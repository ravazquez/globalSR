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

        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;
        #endregion fields & pins

        GlobalSGeneric<Matrix4x4> s;

        private GlobalSTransform()
        {
            s = new GlobalSGeneric<Matrix4x4>();
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
        }

        public void Evaluate(int SpreadMax)
        {
            if (s == null)
            {
                s = new GlobalSGeneric<Matrix4x4>();
            }
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
            s.Evaluate(SpreadMax);
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "Transform", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRTransform : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;


        [Output("Output")]
        public ISpread<Matrix4x4> FOutput;
        #endregion fields & pins

        GlobalRGeneric<Matrix4x4> r;
        private GlobalRTransform()
        {
            r = new GlobalRGeneric<Matrix4x4>();
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<Matrix4x4>();
            }
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
