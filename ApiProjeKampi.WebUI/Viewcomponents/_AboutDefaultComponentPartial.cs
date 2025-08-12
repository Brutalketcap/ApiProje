using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _AboutDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
