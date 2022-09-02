using Api.Common;
using Api.ViewModels;
using Infrastructure.CommandQueries.Queries;
using Infrastructure.Models;
using MassTransit;
using Messsaging.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : MediatorControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public UsersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserVm user)
        {
            await _publishEndpoint.Publish<UserCreated>(new { Name = user.Name });
            return Ok();
        }
    }
}
