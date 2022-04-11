using MerchantGalaxyWPF.CommonClass;
using MerchantGalaxyWPF.UIClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyWPF.Process
{
    public sealed class AssignRomans
    {
        private static readonly Lazy<AssignRomans> instance =
   new Lazy<AssignRomans>(() => new AssignRomans());
        public static AssignRomans Instance { get { return instance.Value; } }
        private AssignRomans() { }
        public string Calculation(string InputValueString, ref DecRomans Dec, List<DecRomans> LstDec)
        {
            RegexClass reg = new RegexClass();
            DecRomans dec = new DecRomans();
            reg = ActionConfig.Instance.GetRegex(InputValueString);
            var queryArry = InputValueString.Split(' ');
            var queryArryLength = queryArry.Length;
            string key = queryArry[queryArryLength - reg.ArrayKeyPartFromEnd];
            string value = queryArry[queryArryLength - reg.ArrayValuePartFromEnd];
            dec.Name = key;
            dec.Roman = value;
            if (CommonConstant.RomanNumbers.Where(a => a.Key == value).Count() == 0)
            {
                return "I have no idea what you are talking about";
            }
            dec.Values = CommonConstant.RomanNumbers.Where(a => a.Key == value).Select(a => a.Value).FirstOrDefault();
            if (LstDec.Where(a => a.Name == key).Count() > 0)
            {
                return "Warning !! same key found.";
            }
            Dec = dec;
            return "Sucess!!Registered information.";
        }
    }
}
