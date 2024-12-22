using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Enums.ServiceBusQueue.Tests;

[Collection("Collection")]
public class ServiceBusQueueTests : FixturedUnitTest
{
    public ServiceBusQueueTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
