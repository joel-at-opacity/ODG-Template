using System;
using System.IO;
using EFProviderWrapperToolkit;
using EFTracingProvider;
using ODG.Core;
using ODG.Core4;
using WebsiteModel;

namespace ODG.Core.Data.Abstract
{
    /// <summary>
    /// Extends the default entity framework context to allow for logging.
    /// Uses microsoft EFProviderWrappers
    /// http://code.msdn.microsoft.com/EFProviderWrappers
    /// </summary>
    public partial class ApplicationDataContext : DataContext
    {

        public ApplicationDataContext()
            : this("name=DataContext")
        {

            this.CommandExecuting += (sender, e) =>
            {
                Logger.LogInfo("Command is executing: {0}", e.ToTraceString());
            };

            this.CommandFinished += (sender, e) =>
            {
                // Logger.LogInfo("Command has finished: {0}", e.ToTraceString());
            };

        }

        public ApplicationDataContext(string connectionString)
            : base(EntityConnectionWrapperUtils.CreateEntityConnectionWithWrappers(
                    connectionString,
                    "EFTracingProvider"
            ))
        {
        }

        #region Tracing Extensions

        private EFTracingConnection TracingConnection
        {
            get { return this.UnwrapConnection<EFTracingConnection>(); }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandExecuting
        {

            add { this.TracingConnection.CommandExecuting += value; }
            remove { this.TracingConnection.CommandExecuting -= value; }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandFinished
        {
            add { this.TracingConnection.CommandFinished += value; }
            remove { this.TracingConnection.CommandFinished -= value; }
        }

        public event EventHandler<CommandExecutionEventArgs> CommandFailed
        {
            add { this.TracingConnection.CommandFailed += value; }
            remove { this.TracingConnection.CommandFailed -= value; }
        }



        #endregion


    }

}
