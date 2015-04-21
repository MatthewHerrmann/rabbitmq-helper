﻿using System;

namespace Thycotic.Messages.Common
{
    /// <summary>
    /// Interface for a blocking consumable
    /// </summary>
    public interface IBasicConsumable : IConsumable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IBasicConsumable"/> was redelivered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if redelivered; otherwise, <c>false</c>.
        /// </value>
        bool Redelivered { get; set; }

        /// <summary>
        /// Gets the expires on datetime in UTC.
        /// </summary>
        /// <value>
        /// The expires on.
        /// </value>
        DateTime? ExpiresOn { get;  }


        /// <summary>
        /// Gets a value indicating whether the consumable should be relayed even if it has expired.
        /// </summary>
        /// <value>
        ///   <c>true</c> if relay even if expired; otherwise, <c>false</c>.
        /// </value>
        bool RelayEvenIfExpired { get; }
    }
}