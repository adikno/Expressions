using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private List<CalcDelegate> missions;

        public string Name { get; set; }

        string IMission.Type => "Composed";

        public ComposedMission(string name)
        {
            this.Name = name;
            this.missions = new List<CalcDelegate>();
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double result = value;
            foreach(var m in missions)
            {
                result = m(result);
            }
            OnCalculate?.Invoke(this, result);
            return result;
        }

        public ComposedMission Add(CalcDelegate calcDelegate)
        {
            this.missions.Add(calcDelegate);
            return this;
        }
    }
}
