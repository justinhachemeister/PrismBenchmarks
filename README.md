# Prism Benchmarks

Benchmarks using [PrismLibrary](https://github.com/PrismLibrary/Prism).

> NOTE: Different frameworks and different hardware will probably give different results as explained in [good practices](https://benchmarkdotnet.org/articles/guides/good-practices.html#try-different-environments).
>
> > Results in different environments may vary significantly.

The results were run the following machine:

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1706 (21H1/May2021Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
```

## Configuration

The [`Program`](PrismBenchmarks/Program.cs) is setup to run the Benchmarks with the following Runtimes:

| Runtime   | Reason                |
|-----------|-----------------------|
| Net461    | Prism Target Runtime  |
| Net462    | Employer Used Runtime |
| Net47     | Prism Target Runtime  |
| Net472    | Prism Target Runtime  |
| Net48     | Employer Used Runtime |
| NetCore31 | Prism Target Runtime  |
| Net6      | Prism Target Runtime  |

## EventAggregator

Aggregates event instances that can be published and subscribed.

### GetEvent&lt;TEvent&gt;

Method definition for accessing event instances to publish and subscribe.

#### Implementation

Highlights relevant implementation details between benchmarks or the baseline.

##### ConditionalLocking

Because Prism's `EventAggregator` is `AppendOnly` the implementation can be 
optimized so lock acquisition is only done when the collection needs to be 
updated (known as [Double Check Locking by Jon Skeet](https://jonskeet.uk/csharp/singleton.html)).

#### Results

|          Method |              Runtime |     Mean |    Error |   StdDev | Ratio | RatioSD | Rank | Allocated |
|---------------- |--------------------- |---------:|---------:|---------:|------:|--------:|-----:|----------:|
|        Baseline | .NET Framework 4.6.1 | 49.89 ns | 0.984 ns | 0.920 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock | .NET Framework 4.6.1 | 30.40 ns | 0.664 ns | 0.738 ns |  0.61 |    0.02 |    1 |         - |
|                 |                      |          |          |          |       |         |      |           |
|        Baseline | .NET Framework 4.6.2 | 52.96 ns | 1.011 ns | 0.946 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock | .NET Framework 4.6.2 | 30.05 ns | 0.659 ns | 0.677 ns |  0.57 |    0.01 |    1 |         - |
|                 |                      |          |          |          |       |         |      |           |
|        Baseline |   .NET Framework 4.7 | 51.64 ns | 1.103 ns | 1.032 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock |   .NET Framework 4.7 | 30.24 ns | 0.666 ns | 0.889 ns |  0.59 |    0.02 |    1 |         - |
|                 |                      |          |          |          |       |         |      |           |
|        Baseline | .NET Framework 4.7.2 | 48.79 ns | 0.798 ns | 0.746 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock | .NET Framework 4.7.2 | 30.33 ns | 0.586 ns | 0.548 ns |  0.62 |    0.02 |    1 |         - |
|                 |                      |          |          |          |       |         |      |           |
|        Baseline |   .NET Framework 4.8 | 49.15 ns | 0.923 ns | 0.863 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock |   .NET Framework 4.8 | 30.61 ns | 0.662 ns | 0.762 ns |  0.62 |    0.02 |    1 |         - |
|                 |                      |          |          |          |       |         |      |           |
|        Baseline |             .NET 6.0 | 38.03 ns | 0.812 ns | 0.869 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock |             .NET 6.0 | 27.54 ns | 0.574 ns | 0.589 ns |  0.73 |    0.03 |    1 |         - |
|                 |                      |          |          |          |       |         |      |           |
|        Baseline |        .NET Core 3.1 | 40.09 ns | 0.850 ns | 1.420 ns |  1.00 |    0.00 |    2 |         - |
| ConditionalLock |        .NET Core 3.1 | 27.92 ns | 0.595 ns | 0.686 ns |  0.70 |    0.03 |    1 |         - |
