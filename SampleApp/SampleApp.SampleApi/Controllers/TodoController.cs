using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Domain.Entities;
using SampleApp.Domain.Interfaces.Services;
using SampleApp.SampleApi.Controllers.Base;
using SampleApp.SampleApi.ViewModels;
using System;
using System.Threading.Tasks;

namespace SampleApp.SampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var todoViewModel = _mapper.Map<TodoViewModel>(_todoService.GetById(Guid.Parse(id)));
            return Ok(todoViewModel);

        }
    }
}
