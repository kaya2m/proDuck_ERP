using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proDuck.Application.Features.Commands.Machine.DeleteMachine
{
    public class DeleteMachineCommandHandler : IRequestHandler<DeleteMachineCommandRequest, DeleteMachineCommandResponse>
    {
        public Task<DeleteMachineCommandResponse> Handle(DeleteMachineCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
