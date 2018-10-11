﻿#region usings
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
        public ISpread<string> FInName;

        [Input("Avoid Duplicates", DefaultBoolean = false)]
        public ISpread<bool> FInAvoidDuplicates;

        [Input("Add", DefaultBoolean = false)]
        public ISpread<bool> FInAdd;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FInClear;
        #endregion fields & pins

        GlobalSGeneric<float> s;

        private GlobalSValue()
        {
            s = new GlobalSGeneric<float>();
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
                s = new GlobalSGeneric<float>();
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
    [PluginInfo(Name = "Global R", Category = "Value", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRValue : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "", IsSingle = true)]
        public ISpread<string> FInName;

        [Input("Clear", DefaultBoolean = false, IsSingle = true)]
        public ISpread<bool> FInClear;


        [Output("Output")]
        public ISpread<float> FOutput;
        #endregion fields & pins

        GlobalRGeneric<float> r;
        private GlobalRValue()
        {
            r = new GlobalRGeneric<float>();
            r.FInClear = FInClear;
            r.FInName = FInName;
        }
        public void Evaluate(int SpreadMax)
        {
            if (r == null)
            {
                r = new GlobalRGeneric<float>();
            }
            r.FInClear = FInClear;
            r.FInName = FInName;
            r.FOutput = FOutput;
            r.Evaluate(SpreadMax);
        }
    }
}
