using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Domain.Entities;
using SampleApp.Domain.Interfaces.Services;
using SampleApp.SampleApi.Controllers.Base;
using SampleApp.SampleApi.ViewModels;
using System;
using System.Net;

namespace SampleApp.SampleApi.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly ITodoService _todoService;

        public TodoController(ILogger<TodoController> logger, IMapper mapper, ITodoService todoService) : base(logger)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<TodoViewModel> Get(string id)
        {
            try
            {
                var todoViewModel = _mapper.Map<TodoViewModel>(_todoService.GetById(Guid.Parse(id)));
                return Ok(todoViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] TodoViewModel todoViewModel)
        {
            try
            {
                var todo = _mapper.Map<Todo>(todoViewModel);
                _todoService.Save(todo);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] TodoViewModel todoViewModel)
        {
            try
            {
                var todo = _mapper.Map<Todo>(todoViewModel);
                _todoService.Update(todo);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var todo = _todoService.GetById(Guid.Parse(id));
                _todoService.Delete(todo);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            return Ok();
        }
    }
}
