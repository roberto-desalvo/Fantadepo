using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.MAUI.Utils
{
    public static class StartupHelper
    {
        public static string GetKeyVaultConnectionString()
        {
            try
            {
                var kvUri = new Uri("https://fantadepo-kv.vault.azure.net/");
                var credentials = new DefaultAzureCredential();
                var secretClient = new SecretClient(kvUri, credentials);

                var secret = secretClient.GetSecret("fantadepo-admin-connstring");
                return secret.Value?.ToString() ?? string.Empty;
            }
            catch(Exception ex) 
            { 
                return string.Empty;
            }            
        }
    }
}
