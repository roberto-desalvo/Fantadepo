using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.WebApi.Business.Services;
using RDS.Fantadepo.WebApi.Business.Utilities.Extensions;
using RDS.Fantadepo.WebApi.DataAccess.Utilities;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class KeyVaultController : ControllerBase
    {
        [HttpGet("/entraid")]
        public async Task<IActionResult> GetEntraIdConnString()
        {
            try
            {
                var secret = AzureHelper.GetEntraIdConnectionString();
                return Ok(secret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/admin")]
        public async Task<IActionResult> GetAdminConnString()
        {
            try
            {
                var secret = AzureHelper.GetAdminConnectionString();
                return Ok(secret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/tutorial")]
        public async Task<IActionResult> GetConnString()
        {
            try
            {
                var secret = AzureHelper.GetSecretAsTutorial();
                return Ok(secret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
