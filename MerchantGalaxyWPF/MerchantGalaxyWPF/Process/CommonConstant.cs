using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantGalaxyWPF.CommonClass;
namespace MerchantGalaxyWPF.Process
{
    public class CommonConstant
    {
        public static Dictionary<string, int> RomanNumbers = new Dictionary<string, int>();
        public static List<RegexClass> CommonRegex = new List<RegexClass>();
        public static void GetCommonRegex()
        {
            CommonConstant.CommonRegex.Add(new RegexClass { RegexName = "DECLARATIONQUERY", RegEx = "^([A-Za-z]+) is ([I|V|X|L|C|D|M])$", ArrayLengthMin = 3, ArrayKeyPartFromEnd = 3, ArrayValuePartFromEnd = 1 });
            CommonConstant.CommonRegex.Add(new RegexClass { RegexName = "CALCULATIVEDECLARATIVEQUERY", RegEx = "(.*) is ([0-9]+) ([c|C]redits)$", ArrayLengthMin = 6, ArrayKeyPartFromEnd = 4, ArrayValuePartFromEnd = 2, CalculativeIndexRangeStart = 1, CalculativeIndexRangeEnd = -4 });
            CommonConstant.CommonRegex.Add(new RegexClass { RegexName = "CREDITQUERY", RegEx = "^how many [C|c]redits is .*?$", ArrayLengthMin = 8, ArrayKeyPartFromEnd = 2, CalculativeIndexRangeStart = 5, CalculativeIndexRangeEnd = -2 });
            CommonConstant.CommonRegex.Add(new RegexClass { RegexName = "QUNATITIVEQUERY", RegEx = "^how much is .*?$", ArrayLengthMin = 8, CalculativeIndexRangeStart = 4, CalculativeIndexRangeEnd = -1 });
        }
        public static void GetCommonRoman()
        {
            CommonConstant.RomanNumbers.Add("I", 1);
            CommonConstant.RomanNumbers.Add("V", 5);
            CommonConstant.RomanNumbers.Add("X", 10);
            CommonConstant.RomanNumbers.Add("L", 50);
            CommonConstant.RomanNumbers.Add("C", 100);
            CommonConstant.RomanNumbers.Add("D", 500);
            CommonConstant.RomanNumbers.Add("M", 1000);
        }
    }
}
