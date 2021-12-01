using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Files.Tasks
{
    internal class RegexMethods
    {
        internal static Regex TransformMaskToRegex(string mask)
        {
            mask = mask.Replace(".", @"\.");
            mask = mask.Replace("?", ".");
            mask = mask.Replace("*", ".*");
            mask = "^" + mask + "$";

            Regex regMask = new Regex(mask, RegexOptions.IgnoreCase);
            return regMask;

        }
    }
}
