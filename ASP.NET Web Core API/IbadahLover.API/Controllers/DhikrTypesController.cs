using IbadahLover.Application.Constants;
using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.Features.DhikrTypes.Requests.Commands;
using IbadahLover.Application.Features.DhikrTypes.Requests.Queries;
using IbadahLover.Application.Responses;
using IbadahLover.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DhikrTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DhikrTypesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<DhikrTypesController>
        [HttpGet]
        [EndpointSummary("Get all Dhikr Types created by useraccountid 1 (admin)")]
        [EndpointDescription("Get A List of all the Dhikr Types created by useraccountid 1 (admin)")]
        [AllowAnonymous]
        public async Task<ActionResult<List<DhikrTypeListDto>>> GetAll()
        {
            var dhikrTypes = await _mediator.Send(new GetDhikrTypeByUserAccountListRequest { CreatedBy = 1 });
            return Ok(dhikrTypes);
        }

        [HttpGet("getallbyuseraccount")]
        [Authorize]
        public async Task<ActionResult<List<DhikrTypeByUserAccountListDto>>> GetAllByUserAccount([FromQuery] int userAccountId)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            var dhikrTypes = await _mediator.Send(new GetDhikrTypeByUserAccountListRequest
            {
                CreatedBy = int.Parse(userIdClaim)
            });
            return Ok(dhikrTypes);
        }


        // GET api/<DhikrTypesController>/5
        [HttpGet("{id}")]
        [EndpointSummary("Get Dhikr Type by Id")]
        [EndpointDescription("Get All Details of specific Dhikr Type")]
        [AllowAnonymous]
        public async Task<ActionResult<DhikrTypeDto>> Get(int id) //Get or GetById??? check if issue! todo! error! debug! fix! test! review! verify! validate! confirm! check! inspect! examine! audit! revise! study! investigate! analyze! assess! evaluate! scrutinize! probe!
        {
            var dhikrType = await _mediator.Send(new GetDhikrTypeDetailsRequest { Id = id });
            return Ok(dhikrType);
        }

        //POST api/<DhikrTypesController>
        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateDhikrTypeDto dhikrType)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(CustomClaimTypes.Id.ToString())?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            dhikrType.CreatedBy = int.Parse(userIdClaim);
            var command = new CreateDhikrTypeCommand { DhikrTypeDto = dhikrType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DhikrTypesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DhikrTypesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
