using MerchantGalaxyWPF.CommonClass;
using MerchantGalaxyWPF.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyWPF.Process
{
    public sealed class HowmuchCalculation
    {
        private static readonly Lazy<HowmuchCalculation> instance =
  new Lazy<HowmuchCalculation>(() => new HowmuchCalculation());
        public static HowmuchCalculation Instance { get { return instance.Value; } }
        private HowmuchCalculation() { }
        public string Calculation(string InputValueString, List<DecRomans> Declarative)
        {
            StringBuilder result = new StringBuilder();
            RegexClass reg = new RegexClass();
            reg = ActionConfig.Instance.GetRegex(InputValueString);
            var queryArry = InputValueString.Split(' ');
            var queryArryLength = queryArry.Length;
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
            result.Append("is " + ConstantValue);
            return result.ToString();
        }
    }
}
