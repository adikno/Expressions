using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double CalcDelegate(double x);

    public class FunctionsContainer
    {
        private Dictionary<string, CalcDelegate> AllMissions = new Dictionary<string, CalcDelegate>();

        public CalcDelegate this[string index]
        {
            get {
                if (!AllMissions.ContainsKey(index))
                {
                    AllMissions.Add(index, val => val);
                }
                return AllMissions[index];
            }
            set
            {
                if (!AllMissions.ContainsKey(index))
                {
                    AllMissions.Add(index, value);
                } else
                {
                    AllMissions[index] = value;
                }
            }
        }

        public List<string> getAllMissions()
        {
            List<string> names = new List<string>();
            foreach(var m in AllMissions)
            {
                names.Add(m.Key);
            }
            return names;
        }
    }
}
