using Microsoft.AspNetCore.Mvc;
using myfirstasp.Models;

[ApiController] // This attribute enables attribute routing for the controller
[Route("api/[controller]")]
public class ApiController : Controller {
    [HttpGet]
    [Route("action1")]
    public ActionResult CustomRoute()
    {
        return Content("test");
    }
    //so cara access function atas ni adalah:
    //http://localhost:5296/api/Api/action1

    //ni salah satu cara custom route juga


    //boleh letak constraints dekat route/request.. macam validate tu la
    //min/max/minlength/maxlength/int/float/guid
    [HttpGet]
    [Route("mantapkali/{year:range(1,12)}/{month:range(2023, 2023)}")]
    public ActionResult CustomParameterRoute(int year, string month)
    {
        return Content(String.Format("test?year={0}&month={1}", year, month));
    }
    //boleh access seperti ini:
    //http://localhost:5296/api/Api/mantapkali/2/2023
}