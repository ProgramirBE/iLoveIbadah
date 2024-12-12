using IbadahLover.Application.DTOs.UserSalahOverview;
using IbadahLover.Application.Features.UserSalahOverviews.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSalahOverviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserSalahOverviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserSalahOverviewsController>
        [HttpGet]
        public async Task<ActionResult<List<UserSalahOverviewListDto>>> GetAll()
        {
            var userSalahOverviews = await _mediator.Send(new GetUserSalahOverviewListRequest());
            return userSalahOverviews;
        }

        // GET api/<UserSalahOverviewsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSalahOverviewDto>> GetById(int id)
        {
            var userSalahOverview = await _mediator.Send(new GetUserSalahOverviewDetailsRequest { Id = id });
            return Ok(userSalahOverview);
        }

        // POST api/<UserSalahOverviewsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserSalahOverviewsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserSalahOverviewsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
