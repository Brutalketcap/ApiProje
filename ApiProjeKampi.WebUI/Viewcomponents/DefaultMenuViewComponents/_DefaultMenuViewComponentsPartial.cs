using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.Viewcomponents.DefaultMenuViewComponents
{
    public class _DefaultMenuViewComponentsPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
