﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMRU.Application.Features.Auth.Command.Login;
using PMRU.Application.Features.Auth.Command.RefreshToken;
using PMRU.Application.Features.Auth.Command.Register;
using PMRU.Application.Features.Auth.Command.Revoke;
using PMRU.Application.Features.Auth.Command.RevokeAll;
using PMRU.Application.Features.Auth.Queries.GetRoles;
using PMRU.Application.Features.Availabilities.Queries.GetAvailabilities;

namespace PMRU.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<GetRolesQueryResponseDto>>> GetRoles()
        {
            var response = await mediator.Send(new GetRolesQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPost]
        public async Task<ActionResult<LoginCommandResponseDto>> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<ActionResult<RefreshTokenCommandResponseDto>> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<ActionResult> Revoke(RevokeCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<ActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
