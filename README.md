[![](https://img.shields.io/nuget/v/Soenneker.Enums.ServiceBusQueue.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Enums.ServiceBusQueue/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.enums.servicebusqueue/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.enums.servicebusqueue/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Enums.ServiceBusQueue.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Enums.ServiceBusQueue/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.enums.servicebusqueue/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.enums.servicebusqueue/actions/workflows/codeql.yml)

# Soenneker.Enums.ServiceBusQueue

A SmartEnum base for defining an application's Azure Service Bus queue names in one strongly typed place.

## Install

```bash
dotnet add package Soenneker.Enums.ServiceBusQueue
```

## Define queues

```csharp
using Soenneker.Enums.ServiceBusQueue;

public sealed class AppQueue : ServiceBusQueue<AppQueue>
{
    public static readonly AppQueue Emails = new("emails", 1);
    public static readonly AppQueue Notifications = new("notifications", 2);

    private AppQueue(string name, int value) : base(name, value)
    {
    }
}
```

The self-referential generic argument is required: `AppQueue` derives from `ServiceBusQueue<AppQueue>`. This allows the underlying SmartEnum implementation to discover the concrete type's static values.

## Usage

```csharp
string queueName = AppQueue.Emails; // implicit conversion returns "emails"

AppQueue parsed = AppQueue.FromName("notifications");

foreach (AppQueue queue in AppQueue.List)
    Console.WriteLine($"{queue.Value}: {queue.Name}");
```

Use unique integer values. Lowercase plural names such as `emails` and `notifications` are the package convention because `Name` is intended to be passed as the Service Bus entity name; the base class does not enforce the convention or validate Azure naming rules.

`FromName` and `FromValue` throw when no match exists. Use `TryFromName` or `TryFromValue` when parsing configuration or external input. This package defines identifiers only; it does not create queues, send messages, receive messages, or verify that a configured queue exists.
