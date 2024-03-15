namespace WebApplication2.TPH;

public class BaseEntityTPH
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PersonTPH : BaseEntityTPH
{
    public string NationalCode { get; set; }

    public string Family { get; set; }

}
public class CompanyTPH : BaseEntityTPH
{
    public string IdentityCode { get; set; }
    public string Address { get; set; }

}