﻿using System;

namespace Thycotic.SecretServerEngine2.Web.Common.Request
{
    public class EngineConfigurationRequest
    {
        public string FriendlyName { get; set; }
        public Guid IdentityGuid { get; set; }
        public string PublicKey { get; set; }
        public double Version { get; set; }
        
    }
}