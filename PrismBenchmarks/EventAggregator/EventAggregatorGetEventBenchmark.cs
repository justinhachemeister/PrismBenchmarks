using BenchmarkDotNet.Attributes;
using Prism.Events;

namespace PrismBenchmarks.EventAggregator;

/// <summary>
///     <see cref="IEventAggregator.GetEvent{TEventType}"/> Benchmark(s).
/// </summary>
public class EventAggregatorGetEventBenchmark
{
    /// <summary>
    ///     The Prism <see cref="EventAggregator"/> instance used to establish a baseline.
    /// </summary>
    private readonly IEventAggregator baselineEventAggregator = new Prism.Events.EventAggregator();

    /// <summary>
    ///     The <see cref="ConditionalLockEventAggregator"/> instance to compare against.
    /// </summary>
    private readonly IEventAggregator conditionalLockEventAggregator = new ConditionalLockEventAggregator();

    /// <summary>
    ///     The Baseline Benchmark to compare against.
    /// </summary>
    /// <returns>
    ///     Returns the <see cref="IEventAggregator.GetEvent{TEventType}"/> to
    ///     prevent JIT optimization eliminating "dead" code.
    /// </returns>
    [Benchmark(Baseline = true)]
    public EventBase Baseline()
        => baselineEventAggregator.GetEvent<CloseSplashScreenEvent>();

    /// <summary>
    ///     The Benchmark using <see cref="conditionalLockEventAggregator"/> to
    ///     compare against the <see cref="Baseline"/>.
    /// </summary>
    /// <returns>
    ///     Returns the <see cref="IEventAggregator.GetEvent{TEventType}"/> to
    ///     prevent JIT optimization eliminating "dead" code.
    /// </returns>
    [Benchmark]
    public EventBase ConditionalLock()
        => conditionalLockEventAggregator.GetEvent<CloseSplashScreenEvent>();
}
