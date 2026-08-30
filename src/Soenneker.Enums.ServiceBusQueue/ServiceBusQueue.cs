using Soenneker.SmartEnum.Named;

namespace Soenneker.Enums.ServiceBusQueue;

/// <summary>
/// Base class for application-defined Azure Service Bus queue names.
/// </summary>
/// <typeparam name="TQueue">The concrete queue type.</typeparam>
public abstract class ServiceBusQueue<TQueue> : NamedSmartEnum<TQueue> where TQueue : ServiceBusQueue<TQueue>
{
    protected ServiceBusQueue(string name, int value) : base(name, value)
    {
    }
}
