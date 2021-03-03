// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityModel.Client
{
    /// <summary>
    /// Request for OIDC premiuminfo
    /// </summary>
    public class PremiumInfoRequest : ProtocolRequest
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the data for request content.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public object Data { get; set; }
    }
}