using IbadahLover.Application.DTOs.BlobFile;
using IbadahLover.Application.Features.BlobFiles.Requests.Commands;
using IbadahLover.Application.Features.BlobFiles.Requests.Queries;
using IbadahLover.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IbadahLover.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobFilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlobFilesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BlobFilesController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<BlobFileListDto>>> GetAll()
        {
            var blobFiles = await _mediator.Send(new GetBlobFileListRequest());
            return blobFiles;
        }

        // GET api/<BlobFilesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BlobFileDto>> GetById(int id)
        {
            var blobFile = await _mediator.Send(new GetBlobFileDetailsRequest { Id = id });
            return Ok(blobFile);
        }

        // POST api/<BlobFilesController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateBlobFileDto blobFile)
        {
            var command = new CreateBlobFileCommand { BlobFileDto = blobFile };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<BlobFilesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<BlobFilesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
