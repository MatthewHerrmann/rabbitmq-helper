﻿using System;

namespace Thycotic.MessageQueue.Client.QueueClient
{
    /// <summary>
    /// Default configuration values for the system
    /// </summary>
    public class DefaultConfigValues
    {
        /// <summary>
        /// Alias for the exchange
        /// </summary>
        [Obsolete("use configurable value", true)]
        public const string Exchange = "thycotic";

        /// <summary>
        /// Alias for the exchange type
        /// </summary>
        public const string ExchangeType = "topic";

        /// <summary>
        /// Alias for the re-open delay
        /// </summary>
        public static readonly TimeSpan ReOpenDelay = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Alias for the confirmation timeout
        /// </summary>
        public static readonly TimeSpan ConfirmationTimeout = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Model/Connection specific defaults
        /// </summary>
        public class Model
        {
            /// <summary>
            /// Alias for the retry attempts
            /// </summary>
            public const int RetryAttempts = 7;

            /// <summary>
            /// Alias for the retry delay in milliseconds
            /// </summary>
            public static readonly TimeSpan RetryDelay = TimeSpan.FromMilliseconds(100);

            /// <summary>
            /// Alias for the retry delay growth factor
            /// </summary>
            public const int RetryDelayGrowthFactor = 2;

            /// <summary>
            /// BasicPublish specific defaults
            /// </summary>
            public class Publish
            {
                /// <summary>
                /// Alias for "not mandatory"
                /// </summary>
                public const bool NotMandatory = false;

                /// <summary>
                /// Alias for "mandatory"
                /// </summary>
                public const bool Mandatory = true;

                //public const bool DeliverImmediatelyAndRequireAListener = true;//deprecated in AMQP

                /// <summary>
                /// Alias for "do not deliver immediately or require a listener"
                /// </summary>
                public const bool DoNotDeliverImmediatelyOrRequireAListener = false;
                
            }
        }
    }
}
