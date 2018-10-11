#region usings
using System.IO;
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
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

        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FInName;

        [Input("Avoid Duplicates", DefaultBoolean = false)]
        public ISpread<bool> FInAvoidDuplicates;

        [Input("Add", DefaultBoolean = false)]
        public ISpread<bool> FInAdd;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FInClear;
        #endregion fields & pins

        GlobalSGeneric<Stream> s;

        private GlobalSRaw()
        {
            s = new GlobalSGeneric<Stream>();
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
                s = new GlobalSGeneric<Stream>();
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
    [PluginInfo(Name = "Global R", Category = "Raw", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRRaw : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FInName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FInClear;


        [Output("Output")]
        public ISpread<Stream> FOutput;
        #endregion fields & pins

        GlobalRGeneric<Stream> r;
        private GlobalRRaw()
        {
            r = new GlobalRGeneric<Stream>();
            r.FInClear = FInClear;
            r.FInName = FInName;
            r.FOutput = FOutput;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<Stream>();
            }
            r.FInClear = FInClear;
            r.FInName = FInName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
