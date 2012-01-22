using System;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using Agathas.Storefront.Infrastructure.CrossCutting.Resources;

namespace Agathas.Storefront.Infrastructure.CrossCutting.Logging
{
    /// <summary>
    /// Trace helper for application's logging
    /// </summary>
    public sealed class TraceManager
        : ITraceManager
    {
        #region Members

        readonly TraceSource _source;

        #endregion

        #region  Constructor

        /// <summary>
        /// Create a new instance of this trace manager
        /// </summary>
        public TraceManager()
        {
            // Create default source
            _source = new TraceSource("Agathas Store");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Trace internal message in configured listeners
        /// </summary>
        /// <param name="eventType">Event type to trace</param>
        /// <param name="message">Message of event</param>
        void TraceInternal(TraceEventType eventType, string message)
        {
            if (_source != null)
            {
                try
                {
                    _source.TraceEvent(eventType, (int)eventType, message);
                }
                catch (SecurityException)
                {
                    //Cannot access to file listener or cannot have
                    //privileges to write in event log
                    //do not propagete this :-(
                }
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        /// <param name="operationName"><see cref="ITraceManager"/></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2135:SecurityRuleSetLevel2MethodsShouldNotBeProtectedWithLinkDemandsFxCopRule"),
        SecurityPermission(SecurityAction.LinkDemand)]
        public void TraceStartLogicalOperation(string operationName)
        {
            if (String.IsNullOrEmpty(operationName))
                throw new ArgumentNullException("operationName", Messages.exception_InvalidTraceMessage);

            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
            
            Trace.CorrelationManager.StartLogicalOperation(operationName);
        }
        
        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2135:SecurityRuleSetLevel2MethodsShouldNotBeProtectedWithLinkDemandsFxCopRule"),
        SecurityPermission(SecurityAction.LinkDemand)]
        public void TraceStopLogicalOperation()
        {
            try
            {
                Trace.CorrelationManager.StopLogicalOperation();
            }
            catch (InvalidOperationException)
            {
                //stack empty
            }
        }
        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        public void TraceStart()
        {
            TraceInternal(TraceEventType.Start, Messages.constant_START);
        }
        /// <summary>
        ///<see cref="ITraceManager"/>
        /// </summary>
        public void TraceStop()
        {

            TraceInternal(TraceEventType.Start, Messages.constant_STOP);

        }
        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        /// <param name="message"><see cref="ITraceManager"/></param>
        public void TraceInfo(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Information, message);

        }
        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        /// <param name="message"><see cref="ITraceManager"/></param>
        public void TraceWarning(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Warning, message);

        }
        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        /// <param name="message"><see cref="ITraceManager"/></param>
        public void TraceError(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Error, message);

        }
        /// <summary>
        /// <see cref="ITraceManager"/>
        /// </summary>
        /// <param name="message"><see cref="ITraceManager"/></param>
        public void TraceCritical(string message)
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentNullException("message", Messages.exception_InvalidTraceMessage);

            TraceInternal(TraceEventType.Critical, message);
        }

        #endregion

    }
}
