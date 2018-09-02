#region usings
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
#endregion usings

namespace GlobalSR
{
    #region PluginInfo
    [PluginInfo(Name = "Global S", Category = "String", AutoEvaluate = true, Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalSString : IPluginEvaluate
    {
        #region fields & pins
        [Input("Input")]
        public ISpread<string> FInput;

        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;
        #endregion fields & pins

        GlobalSGeneric<string> s;

        private GlobalSString()
        {
            s = new GlobalSGeneric<string>();
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
        }

        public void Evaluate(int SpreadMax)
        {
            if (s == null)
            {
                s = new GlobalSGeneric<string>();
            }
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
            s.Evaluate(SpreadMax);
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "String", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRString : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;


        [Output("Output")]
        public ISpread<string> FOutput;
        #endregion fields & pins

        GlobalRGeneric<string> r;
        private GlobalRString()
        {
            r = new GlobalRGeneric<string>();
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<string>();
            }
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
