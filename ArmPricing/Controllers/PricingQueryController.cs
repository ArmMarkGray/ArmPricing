﻿using System.Web.Mvc;
using Pricing.Mappers;
using Pricing.Models;
using Pricing.Repositories;
using Pricing.Services;

namespace Pricing.Controllers
{
    public class PricingQueryController : Controller
    {
        private readonly IPricingQueryRepository _pricingQueryRepository;
        private readonly IEmailingService _emailingService;
        private readonly ICustomerPricingQueryEngine _customerMapper;

        public PricingQueryController()
        {
            
        }

        public PricingQueryController(IPricingQueryRepository pricingQueryRepository, IEmailingService emailingService, ICustomerPricingQueryEngine customerMapper)
        {
            _pricingQueryRepository = pricingQueryRepository;
            _emailingService = emailingService;
            _customerMapper = customerMapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new CustomerPricingQueryInputModel());
        }

        [HttpPost]
        public ActionResult Register(CustomerPricingQueryModel customerPricingQueryModel)
        {
            var pricingQuery = _customerMapper.GenerateQuery(customerPricingQueryModel);
            _pricingQueryRepository.RegisterPricingQuery(pricingQuery);
            _emailingService.SendEmailToTheSalesTeam(pricingQuery);
            return View("ThankYou");
        }
    }
}
