using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
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
    [ThreadingDiagnoser]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MarkdownExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class BenchmarkRunnerOnSampleList
    {
        [Params(1, 10, 100, 1000, 10000, 100000, 1000000)]
        public int CitysCount;

        private List<CityDto> _cityDtos;

        public BenchmarkRunnerOnSampleList()
        {
            AutoMapperConfigurator.SetUp();
            ExpressMapperConfigurator.SetUp();
            TinyMapperConfigurator.SetUp();
        }

        [GlobalSetup]
        public void Setup()
        {
            _cityDtos = DataProvider.GetAddresses(CitysCount);
        }

        [Benchmark(Baseline = true)]
        public List<City> MapWithManualMapping()
        {
            return _cityDtos.MapTo();
        }

        [Benchmark]
        public List<City> MapWithMapster()
        {
            return _cityDtos.Adapt<List<City>>();
        }

        [Benchmark]
        public List<City> MapWithAutoMapper()
        {
            return AutoMapperConfigurator.AutoMapper.Map<List<City>>(_cityDtos);
        }

        [Benchmark]
        public List<City> MapWithAgileMapper()
        {
            return AgileObjects.AgileMapper.Mapper.Map(_cityDtos).ToANew<List<City>>();
        }

        [Benchmark]
        public List<City> MapWithTinyMapper()
        {
            return TinyMapper.Map<List<City>>(_cityDtos);
        }

        [Benchmark]
        public List<City> MapWithExpressMapper()
        {
            return ExpressMapper.Mapper.Map<List<CityDto>, List<City>>(_cityDtos);
        }
    }
}