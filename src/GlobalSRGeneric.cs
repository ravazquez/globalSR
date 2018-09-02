#region usings
using System.Collections.Generic;
using VVVV.PluginInterfaces.V2;
#endregion usings

namespace GlobalSR
{
    public class GlobalSGeneric<T>
    {
        public ISpread<T> FInput;

        public ISpread<string> FName;

        public ISpread<bool> FClear;

        private List<T> previousValue;
        private string previousName = null;

        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            if (FName[0] != null)
            {
                if (previousValue == null || previousValue.Count != FInput.SliceCount)
                {
                    previousValue = new List<T>(new T[FInput.SliceCount]);
                }
                for (int i = 0; i < FInput.Count; i++)
                {
                    if (FClear[0] && GlobalRepository<T>.entries.ContainsKey(FName[0]))
                        GlobalRepository<T>.entries[FName[0]].Clear();
                    if (FName[0] != previousName)
                    {
                        //lower subscription count for previousName and remove it altogether if count is 0
                        if (previousName != null && GlobalRepository<T>.subscriptions.ContainsKey(previousName))
                        {
                            GlobalRepository<T>.subscriptions[previousName]--;
                            if (GlobalRepository<T>.subscriptions[previousName] == 0)
                            {
                                GlobalRepository<T>.subscriptions.Remove(previousName);
                                GlobalRepository<T>.entries.Remove(previousName);
                            }
                        }
                        previousName = FName[0];

                        //create subscription if Name[0]
                        if (!GlobalRepository<T>.subscriptions.ContainsKey(FName[0]))
                            GlobalRepository<T>.subscriptions.Add(FName[0], 1);
                        else
                            GlobalRepository<T>.subscriptions[FName[0]]++;
                    }
                    if (!FInput[i].Equals(previousValue[i]))
                    {
                        previousValue[i] = FInput[i];
                        if (GlobalRepository<T>.entries.ContainsKey(FName[0]))
                            GlobalRepository<T>.entries[FName[0]].Add(FInput[i]);
                        else
                        {
                            var list = new List<T>();
                            list.Add(FInput[i]);
                            GlobalRepository<T>.entries.Add(FName[0], list);
                        }
                    }
                }
            }
        }
    }

    public class GlobalRGeneric<T>
    {
        public ISpread<string> FName;

        public ISpread<bool> FClear;

        public ISpread<T> FOutput;

        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            if (GlobalRepository<T>.entries.ContainsKey(FName[0]))
            {
                if (FName[0] != null)
                {
                    if (FClear[0])
                        GlobalRepository<T>.entries[FName[0]].Clear();
                    FOutput.SliceCount = GlobalRepository<T>.entries[FName[0]].Count;
                    for (int i = 0; i < FOutput.SliceCount; i++)
                    {
                        FOutput[i] = GlobalRepository<T>.entries[FName[0]][i];
                    }
                }
            }
        }
    }

}
