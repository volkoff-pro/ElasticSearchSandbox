using Elastic.App;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Elastic.Tests.Integration
{
    public class HostInfrastructureTests
    {
        private readonly Mock<IOptions<ElasticOptions>> _elasticOptionsMock;

        public HostInfrastructureTests()
        {
            _elasticOptionsMock = new Mock<IOptions<ElasticOptions>>();
            _elasticOptionsMock.Setup(ap => ap.Value).Returns(new ElasticOptions
            {
                ConnectionString = "http://localhost:9200",
                IndexName = "Contacts"
            });
        }

        [Fact]
        public void Host_ElasticOptions_ShouldBeInjected()
        {
        }
    }
}