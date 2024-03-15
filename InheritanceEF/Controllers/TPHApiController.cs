using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2;
using WebApplication2.TPH;

namespace InheritanceEF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TPHApiController : ControllerBase
{
    [HttpGet]
    public IActionResult Insert()
    {

        using (var context = new NewContext())
        {
            var Person = new PersonTPH { NationalCode = "1234567898", Family = "testfamily", Name = "testn" };
            var Company = new CompanyTPH { IdentityCode = "787878", Address = "usa,p1", Name = "google" };
            context.BaseEntityTPH.AddRange(Person, Company);
            context.SaveChanges();
        }
        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {

        using (var context = new NewContext())
        {

            var data = context.BaseEntityTPH.ToList();

        }
        return Ok();
    }
}
