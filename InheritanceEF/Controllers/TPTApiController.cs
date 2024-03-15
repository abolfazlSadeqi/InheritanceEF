using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2;
using WebApplication2.TPT;

namespace InheritanceEF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TPTApiController : ControllerBase
{
    [HttpGet]
    public IActionResult Insert()
    {

        using (var context = new NewContext())
        {
            var Person = new PersonTPT { NationalCode = "1234567898", Family = "testfamily", Name = "testn" };
            var Company = new CompanyTPT { IdentityCode = "787878", Address = "usa,p1", Name = "google" };
            context.BaseEntityTPT.AddRange(Person, Company);
            context.SaveChanges();
        }
        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {

        using (var context = new NewContext())
        {

            var data = context.BaseEntityTPT.ToList();

        }
        return Ok();
    }
}
