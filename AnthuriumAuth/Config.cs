// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace AnthuriumAuth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };
        public static IEnumerable<ApiResource> Apis =>
        new ApiResource[]
        {
            new ApiResource("anthurium-api")
        };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientId = "anthurium-web",
                    ClientSecrets =
                    {
                        new Secret("anthuriumlightsails".Sha256())
                    },
                    AllowedScopes = { "anthurium-api" }
                }

            };
    }
}