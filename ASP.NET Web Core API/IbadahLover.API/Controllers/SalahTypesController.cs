using IbadahLover.Application.DTOs.SalahType;
using IbadahLover.Application.Features.SalahTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalahTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SalahTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SalahTypesController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<SalahTypeListDto>>> GetAll()
        {
            var salahTypes = await _mediator.Send(new GetSalahTypeListRequest());
            return salahTypes;
        }

        // GET api/<SalahTypesController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<SalahTypeDto>> Get(int id)
        {
            var salahType = await _mediator.Send(new GetSalahTypeDetailsRequest { Id = id });
            return Ok(salahType);
        }

        // POST api/<SalahTypesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<SalahTypesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<SalahTypesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
