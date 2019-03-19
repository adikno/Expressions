using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private CalcDelegate mission;
        public event EventHandler<double> OnCalculate;
        public string Name { get; set; }

        string IMission.Type => "Single";

        public SingleMission(CalcDelegate mission, string name)
        {
            this.mission = mission;
            this.Name = name;
        }

        public double Calculate(double value)
        {
            double result = this.mission(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
