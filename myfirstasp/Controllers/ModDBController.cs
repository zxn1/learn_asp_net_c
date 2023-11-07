using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfirstasp.Models;

namespace myfirstasp.Controllers;

// [ApiController]
// [Route("api/[controller]")]
//Kalau nak buat post ni, jangan guna ApiController or custom url. Guna fix default pattern
public class ModDBController : Controller
{
    private readonly MyModDBDbContext dbContext;
    public ModDBController(MyModDBDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // [Route("index")]
    public IActionResult Index()
    {
        if(TempData.ContainsKey("error"))
            ViewBag.Error = TempData["error"];
        return View("index");
    }

    [HttpGet]
    // [Route("get")]
    public async Task<IActionResult> getRecords()
    {
        //get the records from modDBs in db context
        //return Ok(dbContext.modDBs.ToList());
        return Ok(await dbContext.modDBs.ToListAsync());
        //mana mana function yang berkait asynchronous kene letak await
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    // [Route("create")]
    public async Task<IActionResult> InsertRecord(ModDBModel model)
    {
        //passing parameter = request = model
        await dbContext.modDBs.AddAsync(model);
        await dbContext.SaveChangesAsync();

        //nak buat mcm laravel?? return->back()->with('error', 'message');?
        TempData["error"] = "Success!";
        //TempData will be available for one request to display in the view. 

        //return Ok(model);
        return RedirectToAction("Index");
    }
    //notes:
    //untuk function ni kita guna await = async function
    //bila guna await. return data type function mesti async
    //bila async.. kene letak Task<jenis function>
}