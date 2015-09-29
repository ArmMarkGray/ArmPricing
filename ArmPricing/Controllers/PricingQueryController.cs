using System.Web.Mvc;
using Pricing.Services;

namespace Pricing.Controllers
{
    public class PricingQueryController : Controller
    {
        private readonly IPricingQueryService _pricingQueryService;

        public PricingQueryController(IPricingQueryService pricingQueryService)
        {
            _pricingQueryService = pricingQueryService;
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
