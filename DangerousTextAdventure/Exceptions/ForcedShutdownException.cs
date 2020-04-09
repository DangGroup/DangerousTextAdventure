using System;
using System.Runtime.Serialization;

//Exception Namespace.
namespace DangerousTextAdventure.Exceptions
{
    /// <summary>
    /// Exception that forces the application exit and contains relevant information for shutdown.
    /// </summary>
    [Serializable]
    internal class ForcedShutdownException : Exception
    {
        #region Fields
        /// <summary>
        /// Code that should be returned to Windows on exit.
        /// </summary>
        private int _exitCode;

        /// <summary>
        /// Flag, true if the error needs to be logged.
        /// </summary>
        private bool _log;
        #endregion

        #region Constructor
        /// <summary>
        /// Sets base constructor private.
        /// </summary>
        private ForcedShutdownException()
            : base()
        {

        }

        /// <summary>
        /// Sets base constructor private.
        /// </summary>
        private ForcedShutdownException(string pMessage)
            : base(pMessage)
        {

        }

        /// <summary>
        /// Sets base constructor private.
        /// </summary>
        private ForcedShutdownException(string pMessage, Exception pInnerException)
            : base(pMessage, pInnerException)
        {

        }
        /// <summary>
        /// Constructor for serialization, using base serialization constructor.
        /// </summary>
        protected ForcedShutdownException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        {

        }

        /// <summary>
        /// Creates an instance containing all relevant information for a forced application shutdown.
        /// </summary>
        /// <param name="pReasonException">Error that forces the shutdown.</param>
        /// <param name="pExitCode">Code that needsto be returned to Windows.</param>
        /// <param name="pLogError">Flag, (per default) true if the error meeds to be logged.</param>
        public ForcedShutdownException(Exception pReasonException, int pExitCode, bool pLogError = true)
            : base("Game shutdown forced.", pReasonException)
        {
            //Setting information.
            this.ExitCode = pExitCode;
            this.LogError = pLogError;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Code that should be returned to Windows on exit.
        /// </summary>
        internal int ExitCode
        {
            //Getter
            get
            {
                return this._exitCode;
            }
            //Setter
            private set
            {
                this._exitCode = value;
            }
        }

        /// <summary>
        /// Flag, true if the error needs to be logged.
        /// </summary>
        internal bool LogError
        {
            //Getter
            get
            {
                return this._log;
            }
            //Setter
            private set
            {
                this._log = value;
            }
        }
        #endregion
    }
}
