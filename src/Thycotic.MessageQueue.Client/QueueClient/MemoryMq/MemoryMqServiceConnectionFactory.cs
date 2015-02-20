﻿using System;
using System.ServiceModel;
using Thycotic.Logging;
using Thycotic.MemoryMq;

namespace Thycotic.MessageQueue.Client.QueueClient.MemoryMq
{
    internal class MemoryMqServiceConnectionFactory
    {
        public string Uri
        {
            get { return _uri.AbsoluteUri; }
            set { _uri = new Uri(value); }
        }

        public int RequestedHeartbeat { get; set; }

        public object HostName
        {
            get { return _uri.Host; }
        }

        public bool UseSsl { get; set; }

        private Uri _uri;

        private readonly ILogWriter _log = Log.Get(typeof(MemoryMqServiceConnectionFactory));

        public IMemoryMqServiceConnection CreateConnection()
        {
            NetTcpBinding clientBinding;

            if (UseSsl)
            {
                clientBinding = new NetTcpBinding(SecurityMode.Transport);
                clientBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            }
            else
            {
                clientBinding = new NetTcpBinding(SecurityMode.None);
            }

            var callback = new MemoryMqServiceCallback();

            var channelFactory = new DuplexChannelFactory<IMemoryMqServer>(callback, clientBinding, Uri);
            //TODO: Do i need to worry about that since this is ephemeral? -dkk
            //channelFactory.Closed += new EventHandler(DuplexChannelFactory_Closed);
            //channelFactory.Closing += new EventHandler(DuplexChannelFactory_Closing);
            //channelFactory.Faulted += new EventHandler(DuplexChannelFactory_Faulted);

            try
            {
                var channel = channelFactory.CreateChannel();

                return new MemoryMqServiceConnection(channel, callback);
            }
            catch (Exception ex)
            {
                _log.Error(string.Format("Connection failed to open because {0} ", ex.Message), ex);

                throw;
            }
        }
    }
}