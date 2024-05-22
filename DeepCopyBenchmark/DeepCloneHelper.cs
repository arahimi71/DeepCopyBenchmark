using AutoMapper;
using Force.DeepCloner;
using MessagePack;
using MessagePack.Resolvers;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DeepCopyBenchmark;

internal class DeepCloneHelper
{
    public static List<Company> CloneBySystemTextJson(List<Company> companies)
    {
        var json = JsonSerializer.Serialize(companies);

        var clonedCompanies = JsonSerializer.Deserialize<List<Company>>(json);

        //VerifyClone.VerifyDeepClone(companies,clonedCompanies);

        return clonedCompanies;
    }

    public static List<Company> CloneByDeepCloner(List<Company> companies)
    {
        var clonedCompanies = companies.DeepClone();

        //VerifyClone.VerifyDeepClone(companies,clonedCompanies);

        return clonedCompanies;
    }

    public static List<Company> CloneByAutomapper(List<Company> companies, IMapper mapper)
    {
        var clonedCompanies = mapper.Map<List<Company>>(companies);

        //VerifyClone.VerifyDeepClone(companies,clonedCompanies);

        return clonedCompanies;
    }

    public static List<Company> CloneByNewtonsoft(List<Company> companies)
    {
        var clonedCompanies = JsonConvert.DeserializeObject<List<Company>>(JsonConvert.SerializeObject(companies));

        //VerifyClone.VerifyDeepClone(companies,clonedCompanies);

        return clonedCompanies;
    }

    public static List<Company> CloneByMessagePack(List<Company> companies)
    {
        var serializedCompanies = MessagePackSerializer.Serialize(companies, ContractlessStandardResolver.Options);
        
        var clonedCompanies =MessagePackSerializer.Deserialize<List<Company>>(serializedCompanies, ContractlessStandardResolver.Options);

        //VerifyClone.VerifyDeepClone(companies,clonedCompanies);

        return clonedCompanies;
    }
}