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
        [Input("Input", DefaultValue = 0)]
        public ISpread<float> FInput;

        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;
        #endregion fields & pins

        private float previousValue = 0;
        private string previousName = null;
        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            if (FName[0] != null)
            {
                if (FClear[0] && GlobalRepository<float>.entries.ContainsKey(FName[0]))
                    GlobalRepository<float>.entries[FName[0]].Clear();
                if (FName[0] != previousName)
                {
                    //lower subscription count for previousName and remove it altogether if count is 0
                    if (previousName != null && GlobalRepository<float>.subscriptions.ContainsKey(previousName))
                    {
                        GlobalRepository<float>.subscriptions[previousName]--;
                        if (GlobalRepository<float>.subscriptions[previousName] == 0)
                        {
                            GlobalRepository<float>.subscriptions.Remove(previousName);
                            GlobalRepository<float>.entries.Remove(previousName);
                        }
                    }
                    previousName = FName[0];

                    //create subscription if Name[0]
                    if (!GlobalRepository<float>.subscriptions.ContainsKey(FName[0]))
                        GlobalRepository<float>.subscriptions.Add(FName[0], 1);
                    else
                        GlobalRepository<float>.subscriptions[FName[0]]++;
                }
                if (FInput[0] != previousValue)
                {
                    previousValue = FInput[0];
                    if (GlobalRepository<float>.entries.ContainsKey(FName[0]))
                        GlobalRepository<float>.entries[FName[0]].Add(FInput[0]);
                    else
                    {
                        var list = new System.Collections.Generic.List<float>();
                        list.Add(FInput[0]);
                        GlobalRepository<float>.entries.Add(FName[0], list);
                    }
                }
            }
        }
    }

    #region PluginInfo
    [PluginInfo(Name = "Global R", Category = "Value", Author = "ravazquez")]
    #endregion PluginInfo
    public class GlobalRValue : IPluginEvaluate
    {
        #region fields & pins
        [Input("Name", DefaultString = "")]
        public ISpread<string> FName;

        [Input("Clear", DefaultBoolean = false)]
        public ISpread<bool> FClear;


        [Output("Output")]
        public ISpread<float> FOutput;
        #endregion fields & pins

        private float previous = 0;
        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            if (GlobalRepository<float>.entries.ContainsKey(FName[0]))
            {
                if (FName[0] != null) { 
                    if (FClear[0])
                        GlobalRepository<float>.entries[FName[0]].Clear();
                    FOutput.SliceCount = GlobalRepository<float>.entries[FName[0]].Count;
                    for (int i = 0; i < FOutput.SliceCount; i++)
                    {
                        FOutput[i] = GlobalRepository<float>.entries[FName[0]][i];
                    }
                }
            }
        }
    }

}
