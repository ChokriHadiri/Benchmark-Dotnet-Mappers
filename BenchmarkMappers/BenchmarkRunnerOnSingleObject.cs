using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkMappers.Dto;
using BenchmarkMappers.Entities;
using BenchmarkMappers.Mappers;
using BenchmarkMappers.Providers;
using Mapster;
using Nelibur.ObjectMapper;

namespace BenchmarkMappers
{
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    [ThreadingDiagnoser]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MarkdownExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class BenchmarkRunnerOnSingleObject
    {
        private CustomerDto _customerDto;
     
        public BenchmarkRunnerOnSingleObject()
        {
            AutoMapperConfigurator.SetUp();
            ExpressMapperConfigurator.SetUp();
            TinyMapperConfigurator.SetUp();
        }

        [GlobalSetup]
        public void Setup()
        {
            _customerDto = DataProvider.GetData(1)[0];
        }

        [Benchmark(Baseline = true)]
        public Customer MapWithManualMapping()
        {
            return _customerDto.MapTo();
        }

        [Benchmark]
        public Customer MapWithMapster()
        {
            return _customerDto.Adapt<Customer>();
        }

        [Benchmark]
        public Customer MapWithAutoMapper()
        {
            return AutoMapperConfigurator.AutoMapper.Map<Customer>(_customerDto);
        }

        [Benchmark]
        public Customer MapWithAgileMapper()
        {
            return AgileObjects.AgileMapper.Mapper.Map(_customerDto).ToANew<Customer>();
        }

        [Benchmark]
        public Customer MapWithTinyMapper()
        {
            return TinyMapper.Map<Customer>(_customerDto);
        }

        [Benchmark]
        public Customer MapWithExpressMapper()
        {
            return ExpressMapper.Mapper.Map<CustomerDto, Customer>(_customerDto);
        }
    }
}