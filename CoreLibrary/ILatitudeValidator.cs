using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    public interface ILatitudeValidator
    {
        bool IsValidLatitude(string value);
    }
}
