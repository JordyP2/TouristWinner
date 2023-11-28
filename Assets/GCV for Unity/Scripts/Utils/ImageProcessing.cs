using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using static Borders;

public class ImageProcessing : MonoBehaviour
{
    private static float IMAGE_WIDTH;
    private static float IMAGE_HEIGHT;

    public static float ORIGINAL_IMAGE_WIDTH;
    public static float ORIGINAL_IMAGE_HEIGHT;

    private static float RESIZE_MULTIPLIER;

    /// <summary>
    /// This is the most important function. It takes array of vertices (x, y coordinates) and draws rectangles side by side.
    /// For every detected object we receive four coordinates.
    /// To draw lines we have to do some math transformations according to resized image width and height and container pivot.
    /// </summary>
    /// <param name="vertices"></param>
    /// <param name="rectPrefab"></param>
    /// <param name="container"></param>
    /// <param name="image"></param>
    public static void DrawRectangles(List<Vertices[]> vertices, UILineRenderer rectPrefab, GameObject container, Image image)
    {
        List<Vector2> vc = new List<Vector2>();

        foreach (var res in vertices)
        {
            foreach (var v in res)
            {
                float x = v.x * RESIZE_MULTIPLIER;
                float y = v.y * RESIZE_MULTIPLIER;

                x -= IMAGE_WIDTH / 2;
                y -= IMAGE_HEIGHT / 2;

                y *= -1;

                vc.Add(new Vector2(x, y));
            }

            float x1 = res[0].x * RESIZE_MULTIPLIER;
            float y1 = res[0].y * RESIZE_MULTIPLIER;

            x1 -= IMAGE_WIDTH / 2;
            y1 -= IMAGE_HEIGHT / 2;

            y1 *= -1;

            vc.Add(new Vector2(x1, y1));

            UILineRenderer lr = Instantiate(rectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            lr.transform.SetParent(container.transform, false);

            lr.GetComponent<RectTransform>().sizeDelta = image.GetComponent<RectTransform>().sizeDelta;
            lr.Points = vc.ToArray();

            vc.Clear();
        }
    }

    /// <summary>
    /// This function is used to adjust selected image to container size. It resizes image so it fits any screen area.
    /// It's important to save original image width and height somewhere as also new values.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="image"></param>
    /// <param name="container"></param>
    public static void ShowImage(Texture2D texture, Image image, GameObject container)
    { 
        ORIGINAL_IMAGE_WIDTH = texture.width;
        ORIGINAL_IMAGE_HEIGHT = texture.height;

        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);

        RectTransform rt = image.GetComponent<RectTransform>();
        RectTransform rtc = container.GetComponent<RectTransform>();

        float w = rt.rect.width;
        float h = rt.rect.height;

        float w_c = rtc.rect.width;
        float h_c = rtc.rect.height;


        if (w < w_c && h < h_c)
        {
            while (w + w / 10 < rtc.rect.width && h + h / 10 < rtc.rect.height)
            {
                w += w / 10;
                h += h / 10;
            }
        }

        if (w > w_c || h > h_c)
        {
            while (w > w_c || h > h_c)
            {
                w -= w / 10;
                h -= h / 10;
            }
        }

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(w, h);

        IMAGE_WIDTH = w;
        IMAGE_HEIGHT = h;

        RESIZE_MULTIPLIER = IMAGE_WIDTH / ORIGINAL_IMAGE_WIDTH;
    }
}
