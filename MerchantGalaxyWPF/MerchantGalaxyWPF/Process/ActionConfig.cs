using MerchantGalaxyWPF.CommonClass;
using MerchantGalaxyWPF.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MerchantGalaxyWPF.Process
{
    public sealed class ActionConfig
    {
        private static readonly Lazy<ActionConfig> instance =
    new Lazy<ActionConfig>(() => new ActionConfig());
        public static ActionConfig Instance { get { return instance.Value; } }
        public int ConvertRomanToDecimal(string romanNumber)
        {


            var Decimalvalues = romanNumber.Select(GetDecimal).Reverse().ToArray();
            var result = 0;
            var currentValue = 0;
            var previousValue = 0;

            for (var i = 0; i < Decimalvalues.Length; i++)
            {
                currentValue = Decimalvalues[i];
                currentValue = previousValue > currentValue ? -currentValue : currentValue;
                result += currentValue;
                previousValue = currentValue;
            }

            return result;
        }
        private int GetDecimal(char _romanChar)
        {
            return CommonConstant.RomanNumbers.Where(v => v.Key == _romanChar.ToString()).FirstOrDefault().Value;
        }
        public RegexClass GetRegex(string Query)
        {


            foreach (var queryConfig in CommonConstant.CommonRegex)
            {
                Regex regex = new Regex(queryConfig.RegEx);
                Match match = regex.Match(Query);
                if (match.Success)
                {
                    return queryConfig;
                }
            }
            return null;
        }



    }
}
