using BackEndPruebaTecnicsLaureate.Business;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPruebaTecnicsLaureate.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BeneficiariesController : Controller
    {
        [HttpGet("GetBeneficiariesByIdEmployee")]
        [EnableCors("AllowSpecificOrigin")]
        public async ValueTask<ActionResult<VMBeneficiaries>> GetBeneficiaries(string id)
        {
            BBeneficiaries response = new();
            var listBeneficiaries = await response.GetBeneficiaries(id);
            if (!listBeneficiaries.code)
            {
                return BadRequest(listBeneficiaries);
            }
            return Ok(listBeneficiaries);
        }

        [HttpPost("PostBeneficiary")]
        [EnableCors("AllowSpecificOrigin")]
        public async ValueTask<ActionResult<VMGeneric>> PostBeneficiary([FromBody] RQBeneficiary beneficiary)
        {
            BBeneficiaries response = new();
            var addBeneficiary = await response.PostBeneficiary(beneficiary);
            if (!addBeneficiary.code)
            {
                return BadRequest(addBeneficiary);
            }
            return Ok(addBeneficiary);
        }

        [HttpPut("PutBeneficiary")]
        [EnableCors("AllowSpecificOrigin")]
        public async ValueTask<ActionResult<VMGeneric>> PutBeneficiary(string id, [FromBody] UPBeneficiary beneficiary)
        {
            BBeneficiaries response = new();
            var addBeneficiary = await response.PutBeneficiary(id, beneficiary);
            if (!addBeneficiary.code)
            {
                return BadRequest(addBeneficiary);
            }
            return Ok(addBeneficiary);
        }

        [HttpGet("GetBeneficiariesById")]
        [EnableCors("AllowSpecificOrigin")]
        public async ValueTask<ActionResult<VMBeneficiaries>> GetBeneficiaryById(string id)
        {
            BBeneficiaries response = new();
            var listBeneficiaries = await response.GetBeneficiaryById(id);
            if (!listBeneficiaries.code)
            {
                return BadRequest(listBeneficiaries);
            }
            return Ok(listBeneficiaries);
        }
    }
}
