using System;
using Akroma.Web3.Model.HexConvertors.Extensions;
using Akroma.Web3.Model.HexTypes;

namespace Akroma.Web3.Model.HexConvertors
{
    public class HexUTF8StringConvertor : IHexConvertor<string>
    {
        public string ConvertToHex(String value)
        {
            return value.ToHexUTF8();
        }

        public String ConvertFromHex(string hex)
        {
            return hex.HexToUTF8String();
        }

    }
}
