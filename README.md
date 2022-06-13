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

