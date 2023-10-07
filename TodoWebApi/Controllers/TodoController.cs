namespace Todo.WebApi.Controllers
{
    using Application.DTOs;
    using Infrastructure.Commands;
    using Infrastructure.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]

    public class TodoController : Controller
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(int id)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDto>> GetAll()
        {
            return await _mediator.Send(new GetAllTasksQuery());
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> Create(CreateTaskCommand command)
        {
            var task = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            if (taskItem == null)
            {
                return NotFound("No se encontró la tarea");
            }

            return Ok(command.Task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _mediator.Send(new DeleteTaskCommand(id));
            return !deleted ? NotFound("No se encontró la tarea") : Ok();
        }
    }
}

