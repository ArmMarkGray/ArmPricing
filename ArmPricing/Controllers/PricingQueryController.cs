﻿using System.Web.Mvc;
using Pricing.Mappers;
using Pricing.Models;
using Pricing.Services;

namespace Pricing.Controllers
{
    public class PricingQueryController : Controller
    {
        private readonly IPricingQueryService _pricingQueryService;
        private readonly IEmailingService _emailingServiceMock;
        private readonly IMapCustomerPricingModels _customerMapper;

        public PricingQueryController(IPricingQueryService pricingQueryService, IEmailingService emailingServiceMock, IMapCustomerPricingModels customerMapper)
        {
            _pricingQueryService = pricingQueryService;
            _emailingServiceMock = emailingServiceMock;
            _customerMapper = customerMapper;
        }


        [HttpPost]
        public ActionResult Register(CustomerPricingQueryModel customerPricingQueryModel)
        {
            _customerMapper.Map(customerPricingQueryModel);
            _pricingQueryService.RegisterPricingQuery();
            _emailingServiceMock.SendEmailToTheSalesTeam();
            return View("ThankYou");
        }
    }
}
