using System;
using System.Web.Mvc;
using NUnit.Framework;
using Pricing.Controllers;
using Pricing.Mappers;
using Pricing.Models;
using Pricing.Services;
using Rhino.Mocks;

namespace ArmPricing.Tests
{
    [TestFixture]
    public class When_saving_a_pricing_query
    {
        private PricingQueryController _controllerUnderTest;
        private IPricingQueryService _pricingQueryServiceMock;
        private IEmailingService _emailingServiceMock;
        private IMapCustomerPricingModels _customerMapper;
        private ViewResult _result;

        [SetUp]
        public void SetUpTests()
        {
            _pricingQueryServiceMock = MockRepository.GenerateMock<IPricingQueryService>();
            _emailingServiceMock = MockRepository.GenerateMock<IEmailingService>();
            _controllerUnderTest = new PricingQueryController(_pricingQueryServiceMock, _emailingServiceMock);
            _result = _controllerUnderTest.Register() as ViewResult;
        }

        [Test]
        public void Should_MakeACallToThePricingQueryService_When_AttemptingToRegisterAPricingQuery()
        {
            _pricingQueryServiceMock.AssertWasCalled(x => x.RegisterPricingQuery());
        }

        [Test]
        public void Should_MakeACallToTheEmailService_When_RegisteringAPricingQuery()
        {
            _emailingServiceMock.AssertWasCalled(x => x.SendEmailToTheSalesTeam());
        }

        [Test]
        public void Should_SendTheCustomerToTheThankYouPage_When_ThePricingQueryHasBeenRegistered()
        {
            Assert.That(_result.ViewName, Is.EqualTo("ThankYou"));
        }

        [Test]
        public void Should_MapACustomerPricingQueryModelWithCustomerLastName_When_AttemptingToRegisterAPricingQuery()
        {
            _customerMapper.AssertWasCalled(x=>x.Map(Arg<CustomerPricingModel>.Is.Anything));
        }
    }
}
