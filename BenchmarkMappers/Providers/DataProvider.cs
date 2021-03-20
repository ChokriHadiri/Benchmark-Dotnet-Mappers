using System.Collections.Generic;
using System.Linq;
using BenchmarkMappers.Dto;
using Tynamix.ObjectFiller;

namespace BenchmarkMappers.Providers
{
    public static class DataProvider
    {
        public static List<CustomerDto> GetData(int customersCount)
        {
            Filler<CustomerDto> filler = new Filler<CustomerDto>();
            filler.Setup();
            return filler.Create(customersCount).ToList();
        }
    }
}
