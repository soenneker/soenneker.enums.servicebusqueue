using Soenneker.SmartEnum.Named;

namespace Soenneker.Enums.ServiceBusQueue;

/// <summary>
/// An abstract enum type for using in Azure Service Bus messages <para/>
/// Obviously this is meant to be derived. Values should be plural, and lowercase.
/// </summary>
public abstract class ServiceBusQueue : NamedSmartEnum<ServiceBusQueue>
{
    protected ServiceBusQueue(string name, int value) : base(name, value)
    {
    }
}