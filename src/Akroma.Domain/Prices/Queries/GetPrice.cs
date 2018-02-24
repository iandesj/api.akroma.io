using System.Collections.Generic;
using Akroma.Domain.Prices.Models;
using Brickweave.Cqrs;

namespace Akroma.Domain.Prices.Queries
{

    public class GetPrice : IQuery<IEnumerable<Price>>
    {
        //Right now we only support price of AKA, once we/people start building tokens on Akroma this method will take in values.
        public GetPrice()
        {
            
        }
        
    }
}
