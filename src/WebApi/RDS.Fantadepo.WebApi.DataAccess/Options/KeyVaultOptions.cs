using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS.Fantadepo.WebApi.DataAccess.Options
{
    public class KeyVaultOptions
    {
        [Required]
        public string? Address { get; set; }

        [Required]
        public SecretsOptions? Secrets { get; set; }

        public class SecretsOptions
        {
            public string? ConnectionStringAdmin { get; set; }
            public string? ConnectionStringEntraId { get; set; }
        }
    }
}
