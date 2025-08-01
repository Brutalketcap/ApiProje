using Microsoft.AspNetCore.Mvc;

 namespace ApiProjeKampi.WebUI.Viewcomponents
{
    public class _NavbarDefaultComponentPartial: ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
