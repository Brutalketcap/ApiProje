using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
