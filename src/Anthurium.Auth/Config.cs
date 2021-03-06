﻿using IdentityServer4.Models;
using System.Collections.Generic;

namespace Anthurium.Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            {
                new ApiResource("anthurium-api")
            };
        
        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientId = "anthurium-web",                 
                    ClientSecrets =
                    {
                        new Secret("thisismyclientspecificsecret".Sha256())
                    },
                    AllowedScopes = { "anthurium-api" },
                }
            };
        
    }
}