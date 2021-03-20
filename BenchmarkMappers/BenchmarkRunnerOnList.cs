using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkMappers.Dto;
using BenchmarkMappers.Entities;
using BenchmarkMappers.Mappers;
using BenchmarkMappers.Providers;
using Mapster;
using Nelibur.ObjectMapper;

// ReSharper disable once MemberCanBePrivate.Global
// ReSharper disable once UnassignedField.Global
namespace BenchmarkMappers
{
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    [ThreadingDiagnoser]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MarkdownExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class BenchmarkRunnerOnList
    {
        [Params(1, 10, 100, 1000, 5000)]
        public int CustomersCount;

        private List<CustomerDto> _customerDtos;

        public BenchmarkRunnerOnList()
        {
            AutoMapperConfigurator.SetUp();
            ExpressMapperConfigurator.SetUp();
            TinyMapperConfigurator.SetUp();
        }

        [GlobalSetup]
        public void Setup()
        {
            _customerDtos = DataProvider.GetData(CustomersCount);
        }

        [Benchmark(Baseline = true)]
        public List<Customer> MapWithManualMapping()
        {
            return _customerDtos.MapTo();
        }

        [Benchmark]
        public List<Customer> MapWithMapster()
        {
            return _customerDtos.Adapt<List<Customer>>();
        }

        [Benchmark]
        public List<Customer> MapWithAutoMapper()
        {
            return AutoMapperConfigurator.AutoMapper.Map<List<Customer>>(_customerDtos);
        }

        [Benchmark]
        public List<Customer> MapWithAgileMapper()
        {
            return AgileObjects.AgileMapper.Mapper.Map(_customerDtos).ToANew<List<Customer>>();
        }

        [Benchmark]
        public List<Customer> MapWithTinyMapper()
        {
            return TinyMapper.Map<List<Customer>>(_customerDtos);
        }

        [Benchmark]
        public List<Customer> MapWithExpressMapper()
        {
            return ExpressMapper.Mapper.Map<List<CustomerDto>, List<Customer>>(_customerDtos);
        }
    }
}