using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreLibrary
{
    public class LatitudeValidator : ILatitudeValidator
    {
        public bool IsValidLatitude(string value)
        {
            string pattern = @"^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?)$";

            return Regex.IsMatch(value, pattern);
        }
    }
}
