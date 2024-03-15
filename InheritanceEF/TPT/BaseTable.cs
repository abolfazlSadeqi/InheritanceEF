using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.TPH;

namespace WebApplication2.TPT;

public class BaseEntityTPT
{
   
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PersonTPT : BaseEntityTPT
{
    public string NationalCode { get; set; }

    public string Family { get; set; }

}

public class CompanyTPT : BaseEntityTPT
{
    public string IdentityCode { get; set; }
    public string Address { get; set; }

}

