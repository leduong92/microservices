using Microservices.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Microservices.Web.Controllers.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        private readonly IRegionService _regionSevice;
        private readonly ILocalizationService _localizationService;

        public NavMenuViewComponent(IRegionService regionSevice, ILocalizationService localizationService)
        {
            _regionSevice = regionSevice;
            _localizationService = localizationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _localizationService.GetLocalizationsAsync();
            var regions = await _regionSevice.GetRegionsAsync(); ;

            ViewBag.SelectedLanguage = Request.Cookies["language"] ?? "en";
            ViewBag.SelectedRegion = Request.Cookies["region"] ?? "US";

            ViewBag.Languages = languages.Data;
            ViewBag.Regions = regions.Data;

            return View();
        }
    }
}
