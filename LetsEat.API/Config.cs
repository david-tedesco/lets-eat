using Duende.IdentityServer.Models;

namespace LetsEat.API
{
    public static class ConfigProd
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
            new ApiScope("WAPI")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
            new Client
            {
                ClientId = "FCLI.Web",
                ClientName = "Flutter web client",

                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                RedirectUris = { "https://letseat.co/signin-oidc" },
                FrontChannelLogoutUri = "https://letseat.co/signout-oidc",
                PostLogoutRedirectUris = { "https://letseat.co/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "WAPI" }
            },
            new Client
            {
                ClientId = "FCLI.Android",
                ClientName = "Flutter Android client",

                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                RedirectUris = { "com.letseat://signin-oidc" },
                FrontChannelLogoutUri = "com.letseat://signout-oidc",
                PostLogoutRedirectUris = { "com.letseat://signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "WAPI" }
            },
            new Client
            {
                ClientId = "FCLI.iOS",
                ClientName = "Flutter iOS client",

                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                RedirectUris = { "com.letseat://signin-oidc" },
                FrontChannelLogoutUri = "com.letseat://signout-oidc",
                PostLogoutRedirectUris = { "com.letseat://signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "WAPI" }
            },

            };
    }
}