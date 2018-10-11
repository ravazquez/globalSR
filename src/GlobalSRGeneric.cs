#region usings
using System.Collections.Generic;
using VVVV.PluginInterfaces.V2;
#endregion usings

namespace GlobalSR
{
    public class GlobalSGeneric<T>
    {
        public ISpread<T> FInput;

        public ISpread<string> FInName;

        public ISpread<bool> FInAvoidDuplicates;

        public ISpread<bool> FInAdd;

        public ISpread<bool> FInClear;

        private List<T> previousValue;
        private string previousName = null;

        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            if (FInName[0] != null)
            {
                if (previousValue == null || previousValue.Count != FInput.SliceCount)
                {
                    previousValue = new List<T>(new T[FInput.SliceCount]);
                }
                for (int i = 0; i < FInput.Count; i++)
                {
                    if (FInClear[0] && GlobalRepository<T>.entries.ContainsKey(FInName[0]))
                        GlobalRepository<T>.entries[FInName[0]].Clear();
                    if (FInName[0] != previousName)
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
                        previousName = FInName[0];

                        //create subscription if Name[0]
                        if (!GlobalRepository<T>.subscriptions.ContainsKey(FInName[0]))
                            GlobalRepository<T>.subscriptions.Add(FInName[0], 1);
                        else
                            GlobalRepository<T>.subscriptions[FInName[0]]++;
                    }
                    //if (!FInput[i].Equals(previousValue[i]))
                    if (FInAdd[i])
                    {
                        //previousValue[i] = FInput[i];
                        if (GlobalRepository<T>.entries.ContainsKey(FInName[0]))
                        {
                            if (!FInAvoidDuplicates[i] || (FInAvoidDuplicates[i] && !GlobalRepository<T>.entries[FInName[0]].Contains(FInput[i])))
                                GlobalRepository<T>.entries[FInName[0]].Add(FInput[i]);
                        }
                        else
                        {
                            var list = new List<T>();
                            list.Add(FInput[i]);
                            GlobalRepository<T>.entries.Add(FInName[0], list);
                        }
                    }
                }
            }
        }
    }

    public class GlobalRGeneric<T>
    {
        public ISpread<string> FInName;

        public ISpread<bool> FInClear;

        public ISpread<T> FOutput;

        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            if (GlobalRepository<T>.entries.ContainsKey(FInName[0]))
            {
                if (FInName[0] != null)
                {
                    if (FInClear[0])
                        GlobalRepository<T>.entries[FInName[0]].Clear();
                    FOutput.SliceCount = GlobalRepository<T>.entries[FInName[0]].Count;
                    for (int i = 0; i < FOutput.SliceCount; i++)
                    {
                        FOutput[i] = GlobalRepository<T>.entries[FInName[0]][i];
                    }
                }
            }
        }
    }

}
