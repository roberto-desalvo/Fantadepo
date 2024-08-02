using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.DataAccess.Utilities
{
    public class AzureHelper
    {
        public static string GetAdminConnectionString()
        {
            return GetKeyVaultSecret("https://fantadepo-kv.vault.azure.net/", "fantadepo-admin-connstring");
        }

        public static string GetEntraIdConnectionString()
        {
            return GetKeyVaultSecret("https://fantadepo-kv.vault.azure.net/", "fantadepo-entraid-connstring");
        }

        private static string GetKeyVaultSecret(string uriAddress, string secretName)
        {
            try
            {
                var options = new SecretClientOptions()
                {
                    Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
                };

                var kvUri = new Uri(uriAddress);
                var credentials = new DefaultAzureCredential();
                var secretClient = new SecretClient(kvUri, credentials, options);

                var secret = secretClient.GetSecret(secretName);
                return secret?.Value?.Value ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
