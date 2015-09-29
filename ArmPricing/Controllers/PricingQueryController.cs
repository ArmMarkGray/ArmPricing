using System.Web.Mvc;
using Pricing.Services;

namespace Pricing.Controllers
{
    public class PricingQueryController : Controller
    {
        private readonly IPricingQueryService _pricingQueryService;
        private readonly IEmailingService _emailingServiceMock;

        public PricingQueryController(IPricingQueryService pricingQueryService, IEmailingService emailingServiceMock)
        {
            _pricingQueryService = pricingQueryService;
            _emailingServiceMock = emailingServiceMock;
        }


        [HttpPost]
        public ActionResult Register()
        {
            _pricingQueryService.RegisterPricingQuery();
            _emailingServiceMock.SendEmailToTheSalesTeam();
            return View();
        }
    }
}
