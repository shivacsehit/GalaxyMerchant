using MerchantGalaxyWPF.CommonClass;
using MerchantGalaxyWPF.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyWPF.Process
{
    class HowmanyCalculation
    {
        private static readonly Lazy<HowmanyCalculation> instance =
   new Lazy<HowmanyCalculation>(() => new HowmanyCalculation());
        public static HowmanyCalculation Instance { get { return instance.Value; } }
        private HowmanyCalculation() { }
        public string Calculation(string InputValueString, List<DecRomans> Declarative, List<CalcMetals> Calculative)
        {
            StringBuilder result = new StringBuilder();
            var queryArry = InputValueString.Split(' ');
            var queryArryLength = queryArry.Length;
            RegexClass reg = new RegexClass();
            reg = ActionConfig.Instance.GetRegex(InputValueString);
            string key = queryArry[queryArryLength - reg.ArrayKeyPartFromEnd];
            int calStartIndex = reg.CalculativeIndexRangeStart - 1;
            int calEndIndex = Math.Abs(reg.CalculativeIndexRangeEnd);
            StringBuilder romancontants = new StringBuilder();
            for (int i = calStartIndex; i < (queryArryLength - calEndIndex); i++)
            {
                var constant = queryArry[i];
                if (Declarative.Where(a => a.Name == constant).Count() == 0)
                {
                    return "Warning !! " + constant + " not found.";
                }
                romancontants.Append(Declarative.Where(a => a.Name == constant).Select(a => a.Roman).FirstOrDefault());
                result.Append(constant + " ");

            }
            int ConstantValue = ActionConfig.Instance.ConvertRomanToDecimal(romancontants.ToString());
            if (Calculative.Where(a => a.Metal == key).Count() == 0)
            {
                return "Warning !! " + key + " not found.";
            }
            double valueOfMetal = Calculative.Where(a => a.Metal == key).FirstOrDefault().Credits;
            double KeyCalulcationValue = GetCalulcationValue(valueOfMetal, ConstantValue);
            result.Append(key + " is " + KeyCalulcationValue + " Credits");
            return result.ToString(); ;
        }
        private double GetCalulcationValue(double _value, int _constantValue)
        {
            return _value * _constantValue;
        }

    }
}
