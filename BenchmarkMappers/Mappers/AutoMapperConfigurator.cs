using AutoMapper;
using BenchmarkMappers.Dto;
using BenchmarkMappers.Entities;

namespace BenchmarkMappers.Mappers
{
    public static class AutoMapperConfigurator
    {
        public static IMapper AutoMapper { get; private set; }

        public static void SetUp()
        {
            AutoMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<OrderDto, Order>();
                cfg.CreateMap<EmployeeDto, Employee>();
                cfg.CreateMap<OrderDetailDto, OrderDetail>();
                cfg.CreateMap<ShipperDto, Shipper>();
                cfg.CreateMap<ProductDto, Product>();
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<SupplierDto, Supplier>();
                cfg.CreateMap<CustomerDemographicDto, CustomerDemographic>();
                cfg.CreateMap<TerritoryDto, Territory>();
                cfg.CreateMap<RegionDto, Region>();

                cfg.CreateMap<CityDto, City>();
            }).CreateMapper();
        }
    }
}
