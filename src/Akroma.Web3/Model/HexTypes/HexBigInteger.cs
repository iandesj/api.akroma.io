using System.Numerics;
using Akroma.Web3.Model.HexConvertors;
using Newtonsoft.Json;

namespace Akroma.Web3.Model.HexTypes
{
    [JsonConverter(typeof(HexRPCTypeJsonConverter<HexBigInteger, BigInteger>))]
    public class HexBigInteger : HexRPCType<BigInteger>
    {


        public HexBigInteger(string hex) : base(new HexBigIntegerBigEndianConvertor(), hex)
        {

        }

        public HexBigInteger(BigInteger value) : base(value, new HexBigIntegerBigEndianConvertor())
        {

        }


    }
}
