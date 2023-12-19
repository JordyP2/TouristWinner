public class ARTag
{
    private int _tagID;
    public int TagID
    {
        get
        {
            return _tagID;
        }

        set
        {
            _tagID = value;
        }
    }


    private string m_tagName;
    public string tagName
    {
        get
        {
            return m_tagName;
        }

        set
        {
            m_tagName = value;
        }
    }

    public ARTag(int TagID, string TagName)
    {
        this.TagID = TagID;
        tagName = TagName;
    }
}
