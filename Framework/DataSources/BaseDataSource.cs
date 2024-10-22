using Microsoft.Extensions.Configuration;
using System.Collections;

namespace Framework.DataSources
{
    public class BaseDataSource<T> : IEnumerable
    {
        protected virtual string BaseFile => "data";

        protected virtual string BaseSection => "base";

        private IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile(BaseFile + ".json", optional: true)
              .Build();
        }

        public IEnumerator GetEnumerator()
        {
            var genericItems = GetConfiguration().GetSection(BaseSection).Get<List<T>>();

            foreach (var item in genericItems)
            {
                yield return item;
            }
        }
    }
}
