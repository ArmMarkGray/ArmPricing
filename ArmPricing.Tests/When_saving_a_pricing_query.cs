using System;
using NUnit.Framework;
using Pricing.Controllers;

namespace ArmPricing.Tests
{
    [TestFixture]
    public class When_saving_a_pricing_query
    {
        private PricingQueryController controllerUnderTest;

        [SetUp]
        public void SetUpTests()
        {
            controllerUnderTest = new PricingQueryController();
        }

        [Test]
        public void Should_MakeACallToThePricingQueryService_When_AttemptingToRegisterAPricingQuery()
        {
            throw new NotImplementedException();
        }

    }
}
