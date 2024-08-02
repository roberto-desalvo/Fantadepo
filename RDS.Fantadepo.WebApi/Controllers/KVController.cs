using Microsoft.AspNetCore.Mvc;
using RDS.Fantadepo.WebApi.Business.Services;
using RDS.Fantadepo.WebApi.Business.Utilities.Extensions;
using RDS.Fantadepo.WebApi.DataAccess.Utilities;

namespace RDS.Fantadepo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KVController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetEntraIdConnString()
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

        [HttpGet]
        public async Task<ActionResult<string>> GetAdminConnString()
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
    }
}
