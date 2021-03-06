using System.Collections.Generic;
using System.Linq;
using BenchmarkMappers.Dto;
using BenchmarkMappers.Entities;

namespace BenchmarkMappers.Mappers
{
    public static class ManualMapperConfigurator
    {
        public static List<Customer> MapTo(this IEnumerable<CustomerDto> dto)
        {
            return dto.Select(MapTo).ToList();
        }

        public static Customer MapTo(this CustomerDto dto)
        {
            return new()
            {
                CustomerID = dto.CustomerID,
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Address = dto.Address,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                Phone = dto.Phone,
                Fax = dto.Fax,
                Orders = dto.Orders.Select(MapTo).ToList(),
                CustomerDemographics = dto.CustomerDemographics.Select(MapTo).ToArray()
            };
        }

        private static Order MapTo(this OrderDto dto)
        {
            return new()
            {
                OrderID = dto.OrderID,
                CustomerID = dto.CustomerID,
                EmployeeID = dto.EmployeeID,
                OrderDate = dto.OrderDate,
                RequiredDate = dto.RequiredDate,
                ShippedDate = dto.ShippedDate,
                ShipVia = dto.ShipVia,
                Freight = dto.Freight,
                ShipName = dto.ShipName,
                ShipAddress = dto.ShipAddress,
                ShipCity = dto.ShipCity,
                ShipRegion = dto.ShipRegion,
                ShipPostalCode = dto.ShipPostalCode,
                ShipCountry = dto.ShipCountry,
                Employee = MapTo(dto.Employee),
                OrderDetails = dto.OrderDetails.Select(MapTo).ToList(),
                Shipper = MapTo(dto.Shipper),
            };
        }

        private static OrderDetail MapTo(this OrderDetailDto dto)
        {
            return new()
            {
                OrderID = dto.OrderID,
                ProductID = dto.ProductID,
                UnitPrice = dto.UnitPrice,
                Quantity = dto.Quantity,
                Discount = dto.Discount,
                Product = MapTo(dto.Product)
            };
        }

        private static Product MapTo(this ProductDto dto)
        {
            return new()
            {
                ProductID = dto.ProductID,
                ProductName = dto.ProductName,
                SupplierID = dto.SupplierID,
                CategoryID = dto.CategoryID,
                QuantityPerUnit = dto.QuantityPerUnit,
                UnitPrice = dto.UnitPrice,
                UnitsInStock = dto.UnitsInStock,
                UnitsOnOrder = dto.UnitsOnOrder,
                ReorderLevel = dto.ReorderLevel,
                Discontinued = dto.Discontinued,
                Category = MapTo(dto.Category),
                Supplier = MapTo(dto.Supplier)
            };
        }

        private static Employee MapTo(this EmployeeDto dto)
        {
            return new()
            {
                EmployeeID = dto.EmployeeID,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Title = dto.Title,
                TitleOfCourtesy = dto.TitleOfCourtesy,
                BirthDate = dto.BirthDate,
                HireDate = dto.HireDate,
                Address = dto.Address,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                HomePhone = dto.HomePhone,
                Extension = dto.Extension,
                Photo = dto.Photo,
                Notes = dto.Notes,
                ReportsTo = dto.ReportsTo,
                PhotoPath = dto.PhotoPath,
                Territories = dto.Territories.Select(MapTo).ToArray()
            };
        }

        private static CustomerDemographic MapTo(this CustomerDemographicDto dto)
        {
            return new()
            {
                CustomerTypeID = dto.CustomerTypeID,
                CustomerDesc = dto.CustomerDesc
            };
        }

        private static Territory MapTo(this TerritoryDto dto)
        {
            return new()
            {
                TerritoryID = dto.TerritoryID,
                TerritoryDescription = dto.TerritoryDescription,
                RegionID = dto.RegionID,
                Region = MapTo(dto.Region)
            };
        }

        private static Region MapTo(this RegionDto dto)
        {
            return new()
            {
                RegionID = dto.RegionID,
                RegionDescription = dto.RegionDescription
            };
        }

        private static Shipper MapTo(this ShipperDto dto)
        {
            return new()
            {
                ShipperID = dto.ShipperID,
                CompanyName = dto.CompanyName,
                Phone = dto.Phone
            };
        }

        private static Category MapTo(this CategoryDto dto)
        {
            return new()
            {
                CategoryID = dto.CategoryID,
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                Picture = dto.Picture.ToArray()
            };
        }

        private static Supplier MapTo(this SupplierDto dto)
        {
            return new()
            {
                SupplierID = dto.SupplierID,
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Address = dto.Address,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                Phone = dto.Phone,
                Fax = dto.Fax,
                HomePage = dto.HomePage,
            };
        }

        public static List<City> MapTo(this IEnumerable<CityDto> dto)
        {
            return dto.Select(MapTo).ToList();
        }

        public static City MapTo(this CityDto dto)
        {
            return new()
            {
                CityID = dto.CityID,
                Name = dto.Name,
                Region = dto.Region,
                Country = dto.Country
            };
        }
    }
}
