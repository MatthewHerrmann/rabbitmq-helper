﻿using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Thycotic.Wcf
{
    /// <summary>
    /// Net/Tcp Channel factory
    /// </summary>
    public static class NetTcpChannelFactory
    {
        private static Binding GetBinding(bool useSsl, bool useEnvelopeAuth)
        {
            NetTcpBinding clientBinding;

            if (useSsl)
            {
                clientBinding = new NetTcpBinding(SecurityMode.Transport);
                clientBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
            }
            else
            {
                clientBinding = new NetTcpBinding(SecurityMode.None);
            }

            if (useEnvelopeAuth)
            {
                clientBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            }

            return clientBinding;
        }

        /// <summary>
        /// Creates a channel.
        /// </summary>
        /// <typeparam name="TServer">The type of the server.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="useSsl">if set to <c>true</c> [use SSL].</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static TServer CreateChannel<TServer>(string uri, bool useSsl,  string userName = "", string password ="")
        {
            var useEnvelopeAuth = !string.IsNullOrWhiteSpace(userName);
            
            var channelFactory = new ChannelFactory<TServer>(GetBinding(useSsl, useEnvelopeAuth), uri);

            if (useEnvelopeAuth && channelFactory.Credentials != null)
            {
                channelFactory.Credentials.UserName.UserName = userName;
                channelFactory.Credentials.UserName.Password = password;
            }

            return channelFactory.CreateChannel();
        }

        /// <summary>
        /// Creates a duplex channel.
        /// </summary>
        /// <typeparam name="TServer">The type of the server.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="useSsl">if set to <c>true</c> [use SSL].</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static TServer CreateDuplexChannel<TServer>(string uri, object callback, bool useSsl, string userName = "", string password ="")
        {
            var useEnvelopeAuth = !string.IsNullOrWhiteSpace(userName);

            var channelFactory = new DuplexChannelFactory<TServer>(callback, GetBinding(useSsl, useEnvelopeAuth), uri);

            if (useEnvelopeAuth && channelFactory.Credentials != null)
            {
                channelFactory.Credentials.UserName.UserName = userName;
                channelFactory.Credentials.UserName.Password = password;
            }


            //TODO: Do i need to worry about that since this is ephemeral? -dkk
            //channelFactory.Closed += new EventHandler(DuplexChannelFactory_Closed);
            //channelFactory.Closing += new EventHandler(DuplexChannelFactory_Closing);
            //channelFactory.Faulted += new EventHandler(DuplexChannelFactory_Faulted);

            return channelFactory.CreateChannel();
        }
    }
}
