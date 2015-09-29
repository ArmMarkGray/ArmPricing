using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pricing.Domain
{
    public class PricingQuery
    {
        public List<Product> Products { get; set; }

        public Func<decimal> Value { get; set; }
    }
}
