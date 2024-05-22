using AutoMapper;
using BenchmarkDotNet.Attributes;

namespace DeepCopyBenchmark;

[MemoryDiagnoser]
[HtmlExporter]
public class CloningBenchmarks
{
    private List<Company> _companies;
    private IMapper _mapper;

    [Params(5000)]
    public int NumberOfCompanies { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _companies = DataGenerator.GenerateCompanyData(NumberOfCompanies);

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Address, Address>();
            cfg.CreateMap<Person, Person>().ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            cfg.CreateMap<Company, Company>()
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
        });

        _mapper = config.CreateMapper();
    }

    [Benchmark(Baseline = true)]
    public List<Company> CloneByNewtonsoft()
    {
        return DeepCloneHelper.CloneByNewtonsoft(_companies);
    }

    [Benchmark]
    public List<Company> CloneByAutomapper()
    {
        return DeepCloneHelper.CloneByAutomapper(_companies, _mapper);
    }

    [Benchmark]
    public List<Company> CloneByDeepCloner()
    {
        return DeepCloneHelper.CloneByDeepCloner(_companies);
    }

    [Benchmark]
    public List<Company> CloneBySystemTextJson()
    {
        return DeepCloneHelper.CloneBySystemTextJson(_companies);
    }

    [Benchmark]
    public List<Company> CloneByMessagePack()
    {
        return DeepCloneHelper.CloneByMessagePack(_companies);
    }
}