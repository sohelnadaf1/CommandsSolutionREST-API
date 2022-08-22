using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAPI.Data;
using CommandsAPI.Models;
using CommandsAPI.Dtos;
using AutoMapper;

namespace CommandsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandsRepo _repo;
        private readonly IMapper _mapper;
        public CommandsController(ICommandsRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDtos>> GetAllComands()
        {
            var data = _repo.GetAllData();
            return Ok(_mapper.Map<IEnumerable<CommandReadDtos>>(data));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDtos> GetCommandById(int id)
        {
            var data = _repo.GetCommandById(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDtos>(data));
        }

    }
}
