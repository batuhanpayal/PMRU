﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRU.Application.Features.Employees.Queries.GetEmployeesById
{
    public class GetEmployeeByRegistrationNumberQueryRequest : IRequest<GetEmployeeByRegistrationNumberQueryResponse>
    {
        public GetEmployeeByRegistrationNumberQueryRequest(string registrationNumber) 
        {
            RegistrationNumber = registrationNumber;
        }

        public string RegistrationNumber { get; set; }
    }
}