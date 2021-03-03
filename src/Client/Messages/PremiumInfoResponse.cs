// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityModel.Client
{
    /// <summary>
    /// Models an OpenID Connect premiuminfo response
    /// </summary>
    /// <seealso cref="IdentityModel.Client.ProtocolResponse" />
    public class PremiumInfoResponse : ProtocolResponse
    {
        /// <summary>
        /// Allows to initialize instance specific data.
        /// </summary>
        /// <param name="initializationData">The initialization data.</param>
        /// <returns></returns>
        protected override Task InitializeAsync(object initializationData = null)
        {
            if (!IsError)
            {
                Claims = Json.ToClaims();
            }
            else
            {
                Claims = Enumerable.Empty<Claim>();
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        public IEnumerable<Claim> Claims { get; private set; }
        
        /// <summary>
        /// Gets the error description.
        /// </summary>
        /// <value>
        /// The error description.
        /// </value>
        public string ErrorDescription => TryGet(OidcConstants.TokenResponse.ErrorDescription);
    }
}