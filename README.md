# Benchmark Mappers (.Net 5.0)

#### Code Quality Vs Performance

When we read/write data, we need to move our information from one layer to the next. We need to map one or several columns to a new set of columns. As our application grows, we get more and more of these objects. So it become boring, time-consuming process and harder to maintain.

The use of automated object mappers tools like (***Mapster, AutoMapper, ...***) can help us preserve the best practice of clean code, non-complex code, and organized code.

This benefit comes with a cost. Improving code quality while maintaining a good performance/RAM memory allocation is probably one of the hardest parts of developing software, but it's what makes our product valuable.

In our case, we are going to use **benchmarks** to compare the performance of manual mapping versus the performance of using object mappers. Based on those benchmarks, we can make the appropriate decision.


## Mappers

For our comparison, we have selected the most used object-to-object mapper libraries on NuGet:

- [Mapster](https://github.com/MapsterMapper/Mapster) ![](https://img.shields.io/nuget/v/Mapster.svg) : a fast, fun and stimulating object to object Mapper.

- [AutoMapper](https://github.com/AutoMapper/AutoMapper) ![](http://img.shields.io/nuget/v/AutoMapper.svg) : a simple little library built to solve a deceptively complex problem - getting rid of code that mapped one object to another.

- [AgileMapper](https://github.com/agileobjects/AgileMapper) ![](https://badge.fury.io/nu/AgileObjects.AgileMapper.svg) : a zero-configuration, highly-configurable, unopinionated object mapper with viewable execution plans.

- [ExpressMapper](https://github.com/fluentsprings/ExpressMapper) : a lightweight and easy to use .Net mapper to map one type of object(s) to another.

- [TinyMapper](https://github.com/TinyMapper/TinyMapper) ![](https://img.shields.io/nuget/v/tinymapper.svg) : a quick object-object mapper for .NET

## Configuration
To map an object to another one, you should first initialize mapping configuration for each object.

**Mapster** and **AgileMapper** don't need any configuration.

For **AutoMapper**,
Create a MapperConfiguration instance and initialize configuration via the constructor:
```cs
var config = new MapperConfiguration(cfg =>
{
	cfg.CreateMap<CustomerDto, Customer>();
	cfg.CreateMap<OrderDto, Order>();
}).CreateMapper();
```
For **ExpressMapper**,
Mappings should be registered so you can map objects in your code wherever you want either as many times as you want.
```cs
ExpressMapper.Mapper.Register<CustomerDto, Customer>();
ExpressMapper.Mapper.Register<OrderDto, Order>();
```
For **TinyMapper**,
```cs
TinyMapper.Bind<CustomerDto, Customer>();
TinyMapper.Bind<OrderDto, Order>();
```

## Benchmark
A benchmark is simply a measurement or set of measurements relating to the execution of some code.
To run [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) in your .NET application, you must first install the Benchmark.NET library:
```
Install-Package BenchmarkDotNet
```

When benchmarking, always remember to run in **Release** mode. That means measuring without a debugger attached. Release mode ensures the code is optimized, which can make a big different in performance for specific scenarios. The C# compiler does a few optimizations in release mode that are not available in debug mode.

At the **Visual Studio command prompt**, specify the following command :
```
dotnet run -p BenchmarkMappers.csproj -c Release
```

After that, we can check out the markdown results.

## Results
All use cases are going to be tested with 1, 10, 100, 1.000,  10000, 1000000 records and we have used [ObjectFiller](http://objectfiller.net/) to fill our records with random data.

For **Sample object** (CityDto)
![](https://raw.githubusercontent.com/ChokriHadiri/Benchmark-Dotnet-Mappers/master/BenchmarkSampleResults.PNG)

For **Complex object** (CustomerDto)
![](https://raw.githubusercontent.com/ChokriHadiri/Benchmark-Dotnet-Mappers/master/BenchmarkResults.PNG)



## Points to Note
Let’s take a close look at these benchmark results.

**Mapster** 🥇 is the fastest  and the performance and RAM memory spent difference is minimum.

**Manual Mapping** is next. Efficient on both speed and memory.

**Automapper** is indeed consistently slower compared to others.


## License
The code is released under the [MIT License](https://opensource.org/licenses/MIT "MIT License").