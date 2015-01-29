﻿using System;
using Thycotic.Messages.Common;

namespace Thycotic.MessageQueueClient.MemoryMq
{
    /// <summary>
    /// Memory message queue that is volatile and non-persistent
    /// </summary>
    public class MemoryMqRequestBus :  IRequestBus
    {

        /// <summary>
        /// Publishes the specified request as remote procedure call. The client will hold until the call succeeds or cails
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="timeoutSeconds">The timeout seconds.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TResponse BlockingPublish<TResponse>(IConsumable request, int timeoutSeconds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publishes the specified request as a fire-and-forget
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="persistent">Ignored.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void BasicPublish(IConsumable request, bool persistent = true)
        {
        
        }
    }
}
