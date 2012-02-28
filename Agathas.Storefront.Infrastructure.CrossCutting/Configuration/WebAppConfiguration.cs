using System.Configuration;

namespace Agathas.Storefront.Infrastructure.CrossCutting.Configuration
{
    public class WebAppConfiguration : IApplicationConfiguration
    {
        #region Implementation of IApplicationConfiguration

        public string NumberOfResultsPerPage
        {
            get
            {
                return ConfigurationManager
                    .AppSettings["NumberOfResultsPerPage"];
            }
        }

        #endregion
    }
}
