using System.Web.Mvc;
using NUnit.Framework;
using Pricing.Controllers;
using Pricing.Mappers;
using Pricing.Models;
using Pricing.Repositories;
using Pricing.Services;
using Rhino.Mocks;

namespace ArmPricing.Tests
{
    [TestFixture]
    public class When_loading_the_pricing_query_index_page
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

            _result = _controllerUnderTest.Index() as ViewResult;

        }

        [Test]
        public void Should_ReturnACustomerPricingQueryInputModel_When_AttemptingToLoadTheIndexPage()
        {
            Assert.That(_result.Model, Is.TypeOf<CustomerPricingQueryInputModel>());
        }
    }
}
