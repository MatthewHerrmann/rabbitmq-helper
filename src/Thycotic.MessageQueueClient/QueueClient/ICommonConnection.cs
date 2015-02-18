﻿using System;

namespace Thycotic.MessageQueue.Client.QueueClient
{
    /// <summary>
    /// Interface for a Memory Mq connection
    /// </summary>
    public interface ICommonConnection : IDisposable
    {

        /// <summary>
        /// Forces the initialization.
        /// </summary>
        bool ForceInitialize();

        /// <summary>
        /// Opens the channel.
        /// </summary>
        /// <param name="retryAttempts">The retry attempts.</param>
        /// <param name="retryDelayMs">The retry delay ms.</param>
        /// <param name="retryDelayGrowthFactor">The retry delay growth factor.</param>
        /// <returns></returns>
        ICommonModel OpenChannel(int retryAttempts, int retryDelayMs, float retryDelayGrowthFactor);

        /// <summary>
        /// Gets or sets the connection created.
        /// </summary>
        /// <value>
        /// The connection created.
        /// </value>
        EventHandler ConnectionCreated { get; set; }

    }
}