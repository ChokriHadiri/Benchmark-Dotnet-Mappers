using BenchmarkMappers.Dto;
using BenchmarkMappers.Entities;

namespace BenchmarkMappers.Mappers
{
    public static class ExpressMapperConfigurator
    {
        public static void SetUp()
        {
            ExpressMapper.Mapper.Register<CustomerDto, Customer>();
            ExpressMapper.Mapper.Register<OrderDto, Order>();
            ExpressMapper.Mapper.Register<EmployeeDto, Employee>();
            ExpressMapper.Mapper.Register<OrderDetailDto, OrderDetail>();
            ExpressMapper.Mapper.Register<ShipperDto, Shipper>();
            ExpressMapper.Mapper.Register<ProductDto, Product>();
            ExpressMapper.Mapper.Register<CategoryDto, Category>();
            ExpressMapper.Mapper.Register<SupplierDto, Supplier>();
            ExpressMapper.Mapper.Register<CustomerDemographicDto, CustomerDemographic>();
            ExpressMapper.Mapper.Register<TerritoryDto, Territory>();
            ExpressMapper.Mapper.Register<RegionDto, Region>();
        }
    }
}
