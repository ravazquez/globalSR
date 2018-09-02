#region usings
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
#endregion usings

namespace GlobalSR
{
    #region PluginInfo
    [PluginInfo(Name = "Global S", Category = "Color", AutoEvaluate = true, Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalSColor : IPluginEvaluate
    {
        #region fields & pins
        [Input("Input")]
        public ISpread<RGBAColor> FInput;

        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FClear;
        #endregion fields & pins

        GlobalSGeneric<RGBAColor> s;

        private GlobalSColor()
        {
            s = new GlobalSGeneric<RGBAColor>();
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
        }

        public void Evaluate(int SpreadMax)
        {
            if (s == null)
            {
                s = new GlobalSGeneric<RGBAColor>();
            }
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
            s.Evaluate(SpreadMax);
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "Color", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRColor : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FClear;


        [Output("Output")]
        public ISpread<RGBAColor> FOutput;
        #endregion fields & pins

        GlobalRGeneric<RGBAColor> r;
        private GlobalRColor()
        {
            r = new GlobalRGeneric<RGBAColor>();
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<RGBAColor>();
            }
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
