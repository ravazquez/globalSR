#region usings
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VMath;
#endregion usings

namespace GlobalSR
{
    #region PluginInfo
    [PluginInfo(Name = "Global S", Category = "Transform", AutoEvaluate = true, Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalSTransform : IPluginEvaluate
    {
        #region fields & pins
        [Input("Input")]
        public ISpread<Matrix4x4> FInput;

        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FInName;

        [Input("Avoid Duplicates", DefaultBoolean = false)]
        public ISpread<bool> FInAvoidDuplicates;

        [Input("Add", DefaultBoolean = false)]
        public ISpread<bool> FInAdd;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FInClear;
        #endregion fields & pins

        GlobalSGeneric<Matrix4x4> s;

        private GlobalSTransform()
        {
            s = new GlobalSGeneric<Matrix4x4>();
            s.FInput = FInput;
            s.FInName = FInName;
            s.FInAvoidDuplicates = FInAvoidDuplicates;
            s.FInAdd = FInAdd;
            s.FInClear = FInClear;
        }

        public void Evaluate(int SpreadMax)
        {
            if (s == null)
            {
                s = new GlobalSGeneric<Matrix4x4>();
            }
            s.FInput = FInput;
            s.FInName = FInName;
            s.FInAvoidDuplicates = FInAvoidDuplicates;
            s.FInAdd = FInAdd;
            s.FInClear = FInClear;
            s.Evaluate(SpreadMax);
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "Transform", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRTransform : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FInName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FInClear;


        [Output("Output")]
        public ISpread<Matrix4x4> FOutput;
        #endregion fields & pins

        GlobalRGeneric<Matrix4x4> r;
        private GlobalRTransform()
        {
            r = new GlobalRGeneric<Matrix4x4>();
            r.FInClear = FInClear;
            r.FInName = FInName;
            r.FOutput = FOutput;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<Matrix4x4>();
            }
            r.FInClear = FInClear;
            r.FInName = FInName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
