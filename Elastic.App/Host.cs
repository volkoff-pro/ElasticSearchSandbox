using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Elastic.App
{
    public class Host
    {
        private readonly ElasticOptions _elasticOptions;

        public Host(IOptions<ElasticOptions> options)
        {
            _elasticOptions = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task Run()
        {
            
        }
    }
}