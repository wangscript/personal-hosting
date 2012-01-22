using Agathas.Storefront.Infrastructure.CrossCutting.IoC.Unity;

namespace Agathas.Storefront.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    /// IoCFactory  implementation 
    /// </summary>
    public sealed class IoCFactory
    {
        #region Singleton

        static readonly IoCFactory _instance = new IoCFactory();

        /// <summary>
        /// Get singleton instance of IoCFactory
        /// </summary>
        public static IoCFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region Members

        IContainer _CurrentContainer;

        /// <summary>
        /// Get current configured IContainer
        /// <remarks>
        /// At this moment only IoCUnityContainer existss
        /// </remarks>
        /// </summary>
        public IContainer CurrentContainer
        {
            get
            {
                return _CurrentContainer;
            }
        }

        #endregion

        #region Constructor

        IoCFactory()
        {
            _CurrentContainer = new IoCUnityContainer();
        }

        #endregion
    }
}
