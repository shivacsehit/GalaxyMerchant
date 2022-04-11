using MerchantGalaxyWPF.CommonClass;
using MerchantGalaxyWPF.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyWPF.Process
{
    public sealed class AssignMetals
    {
        private static readonly Lazy<AssignMetals> instance =
   new Lazy<AssignMetals>(() => new AssignMetals());
        public static AssignMetals Instance { get { return instance.Value; } }
        private AssignMetals() { }

        public string Calculation(string InputValueString, List<DecRomans> Declarative, ref CalcMetals Calc, List<CalcMetals> LstCalc)
        {
            CalcMetals calc = new CalcMetals();
            var queryArry = InputValueString.Split(' ');
            var queryArryLength = queryArry.Length;
            RegexClass reg = new RegexClass();
            reg = ActionConfig.Instance.GetRegex(InputValueString);
            string key = queryArry[queryArryLength - reg.ArrayKeyPartFromEnd];
            string value = queryArry[queryArryLength - reg.ArrayValuePartFromEnd];
            int calStartIndex = reg.CalculativeIndexRangeStart - 1;
            int calEndIndex = Math.Abs(reg.CalculativeIndexRangeEnd);
            double credits = Convert.ToDouble(queryArry[queryArryLength - reg.ArrayValuePartFromEnd]);
            StringBuilder romancontants = new StringBuilder();
            for (int i = calStartIndex; i < (queryArryLength - calEndIndex); i++)
            {
                var constant = queryArry[i];
                if (Declarative.Where(a => a.Name == constant).Count() == 0)
                {
                    return "Warning !! " + constant + " not found.";
                }

                romancontants.Append(Declarative.Where(a => a.Name == constant).Select(a => a.Roman).FirstOrDefault());
            }
            int ConstantValue = ActionConfig.Instance.ConvertRomanToDecimal(romancontants.ToString());
            var KeyCalulcationValue = GetDelcarativeValue(credits, ConstantValue);
            if (LstCalc.Where(a => a.Metal == key).Count() > 0)
            {
                return "Warning !! same key found.";
            }
            calc.Metal = key;
            calc.Credits = Convert.ToInt32(KeyCalulcationValue);
            Calc = calc;
            return "Sucess!!Registered information.";
        }

        private double GetDelcarativeValue(double _credits, int romanvalues)
        {
            return _credits / romanvalues;
        }



    }
}
