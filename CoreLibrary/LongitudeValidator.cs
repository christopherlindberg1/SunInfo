using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreLibrary
{
    public class LongitudeValidator : ILongitudeValidator
    {
        public bool IsValidLongitude(string value)
        {
            string pattern = @"^[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$";

            return Regex.IsMatch(value, pattern);
        }
    }
}
