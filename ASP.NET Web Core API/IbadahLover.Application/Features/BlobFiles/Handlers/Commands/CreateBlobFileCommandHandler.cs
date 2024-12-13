using AutoMapper;
using IbadahLover.Application.Contracts.Infrastructure;
using IbadahLover.Application.Contracts.Persistence;
using IbadahLover.Application.DTOs.BlobFile.Validators;
using IbadahLover.Application.Features.BlobFiles.Requests.Commands;
using IbadahLover.Application.Models;
using IbadahLover.Application.Responses;
using IbadahLover.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.BlobFiles.Handlers.Commands
{
    public class CreateBlobFileCommandHandler : IRequestHandler<CreateBlobFileCommand, BaseCommandResponse>
    {
        private readonly IBlobFileRepository _blobFileRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public CreateBlobFileCommandHandler(IBlobFileRepository blobFileRepository, IUserAccountRepository userAccountRepository,IMapper mapper)
        {
            _blobFileRepository = blobFileRepository;
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBlobFileCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBlobFileDtoValidator(_userAccountRepository);
            var validationResult = await validator.ValidateAsync(request.BlobFileDto);

            //var validationResult = await validator.ValidateAsync(new CreateUserAccountDto
            //{
            //    // Copy properties from UserAccountDto to CreateUserAccountDto
            //    Property1 = request.UserAccountDto.Property1,
            //    Property2 = request.UserAccountDto.Property2,
            //    // Add more properties as needed
            //});

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                //throw new ValidationException(validationResult);
            }

            var blobFile = _mapper.Map<BlobFile>(request.BlobFileDto);
            blobFile = await _blobFileRepository.Create(blobFile);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = blobFile.Id;

            return response;
        }
    }
}
