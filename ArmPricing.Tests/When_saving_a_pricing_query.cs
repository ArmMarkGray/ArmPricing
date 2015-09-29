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
        private IMapCustomerPricingModels _customerMapperMock;
        private ViewResult _result;

        [SetUp]
        public void SetUpTests()
        {
            _pricingQueryServiceMock = MockRepository.GenerateMock<IPricingQueryService>();
            _emailingServiceMock = MockRepository.GenerateMock<IEmailingService>();
            _customerMapperMock = MockRepository.GenerateMock<IMapCustomerPricingModels>();

            _controllerUnderTest = new PricingQueryController(_pricingQueryServiceMock, _emailingServiceMock, _customerMapperMock);

            var customerPricingModel = new CustomerPricingModel
            {
                LastName = "Jones",
                Email = "Jones@Bob.com",
                AddressLine1 = "Address1",
                City = "City",
                PostCode = "PostCode",
                Country = "Country",
                Phone = "01234567890"
            };

            _result = _controllerUnderTest.Register(customerPricingModel) as ViewResult;
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
        public void Should_MakeACallToTheCustomerPricingQueryModelMapper_When_AttemptingToRegisterAPricingQuery()
        {
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Is.Anything));
        }

        [Test]
        public void Should_MapACustomerPricingQueryModelWithCustomerLastName_When_AttemptingToRegisterAPricingQuery()
        {
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.LastName == "Jones")));
        }

        [Test]
        public void Should_MapACustomerPricingQueryModelWithCustomerEmail_When_AttemptingToRegisterAPricingQuery()
        {
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.Email == "Jones@Bob.com")));
        }

        [Test]
        public void Should_MapRemainingMandatoryFieldsFromTheCustomerPricingQueryModel_When_AttemptingToRegisterAPricingQuery()
        {
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.AddressLine1 == "Address1")));
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.City == "City")));
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.PostCode == "PostCode")));
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.Country == "Country")));
            _customerMapperMock.AssertWasCalled(x => x.Map(Arg<CustomerPricingModel>.Matches(m => m.Phone == "01234567890")));
        }
    }
}
