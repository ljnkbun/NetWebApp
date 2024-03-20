using Application.Commands.Users;
using Application.Parameters.Users;
using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;

namespace NetWebApp.Controllers
{
    public class UserController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserParameter filter)
        {
            return Ok(await Mediator.Send(new GetUsersQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                UpdatedDate = filter.UpdatedDate,
                CreatedBy = filter.CreatedBy,
                UpdatedBy = filter.UpdatedBy,
                UserName = filter.UserName,
                Name = filter.Name,
                Password = filter.Password,
                PhoneNum = filter.PhoneNum,
                Email = filter.Email,
                IsActive = filter.IsActive,
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUserQuery { Id = id }));
        }

        // POST api/v1/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/v1/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { Id = id }));
        }
    }
}
