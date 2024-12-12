using IbadahLover.Application.DTOs.DhikrType;
using IbadahLover.Application.Features.DhikrTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DhikrTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DhikrTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DhikrTypesController>
        [HttpGet]
        public async Task<ActionResult<List<DhikrTypeListDto>>> Get()
        {
            var dhikrTypes = await _mediator.Send(new GetDhikrTypeListRequest());
            return dhikrTypes;
        }

        // GET api/<DhikrTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DhikrTypeDto>> Get(int id) //Get or GetById??? check if issue! todo! error! debug! fix! test! review! verify! validate! confirm! check! inspect! examine! audit! revise! study! investigate! analyze! assess! evaluate! scrutinize! probe!
        {
            var dhikrType = await _mediator.Send(new GetDhikrTypeDetailsRequest { Id = id });
            return Ok(dhikrType);
        }

        // POST api/<DhikrTypesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

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
