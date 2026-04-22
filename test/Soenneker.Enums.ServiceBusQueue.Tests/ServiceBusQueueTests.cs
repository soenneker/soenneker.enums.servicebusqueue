using Soenneker.Tests.HostedUnit;

namespace Soenneker.Enums.ServiceBusQueue.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ServiceBusQueueTests : HostedUnitTest
{
    public ServiceBusQueueTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
