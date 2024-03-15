using WebApplication2.TPT;

namespace WebApplication2.TPC;

public abstract class BaseEntityTPC
{

    public int Id { get; set; }
    public string Name { get; set; }
}

public class PersonTPC : BaseEntityTPC
{
    public string NationalCode { get; set; }

    public string Family { get; set; }

}

public class CompanyTPC : BaseEntityTPC
{
    public string IdentityCode { get; set; }
    public string Address { get; set; }

}
