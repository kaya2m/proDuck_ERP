using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Machine.CreateMachine
{
    public class CreateMachineCommandHandler : IRequestHandler<CreateMachineCommandRequest, CreateMachineCommandResponse>
    {
        public Task<CreateMachineCommandResponse> Handle(CreateMachineCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
