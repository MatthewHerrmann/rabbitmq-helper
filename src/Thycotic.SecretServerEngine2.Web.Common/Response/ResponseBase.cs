﻿namespace Thycotic.SecretServerEngine2.Web.Common.Response
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}