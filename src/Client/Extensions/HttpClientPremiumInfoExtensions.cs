// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Internal;

namespace IdentityModel.Client
{
    /// <summary>
    /// HttpClient extensions for OIDC premiuminfo
    /// </summary>
    public static class HttpClientPremiumInfoExtensions
    {
        /// <summary>
        /// Sends a premiuminfo request.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<PremiumInfoResponse> PostPremiumInfoAsync(this HttpMessageInvoker client, PremiumInfoRequest request, CancellationToken cancellationToken = default)
        {
            if (request.Token.IsMissing()) throw new ArgumentNullException(nameof(request.Token));

            var clone = request.Clone();

            clone.Method = HttpMethod.Post;
            clone.SetBearerToken(request.Token);
            clone.Content = new StringContent(JsonSerializer.Serialize(request.Data), Encoding.UTF8, "application/json");
            
            clone.Prepare();

            HttpResponseMessage response;
            try
            {
                response = await client.SendAsync(clone, cancellationToken).ConfigureAwait();
            }
            catch (Exception ex)
            {
                return ProtocolResponse.FromException<PremiumInfoResponse>(ex);
            }

            return await ProtocolResponse.FromHttpResponseAsync<PremiumInfoResponse>(response).ConfigureAwait();
        }
    }
}