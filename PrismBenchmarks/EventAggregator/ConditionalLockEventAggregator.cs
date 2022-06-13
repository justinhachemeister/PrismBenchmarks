using Prism.Events;

namespace PrismBenchmarks.EventAggregator;

/// <summary>
///     An implementation of <see cref="IEventAggregator"/> that conditionally
///     acquires a lock when an update needs to be made.
/// </summary>
public class ConditionalLockEventAggregator : IEventAggregator
{
    /// <summary>
    ///     The collection of <see cref="EventBase"/> instances mapped by
    ///     <see cref="Type"/>.
    /// </summary>
    private readonly Dictionary<Type, EventBase> events = new Dictionary<Type, EventBase>();

    /// <summary>
    ///     The <see cref="SynchronizationContext"/> for the UI thread for UI
    ///     thread dispatching when constructed on the UI thread in a platform
    ///     agnostic way.
    /// </summary>
    private readonly SynchronizationContext? synchronizationContext = SynchronizationContext.Current;

    /// <inheritdoc/>
    public TEventType GetEvent<TEventType>()
        where TEventType : EventBase, new()
    {
        if (!events.TryGetValue(typeof(TEventType), out var eventInstance))
        {
            lock (events)
            {
                if (!events.TryGetValue(typeof(TEventType), out eventInstance))
                {
                    eventInstance = new TEventType()
                    {
                        SynchronizationContext = synchronizationContext,
                    };
                    events[typeof(TEventType)] = eventInstance;
                }
            }
        }

        return (TEventType)eventInstance;
    }
}
