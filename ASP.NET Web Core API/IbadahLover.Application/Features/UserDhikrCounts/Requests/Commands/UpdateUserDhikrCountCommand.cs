using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.Features.UserDhikrCounts.Requests.Commands
{
    public class UpdateUserDhikrCountCommand : IRequest<Unit>
    {
        public UpdateUserDhikrCountDto UserDhikrCountDto { get; set; }
    }
}
