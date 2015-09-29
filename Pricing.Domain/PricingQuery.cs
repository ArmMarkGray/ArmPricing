using System;
using System.Collections.Generic;

namespace Pricing.Domain
{
    public class PricingQuery
    {
        public List<Product> Products { get; set; }

        public Func<decimal> Value { get; set; }
    }
}
