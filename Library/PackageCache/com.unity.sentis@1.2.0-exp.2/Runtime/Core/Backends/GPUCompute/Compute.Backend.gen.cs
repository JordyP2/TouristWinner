// This is auto-generated -- do not modify directly

using System;
using Unity.Sentis;
using UnityEngine.Assertions;
using static Unity.Sentis.ComputeTensorData;
using static Unity.Sentis.ShaderPropertyID;

namespace Unity.Sentis
{
    public partial class GPUComputeBackend
    {
        // Binary Broadcast

        /// <inheritdoc/>
        public override void Pow(TensorFloat A, TensorFloat B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastPowFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastPowFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwisePowFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Add(TensorFloat A, TensorFloat B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastAddFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastAddFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseAddFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Sub(TensorFloat A, TensorFloat B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastSubFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastSubFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseSubFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Mul(TensorFloat A, TensorFloat B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMulFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMulFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMulFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Div(TensorFloat A, TensorFloat B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastDivFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastDivFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseDivFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void FMod(TensorFloat A, TensorFloat B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastFModFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastFModFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseFModFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Pow(TensorFloat A, TensorInt B, TensorFloat O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastPowInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastPowInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwisePowInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Add(TensorInt A, TensorInt B, TensorInt O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastAddInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastAddInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseAddInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Sub(TensorInt A, TensorInt B, TensorInt O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastSubInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastSubInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseSubInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Mul(TensorInt A, TensorInt B, TensorInt O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMulInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMulInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMulInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Div(TensorInt A, TensorInt B, TensorInt O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastDivInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastDivInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseDivInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Mod(TensorInt A, TensorInt B, TensorInt O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastModInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastModInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseModInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void FMod(TensorInt A, TensorInt B, TensorInt O)
        {
            if (A.shape == O.shape && B.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastFModInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (A.shape == O.shape && B.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastFModInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(A));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(B));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseFModInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, A.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, B.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(A), Pin(B), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        // Variadic Broadcast

        void BroadcastMin(TensorFloat X, TensorFloat Y, TensorFloat O)
        {
            if (X.shape == O.shape && Y.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMinFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (X.shape == O.shape && Y.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMinFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMinFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, X.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, Y.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(X), Pin(Y), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Min(TensorFloat[] tensors, TensorFloat O)
        {
            var Otmp = (tensors.Length > 2) ? NewTempTensorFloat(O.shape) : null;

            var curX = tensors[0];
            var curO = tensors.Length % 2 == 0 ? O : Otmp;
            for (var t = 1; t < tensors.Length; t++)
            {
                BroadcastMin(curX, tensors[t], curO);
                curX = curO;
                curO = curO == O ? Otmp : O;
            }

            Logger.AssertIsTrue(curO != O, "Output tensor should have been the persistent one.");
        }

        void BroadcastMax(TensorFloat X, TensorFloat Y, TensorFloat O)
        {
            if (X.shape == O.shape && Y.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMaxFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (X.shape == O.shape && Y.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMaxFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMaxFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, X.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, Y.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(X), Pin(Y), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Max(TensorFloat[] tensors, TensorFloat O)
        {
            var Otmp = (tensors.Length > 2) ? NewTempTensorFloat(O.shape) : null;

            var curX = tensors[0];
            var curO = tensors.Length % 2 == 0 ? O : Otmp;
            for (var t = 1; t < tensors.Length; t++)
            {
                BroadcastMax(curX, tensors[t], curO);
                curX = curO;
                curO = curO == O ? Otmp : O;
            }

            Logger.AssertIsTrue(curO != O, "Output tensor should have been the persistent one.");
        }

        void BroadcastMean(TensorFloat X, TensorFloat Y, TensorFloat O, float normalizationX, float normalizationY)
        {
            if (X.shape == O.shape && Y.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMeanFloat");
                fn.SetFloat(k_ID_alpha, normalizationX);
                fn.SetFloat(k_ID_beta, normalizationY);
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (X.shape == O.shape && Y.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMeanFloat");
                fn.SetFloat(k_ID_alpha, normalizationX);
                fn.SetFloat(k_ID_beta, normalizationY);
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMeanFloat");
                fn.SetFloat(k_ID_alpha, normalizationX);
                fn.SetFloat(k_ID_beta, normalizationY);
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, X.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, Y.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(X), Pin(Y), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Mean(TensorFloat[] tensors, TensorFloat O)
        {
            var Otmp = (tensors.Length > 2) ? NewTempTensorFloat(O.shape) : null;

            var curX = tensors[0];
            var curO = tensors.Length % 2 == 0 ? O : Otmp;
            for (var t = 1; t < tensors.Length; t++)
            {
                BroadcastMean(curX, tensors[t], curO, t == 1 ? 1.0f / tensors.Length : 1.0f, 1.0f / tensors.Length);
                curX = curO;
                curO = curO == O ? Otmp : O;
            }

            Logger.AssertIsTrue(curO != O, "Output tensor should have been the persistent one.");
        }

        void BroadcastSum(TensorFloat X, TensorFloat Y, TensorFloat O)
        {
            if (X.shape == O.shape && Y.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastAddFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (X.shape == O.shape && Y.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastAddFloat");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseAddFloat");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, X.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, Y.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(X), Pin(Y), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Sum(TensorFloat[] tensors, TensorFloat O)
        {
            var Otmp = (tensors.Length > 2) ? NewTempTensorFloat(O.shape) : null;

            var curX = tensors[0];
            var curO = tensors.Length % 2 == 0 ? O : Otmp;
            for (var t = 1; t < tensors.Length; t++)
            {
                BroadcastSum(curX, tensors[t], curO);
                curX = curO;
                curO = curO == O ? Otmp : O;
            }

            Logger.AssertIsTrue(curO != O, "Output tensor should have been the persistent one.");
        }

        void BroadcastMin(TensorInt X, TensorInt Y, TensorInt O)
        {
            if (X.shape == O.shape && Y.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMinInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (X.shape == O.shape && Y.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMinInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMinInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, X.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, Y.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(X), Pin(Y), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Min(TensorInt[] tensors, TensorInt O)
        {
            var Otmp = (tensors.Length > 2) ? NewTempTensorInt(O.shape) : null;

            var curX = tensors[0];
            var curO = tensors.Length % 2 == 0 ? O : Otmp;
            for (var t = 1; t < tensors.Length; t++)
            {
                BroadcastMin(curX, tensors[t], curO);
                curX = curO;
                curO = curO == O ? Otmp : O;
            }

            Logger.AssertIsTrue(curO != O, "Output tensor should have been the persistent one.");
        }

        void BroadcastMax(TensorInt X, TensorInt Y, TensorInt O)
        {
            if (X.shape == O.shape && Y.shape.length == 1)
            {
                var fn = ComputeFuncSingleton.Instance.Get("ScalarBroadcastMaxInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else if (X.shape == O.shape && Y.shape == O.shape)
            {
                var fn = ComputeFuncSingleton.Instance.Get("BroadcastMaxInt");
                fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
                fn.SetTensorAsBuffer(k_ID_Bptr, Pin(Y));
                fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
                fn.SetInt(k_ID_LengthO, O.shape.length - 1);
                var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
                var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
                var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
                fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
                fn.Dispatch(numBlocksX, numBlocksY, 1);
            }
            else
            {
                var fn = ComputeFuncSingleton.Instance.Get("ElementwiseMaxInt");
                fn.SetTensorShapeStrides(k_ID_shapeO, k_ID_stridesO, O.shape);
                fn.SetTensorShapeStrides(k_ID_shapeX, k_ID_stridesX, X.shape);
                fn.SetTensorShapeStrides(k_ID_shapeY, k_ID_stridesY, Y.shape);
                fn.SetInt(k_ID_rank, (TensorShape.maxRank - 1) - O.shape.rank);

                fn.ScheduleXBO(Pin(X), Pin(Y), Pin(O, clearOnInit: false), O.shape.length);
            }
        }

        /// <inheritdoc/>
        public override void Max(TensorInt[] tensors, TensorInt O)
        {
            var Otmp = (tensors.Length > 2) ? NewTempTensorInt(O.shape) : null;

            var curX = tensors[0];
            var curO = tensors.Length % 2 == 0 ? O : Otmp;
            for (var t = 1; t < tensors.Length; t++)
            {
                BroadcastMax(curX, tensors[t], curO);
                curX = curO;
                curO = curO == O ? Otmp : O;
            }

            Logger.AssertIsTrue(curO != O, "Output tensor should have been the persistent one.");
        }

        // Reduction

        /// <inheritdoc/>
        public override void ReduceMin(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceMinFloat", "GlobalReduceMinFloat", "UnrolledReduceMinFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceMinFloat", "GlobalReduceMinFloat", "UnrolledReduceMinFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceMinFloat", "GlobalReduceMinFloat", "UnrolledReduceMinFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceMax(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceMaxFloat", "GlobalReduceMaxFloat", "UnrolledReduceMaxFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceMaxFloat", "GlobalReduceMaxFloat", "UnrolledReduceMaxFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceMaxFloat", "GlobalReduceMaxFloat", "UnrolledReduceMaxFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceSum(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceSumSquare(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceSumSquareFloat", "GlobalReduceSumSquareFloat", "UnrolledReduceSumSquareFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;
            bool isInitial = true;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else if (isInitial)
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumSquareFloat", "GlobalReduceSumSquareFloat", "UnrolledReduceSumSquareFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                    isInitial = false;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            if (isInitial)
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumSquareFloat", "GlobalReduceSumSquareFloat", "UnrolledReduceSumSquareFloat");
            }
            else
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceMean(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceMeanFloat", "GlobalReduceMeanFloat", "UnrolledReduceMeanFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceMeanFloat", "GlobalReduceMeanFloat", "UnrolledReduceMeanFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceMeanFloat", "GlobalReduceMeanFloat", "UnrolledReduceMeanFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceProd(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceProdFloat", "GlobalReduceProdFloat", "UnrolledReduceProdFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceProdFloat", "GlobalReduceProdFloat", "UnrolledReduceProdFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceProdFloat", "GlobalReduceProdFloat", "UnrolledReduceProdFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceL1(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceL1Float", "GlobalReduceL1Float", "UnrolledReduceL1Float");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;
            bool isInitial = true;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else if (isInitial)
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceL1Float", "GlobalReduceL1Float", "UnrolledReduceL1Float");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                    isInitial = false;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            if (isInitial)
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceL1Float", "GlobalReduceL1Float", "UnrolledReduceL1Float");
            }
            else
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceL2(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceL2Float", "GlobalReduceL2Float", "UnrolledReduceL2Float");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;
            bool isInitial = true;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else if (isInitial)
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumSquareFloat", "GlobalReduceSumSquareFloat", "UnrolledReduceSumSquareFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                    isInitial = false;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            if (isInitial)
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceL2Float", "GlobalReduceL2Float", "UnrolledReduceL2Float");
            }
            else
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSqrtFloat", "GlobalReduceSqrtFloat", "UnrolledReduceSqrtFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceLogSum(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceLogSumFloat", "GlobalReduceLogSumFloat", "UnrolledReduceLogSumFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumFloat", "GlobalReduceSumFloat", "UnrolledReduceSumFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceLogSumFloat", "GlobalReduceLogSumFloat", "UnrolledReduceLogSumFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceLogSumExp(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                var Xmax = NewTempTensorFloat(O.shape);
                Reduce(X, Xmax, 1, X.shape.length, 1, "ReduceMaxFloat", "GlobalReduceMaxFloat", "UnrolledReduceMaxFloat");
                Reduce(X, Xmax, O, 1, X.shape.length, 1, "ReduceLogSumExpFloat", "GlobalReduceLogSumExpFloat", "UnrolledReduceLogSumExpFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    var Xmax = NewTempTensorFloat(shapeXReduced);
                    Reduce(X, Xmax, outerLength, reduceLength, innerLength, "ReduceMaxFloat", "GlobalReduceMaxFloat", "UnrolledReduceMaxFloat");
                    Reduce(X, Xmax, Otmp, outerLength, reduceLength, innerLength, "ReduceLogSumExpFloat", "GlobalReduceLogSumExpFloat", "UnrolledReduceLogSumExpFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                var Xmax = NewTempTensorFloat(shapeXReduced);
                Reduce(X, Xmax, outerLength, reduceLength, innerLength, "ReduceMaxFloat", "GlobalReduceMaxFloat", "UnrolledReduceMaxFloat");
                Reduce(X, Xmax, O, outerLength, reduceLength, innerLength, "ReduceLogSumExpFloat", "GlobalReduceLogSumExpFloat", "UnrolledReduceLogSumExpFloat");
            }
        }

        /// <inheritdoc/>
        public void ReduceSumExp(TensorFloat X, TensorFloat O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceSumExpFloat", "GlobalReduceSumExpFloat", "UnrolledReduceSumExpFloat");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorFloat(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumExpFloat", "GlobalReduceSumExpFloat", "UnrolledReduceSumExpFloat");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumExpFloat", "GlobalReduceSumExpFloat", "UnrolledReduceSumExpFloat");
            }
        }

        /// <inheritdoc/>
        public override void ReduceMin(TensorInt X, TensorInt O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceMinInt", "GlobalReduceMinInt", "UnrolledReduceMinInt");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceMinInt", "GlobalReduceMinInt", "UnrolledReduceMinInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceMinInt", "GlobalReduceMinInt", "UnrolledReduceMinInt");
            }
        }

        /// <inheritdoc/>
        public override void ReduceMax(TensorInt X, TensorInt O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceMaxInt", "GlobalReduceMaxInt", "UnrolledReduceMaxInt");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceMaxInt", "GlobalReduceMaxInt", "UnrolledReduceMaxInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceMaxInt", "GlobalReduceMaxInt", "UnrolledReduceMaxInt");
            }
        }

        /// <inheritdoc/>
        public override void ReduceSum(TensorInt X, TensorInt O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");
            }
        }

        /// <inheritdoc/>
        public override void ReduceSumSquare(TensorInt X, TensorInt O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceSumSquareInt", "GlobalReduceSumSquareInt", "UnrolledReduceSumSquareInt");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;
            bool isInitial = true;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else if (isInitial)
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumSquareInt", "GlobalReduceSumSquareInt", "UnrolledReduceSumSquareInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                    isInitial = false;
                }
                else
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            if (isInitial)
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumSquareInt", "GlobalReduceSumSquareInt", "UnrolledReduceSumSquareInt");
            }
            else
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");
            }
        }

        /// <inheritdoc/>
        public override void ReduceProd(TensorInt X, TensorInt O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceProdInt", "GlobalReduceProdInt", "UnrolledReduceProdInt");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceProdInt", "GlobalReduceProdInt", "UnrolledReduceProdInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceProdInt", "GlobalReduceProdInt", "UnrolledReduceProdInt");
            }
        }

        /// <inheritdoc/>
        public override void ReduceL1(TensorInt X, TensorInt O, ReadOnlySpan<int> axes, bool keepdim)
        {
            if (axes == null || axes.Length == 0)
            {
                Reduce(X, O, 1, X.shape.length, 1, "ReduceL1Int", "GlobalReduceL1Int", "UnrolledReduceL1Int");
                return;
            }

            // Accumulate reduce axis until non contiguity
            // X: (2 3 4 5 6), reduce 0,1,4
            // reduce 0 + 1 will result in a fused reduce on axis 2*3
            // 4 breaks contiguity, thus we perform the previous reduce and start procedure over

            int axis = X.shape.Axis(axes[0]);
            int innerLength = X.shape.Strides(axis);
            int outerLength = X.shape.Length(0, axis);
            int dimX = X.shape[axis];
            int reduceLength = dimX;
            TensorShape shapeXReduced = X.shape;
            shapeXReduced[axis] = 1;
            int prevAxis = axis;
            bool isInitial = true;

            for (int i = 1; i < axes.Length; i++)
            {
                axis = X.shape.Axis(axes[i]);
                dimX = X.shape[axis];
                Assert.AreNotEqual(0, X.shape[axis], "ValueError: zero-size array to reduction operation which has no identity.");

                if ((axis == (prevAxis + 1)))
                {
                    innerLength /= dimX;
                    reduceLength *= dimX;
                }
                else if (isInitial)
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceL1Int", "GlobalReduceL1Int", "UnrolledReduceL1Int");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                    isInitial = false;
                }
                else
                {
                    var Otmp = NewTempTensorInt(shapeXReduced);

                    Reduce(X, Otmp, outerLength, reduceLength, innerLength, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");

                    X = Otmp;
                    innerLength = X.shape.Strides(axis);
                    outerLength = X.shape.Length(0, axis);
                    reduceLength = dimX;
                }

                shapeXReduced[axis] = 1;
                prevAxis = axis;
            }

            if (isInitial)
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceL1Int", "GlobalReduceL1Int", "UnrolledReduceL1Int");
            }
            else
            {
                Reduce(X, O, outerLength, reduceLength, innerLength, "ReduceSumInt", "GlobalReduceSumInt", "UnrolledReduceSumInt");
            }
        }

        /// <inheritdoc/>
        public override void ScalarMad(TensorFloat X, TensorFloat O, float s, float b)
        {
            if (X.shape.HasZeroDims())
                return;
            var fn = new ComputeFunc("ScalarMad");
            fn.SetTensorAsBuffer(k_ID_Xptr, Pin(X));
            fn.SetFloat(k_ID_s, s);
            fn.SetFloat(k_ID_b, b);
            fn.SetTensorAsBuffer(k_ID_Optr, Pin(O, clearOnInit: false));
            fn.SetInt(k_ID_LengthO, O.shape.length - 1);
            var numThreads = ComputeHelper.IDivC(O.shape.length, 4);
            var numBlocksY = ComputeHelper.IDivC(numThreads, (int)ComputeFunc.SafeDispatchLimit);
            var numBlocksX = ComputeHelper.IDivC(numThreads, numBlocksY);
            fn.SetInt(k_ID_MaxBlockIndexX, numBlocksX * 4);
            fn.Dispatch(numBlocksX, numBlocksY, 1);
        }
    }
}
