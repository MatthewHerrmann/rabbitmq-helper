﻿using System;
using System.Diagnostics.Contracts;

namespace Thycotic.Messages.Common
{
    /// <summary>
    /// Interface for a consumer that accepts a request
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    [ContractClass(typeof(BasicConsumerContract<>))]
    public interface IBasicConsumer<in TRequest> : IConsumer 
        where TRequest : class 
    {
        /// <summary>
        /// Consumes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        void Consume(TRequest request);
    }

    /// <summary>
    /// Contract 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    [ContractClassFor(typeof(IBasicConsumer<>))]
    public abstract class BasicConsumerContract<TRequest> : IBasicConsumer<TRequest>
        where TRequest : class 
    {
        /// <summary>
        /// Consumes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Consume(TRequest request)
        {
            Contract.Requires<ArgumentNullException>(request != null);
        }
    }
}