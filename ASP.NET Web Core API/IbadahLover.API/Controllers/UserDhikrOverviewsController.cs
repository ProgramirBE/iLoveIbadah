using IbadahLover.Application.DTOs.UserDhikrOverview;
using IbadahLover.Application.Features.UserDhikrOverviews.Requests.Queries;
using IbadahLover.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDhikrOverviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserDhikrOverviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserDhikrOverviewsController>
        [HttpGet]
        public async Task<ActionResult<List<UserDhikrOverviewListDto>>> GetAll()
        {
            var userDhikrOverviews = await _mediator.Send(new GetUserDhikrOverviewListRequest());
            return userDhikrOverviews;
        }

        // GET api/<UserDhikrOverviewsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDhikrOverviewDto>> GetById(int id)
        {
            var userDhikrOverview = await _mediator.Send(new GetUserDhikrOverviewDetailsRequest { Id = id });
            return Ok(userDhikrOverview);
        }

        // POST api/<UserDhikrOverviewsController>
        [HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserDhikrOverviewsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserDhikrOverviewsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
