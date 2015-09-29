using System;
using NUnit.Framework;
using Pricing.Controllers;
using Pricing.Services;
using Rhino.Mocks;

namespace ArmPricing.Tests
{
    [TestFixture]
    public class When_saving_a_pricing_query
    {
        private PricingQueryController controllerUnderTest;
        private IPricingQueryService pricingQueryServiceMock;
        private IEmailingService emailingServiceMock;

        [SetUp]
        public void SetUpTests()
        {
            pricingQueryServiceMock = MockRepository.GenerateMock<IPricingQueryService>();
            emailingServiceMock = MockRepository.GenerateMock<IEmailingService>();
            controllerUnderTest = new PricingQueryController(pricingQueryServiceMock);
        }

        [Test]
        public void Should_MakeACallToThePricingQueryService_When_AttemptingToRegisterAPricingQuery()
        {
            controllerUnderTest.Register();
            pricingQueryServiceMock.AssertWasCalled(x => x.RegisterPricingQuery());
        }

        [Test]
        public void Should_MakeACallToTheEmailService_When_RegisteringAPricingQuery()
        {
            controllerUnderTest.Register();
            emailingServiceMock.AssertWasCalled(x => x.SendEmailToTheSalesTeam());
        }

    }
}
