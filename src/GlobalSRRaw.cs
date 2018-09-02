#region usings
using System.IO;
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
#endregion usings

namespace GlobalSR
{
    #region PluginInfo
    [PluginInfo(Name = "Global S", Category = "Raw", AutoEvaluate = true, Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalSRaw : IPluginEvaluate
    {
        #region fields & pins
        [Input("Input")]
        public ISpread<Stream> FInput;

        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;
        #endregion fields & pins

        GlobalSGeneric<Stream> s;

        private GlobalSRaw()
        {
            s = new GlobalSGeneric<Stream>();
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
        }

        public void Evaluate(int SpreadMax)
        {
            if (s == null)
            {
                s = new GlobalSGeneric<Stream>();
            }
            s.FInput = FInput;
            s.FName = FName;
            s.FClear = FClear;
            s.Evaluate(SpreadMax);
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "Raw", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRRaw : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;


        [Output("Output")]
        public ISpread<Stream> FOutput;
        #endregion fields & pins

        GlobalRGeneric<Stream> r;
        private GlobalRRaw()
        {
            r = new GlobalRGeneric<Stream>();
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<Stream>();
            }
            r.FClear = FClear;
            r.FName = FName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
