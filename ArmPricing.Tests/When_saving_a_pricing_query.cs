using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Pricing.Controllers;
using Pricing.Domain;
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
        private IPricingQueryRepository _pricingQueryRepositoryMock;
        private IEmailingService _emailingServiceMock;
        private ICustomerPricingQueryEngine _customerPricingQueryEngineMock;
        private ViewResult _result;

        [SetUp]
        public void SetUpTests()
        {
            _pricingQueryRepositoryMock = MockRepository.GenerateMock<IPricingQueryRepository>();
            _emailingServiceMock = MockRepository.GenerateMock<IEmailingService>();
            _customerPricingQueryEngineMock = MockRepository.GenerateMock<ICustomerPricingQueryEngine>();

            _controllerUnderTest = new PricingQueryController(_pricingQueryRepositoryMock, _emailingServiceMock, _customerPricingQueryEngineMock);

            var customerPricingModel = SetUpCustomerPricingQueryModel();

            _result = _controllerUnderTest.Register(customerPricingModel) as ViewResult;
        }

        private static CustomerPricingQueryModel SetUpCustomerPricingQueryModel()
        {
            var products = new List<ProductModel> {new ProductModel()};


            return new CustomerPricingQueryModel
            {
                LastName = "Jones",
                Email = "Jones@Bob.com",
                AddressLine1 = "Address1",
                City = "City",
                PostCode = "PostCode",
                Country = "Country",
                Phone = "01234567890",
                Products = products
            };
        }

        [Test]
        public void Should_MakeACallToThePricingQueryRepository_When_AttemptingToRegisterAPricingQuery()
        {
            _pricingQueryRepositoryMock.AssertWasCalled(x => x.RegisterPricingQuery(Arg<PricingQuery>.Is.Anything));
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
        public void Should_MakeACallToTheCustomerPricingQueryEngine_When_AttemptingToRegisterAPricingQuery()
        {
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Is.Anything));
        }

        [Test]
        public void Should_MakeACallToTheCustomerPricingQueryEngineWithCustomerLastName_When_AttemptingToRegisterAPricingQuery()
        {
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.LastName == "Jones")));
        }

        [Test]
        public void Should_MakeACallToTheCustomerPricingQueryEngineWithCustomerEmail_When_AttemptingToRegisterAPricingQuery()
        {
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.Email == "Jones@Bob.com")));
        }

        [Test]
        public void Should_MakeACallToTheTheCustomerPricingQueryEngineWithTheRemainingMandatoryFields_When_AttemptingToRegisterAPricingQuery()
        {
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.AddressLine1 == "Address1")));
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.City == "City")));
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.PostCode == "PostCode")));
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.Country == "Country")));
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m => m.Phone == "01234567890")));
        }

        [Test]
        public void Should_MapCustomerPricingQueryModelWithProducts_When_AttemptingToRegisterAPricingQuery()
        {
            _customerPricingQueryEngineMock.AssertWasCalled(x => x.GenerateQuery(Arg<CustomerPricingQueryModel>.Matches(m=>m.Products.Any())));
        }

        [Test]
        public void Should_CallThePricingQueryRepositoryWithAPricingQuery_When_AttemptingToRegisterAPricingQuery()
        {
            _pricingQueryRepositoryMock.AssertWasCalled(x=>x.RegisterPricingQuery(Arg<PricingQuery>.Is.Anything));
        }
    }
}
