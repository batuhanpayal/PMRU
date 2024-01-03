using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRU.Application.Features.Appointments.Queries.GetDoctors
{
    public class GetDoctorQueryRequest : IRequest<IList<GetDoctorQueryResponse>>
    {
    }
}
