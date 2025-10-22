using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.Viewcomponents.DashboardViewComponents
{
    public class _DashboardEmployeeTaskComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardEmployeeTaskComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return View();
        }
    }
}
