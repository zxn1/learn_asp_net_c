using Microsoft.AspNetCore.Mvc;
using myfirstasp.Models;

public class HelloController : Controller
{
    //public IActionResult Greet()
    //nape bawah guna ViewResult? lebih practical guna yang lebih specific dengan needs
    public ViewResult Greet()
    {
        var model = new GreetModel
        {
            Message = "Hello, World!"
        };
        //return View(model); //<--- ViewResult

        //atau kalau taknak guna macam atas, macam na guna specific view file nama lain. Nama view file lain dari nama action.
        return View("Greet", model); //<-- Greet tu kalau ada view file nama lain bole tukar.. 

        //alternatively we can do return as below:
        //return new ViewResult();
        
        //or if we want to return with model
        // var viewResult = new ViewResult();
        // viewResult.ViewData.Model = model;
        // return viewResult;
    }

    //IActionResult vs ActionResult
    //semua subtype ada dalam IActionResult, tapi ada kelebihan
    //dia offers customresult

    //ActionResult is an abstract class
    //dalam dia ada banyak subtypes, cthnya:
    // ViewResult - Renders a specifed view to the response stream
    // PartialViewResult - Renders a specifed partial view to the response stream
    // EmptyResult - An empty response is returned
    // RedirectResult - Performs an HTTP redirection to a specifed URL
    // RedirectToRouteResult - Performs an HTTP redirection to a URL that is determined by the routing engine, based on given route data
    // JsonResult - Serializes a given ViewData object to JSON format
    // JavaScriptResult - Returns a piece of JavaScript code that can be executed on the client
    // ContentResult - Writes content to the response stream without requiring a view
    // FileContentResult - Returns a file to the client
    // FileStreamResult - Returns a file to the client, which is provided by a Stream
    // FilePathResult - Returns a file to the client

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PostAction(GreetModel greet)
    {
        //GreetModel greet tu, ibarat $request.. tapi dalam asp ni, form post tu guna concept model terus.

        var jsonData = new { Name = greet.Message, ID = 4, DateOfBirth = new DateTime(1988, 02, 29) };
        return new JsonResult(jsonData);
    }

    //buat je function dekat controller.. with parameter int id tu.. nanti boleh access dan passing dah
    //http://localhost:5296/Hello/Edit/2
    //@atau
    //http://localhost:5296/Hello/Edit?id=2
    public ActionResult Edit(int id)
    {
        return Content("id=" + id);
    }
    //incase kalau kita tukar parameter tu int id tu jadi int movieid
    //kita tak boleh buat mcm ni dah /Hello/Edit/2
    //sebab url patter kita guna id
    //pattern: "{controller=Home}/{action=Index}/{id?}");

    //maksudnya int? mungkin id tak dipassing/null
    public ActionResult NullableID(int? id, string? test)
    {
        if(id == null || !id.HasValue)
        {
            id = 1;
        } else {
            id = id + 41;
        }

        if(String.IsNullOrWhiteSpace(test))
        {
            test = "What are you doing?";
        }

        return Content(String.Format("pageIndex={0}&sortBy={1}", id, test));
    }
    //dah boleh access mcm ni
    //http://localhost:5296/Hello/NullableID/1/asda
    //sebab dah buat custom route dekat program.cs  


    //passing data?
    //sebelum ni kita passing guna object model yang kita create kan?
    public ActionResult PassingDataToView()
    {
        ViewData["Kucing"] = "nak passing model pun boleh sini";
        //ada satu lagi ViewBag
        ViewBag.Kucings = "nak passing model pun boleh 2";

        //sebenarnya dua dua viewdata dan viewbag tu sama je haha
        //wonder why microsoft buat dua jenis ni
        //youtuber pun no idea kenapa

        //var viewResult = new ViewResult();
        //viewResult.ViewData.Model = model;

        

        //Next, combine multiple model
        var modelA = new ModAModel() { Name = "Harimau" };
        var modelB = new ModBModel() { Name = "Kucing" };

        var listModA = new List<ModAModel> {
            new ModAModel() { Name = "Talapia" },
            new ModAModel() { Name = "Jengking" },
            modelA,
        };

        var viewCombinedModel = new ViewModelABModel()
        {
            modelA = modelA,
            modelB = modelB,
            listModA = listModA
        };

        //x caya try tgk view file...
        return View(viewCombinedModel);
    }
}
