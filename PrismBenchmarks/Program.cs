using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace PrismBenchmarks;

/// <summary>
///     The application entry point.
/// </summary>
internal static class Program
{
    /// <summary>
    ///     Application entry point.
    /// </summary>
    /// <param name="arguments">
    ///     Start up arguments provided to the application.
    /// </param>
    private static void Main(string[] arguments)
#pragma warning disable HAA0101 // This call site is calling into a function with a `params` parameter. This results in an array allocation.
        => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
            .Run(
                arguments,
                DefaultConfig.Instance
                    .AddColumn(RankColumn.Arabic, StatisticColumn.Mean)
                    .AddDiagnoser(MemoryDiagnoser.Default)
                    .AddExporter(MarkdownExporter.Default)
                    .AddLogger(ConsoleLogger.Default)
                    .AddJob(
#pragma warning disable SA1114 // Parameter list should follow declaration.
#pragma warning disable SA1115 // The parameter should begin on the line after the previous parameter.

                        // Employer Used Runtimes
                        Job.Default.WithRuntime(ClrRuntime.Net462),
                        Job.Default.WithRuntime(ClrRuntime.Net48),

                        // Prism Target Frameworks
                        Job.Default.WithRuntime(ClrRuntime.Net461),
                        Job.Default.WithRuntime(ClrRuntime.Net47),
                        Job.Default.WithRuntime(ClrRuntime.Net472),
                        Job.Default.WithRuntime(CoreRuntime.Core31),
                        Job.Default.WithRuntime(CoreRuntime.Core60)));

#pragma warning restore SA1114 // Parameter list should follow declaration.
#pragma warning restore SA1115 // The parameter should begin on the line after the previous parameter.
#pragma warning restore HAA0101 // This call site is calling into a function with a `params` parameter. This results in an array allocation.
}
