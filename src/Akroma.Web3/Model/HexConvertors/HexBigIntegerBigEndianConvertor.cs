using System.Numerics;
using Akroma.Web3.Model.HexConvertors.Extensions;
using Akroma.Web3.Model.HexTypes;

namespace Akroma.Web3.Model.HexConvertors
{
    public class HexBigIntegerBigEndianConvertor : IHexConvertor<BigInteger>
    {

        public string ConvertToHex(BigInteger newValue)
        {
            return newValue.ToHex(false);
        }

        public BigInteger ConvertFromHex(string hex)
        {
            return hex.HexToBigInteger(false);
        }

    }
}
