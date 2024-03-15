using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2;
using WebApplication2.TPC;

namespace InheritanceEF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TPCApiController : ControllerBase
{
    [HttpGet]
    public IActionResult Insert()
    {

        using (var context = new NewContext())
        {
            var Person = new PersonTPC { NationalCode = "1234567898", Family = "testfamily", Name = "testn" };
            var Company = new CompanyTPC { IdentityCode = "787878", Address = "usa,p1", Name = "google" };
            context.BaseEntityTPC.AddRange(Person, Company);
            context.SaveChanges();
        }
        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {

        using (var context = new NewContext())
        {

            var data = context.BaseEntityTPC.ToList();

        }
        return Ok();
    }
}
