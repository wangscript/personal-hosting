using System.Configuration;

namespace Agathas.Storefront.Infrastructure.CrossCutting.Configuration
{
    public class WebAppConfiguration : IApplicationConfiguration
    {
        private const int DefaultNumberPerPage = 10;

        #region Implementation of IApplicationConfiguration

        public int NumberOfResultsPerPage
        {
            get
            {
                int numberPerPage = 0;
                string sourceValue = ConfigurationManager
                    .AppSettings["NumberOfResultsPerPage"];

                if (string.IsNullOrEmpty(sourceValue) && !int.TryParse(sourceValue, out numberPerPage))
                    return DefaultNumberPerPage;

                return numberPerPage;
            }
        }

        #endregion
    }
}
