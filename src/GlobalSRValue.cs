#region usings
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
#endregion usings

namespace GlobalSR
{
    #region PluginInfo
    [PluginInfo(Name = "Global S", Category = "Value", AutoEvaluate = true, Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalSValue : IPluginEvaluate
    {
        #region fields & pins
        [Input("Input")]
        public ISpread<float> FInput;

        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FClear;
        #endregion fields & pins

        GlobalSGeneric<float> s;

        private GlobalSValue()
        {
            s = new GlobalSGeneric<float>();
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
        }

        public void Evaluate(int SpreadMax)
        {
            if (s == null)
            {
                s = new GlobalSGeneric<float>();
            }
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
            s.Evaluate(SpreadMax);
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "Value", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRValue : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FClear;


        [Output("Output")]
        public ISpread<float> FOutput;
        #endregion fields & pins

        GlobalRGeneric<float> r;
        private GlobalRValue()
        {
            r = new GlobalRGeneric<float>();
            r.FClear = FClear;
            r.FName = FName;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<float>();
            }
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
