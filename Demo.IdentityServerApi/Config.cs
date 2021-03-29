using IdentityServer4.Models;
using System.Collections.Generic;

namespace Demo.IdentityServerApi
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("client_scope1")
            };

        public static IEnumerable<ApiResource> ApiResources =>
         new ApiResource[]
         {
             new ApiResource("api1", "api1")
             {
                 Scopes = { "client_scope1" }
             }
         };


        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "credentials_client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedScopes = { "client_scope1" }
            }
        };

    }
}
