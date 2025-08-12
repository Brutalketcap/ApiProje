using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.Viewcomponents.AdminLayoutViewComponents
{
    public class _NavbarAdminLayoutComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
