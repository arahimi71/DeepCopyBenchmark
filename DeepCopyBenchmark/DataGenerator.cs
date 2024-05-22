using Bogus;

namespace DeepCopyBenchmark;

public class DataGenerator
{
    public static List<Company> GenerateCompanyData(int numberOfCompanies)
    {
        var addressFaker = new Faker<Address>()
            .RuleFor(a => a.Street, f => f.Address.StreetAddress())
            .RuleFor(a => a.City, f => f.Address.City());

        var personFaker = new Faker<Person>()
            .RuleFor(p => p.Name, f => f.Name.FullName())
            .RuleFor(p => p.Age, f => f.Random.Int(20, 60))
            .RuleFor(p => p.Address, f => addressFaker.Generate())
            .RuleFor(p => p.PhoneNumbers, f => f.Make(2, () => f.Phone.PhoneNumber()));

        var companyFaker = new Faker<Company>()
            .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
            .RuleFor(c => c.Employees, f => personFaker.Generate(f.Random.Int(10, 50)));

        var companies = companyFaker.Generate(numberOfCompanies);

        return companies;
    }
}