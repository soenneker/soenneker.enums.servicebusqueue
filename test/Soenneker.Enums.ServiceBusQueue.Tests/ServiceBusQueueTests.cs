using Soenneker.Tests.HostedUnit;
using System.Linq;
using System.Threading.Tasks;

namespace Soenneker.Enums.ServiceBusQueue.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ServiceBusQueueTests : HostedUnitTest
{
    public ServiceBusQueueTests(Host host) : base(host)
    {
    }

    [Test]
    public async Task Derived_values_participate_in_lookup()
    {
        TestQueue emails = TestQueue.Emails;

        await Assert.That(emails.Name).IsEqualTo("emails");
        await Assert.That(TestQueue.List.Any(value => value.Name == "emails")).IsTrue();
        await Assert.That(TestQueue.FromName("emails")).IsEqualTo(TestQueue.Emails);
    }

    private sealed class TestQueue : ServiceBusQueue<TestQueue>
    {
        public static readonly TestQueue Emails = new("emails", 1);

        private TestQueue(string name, int value) : base(name, value)
        {
        }
    }
}
