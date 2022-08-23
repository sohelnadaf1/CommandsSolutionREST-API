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
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDtos> GetCommandById(int id)
        {
            var data = _repo.GetCommandById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDtos>(data));
        }


        // creating new resource 
        [HttpPost]
        public ActionResult<CommandReadDtos> CreateResource([FromBody] CommandCreateDtos commandCreateDtos)
        {
            var data = _mapper.Map<Commands>(commandCreateDtos);
            _repo.InsertCommand(data);
            _repo.SaveChanges();

            var DataReturn = _mapper.Map<CommandReadDtos>(data);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = DataReturn.Id }, DataReturn);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateResource(int id, [FromBody] CommandUpdateDtos commandUpdateDtos)
        {
            // check data is present or not with provided id
            var CheckData = _repo.GetCommandById(id);

            if (CheckData == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDtos, CheckData);
            _repo.UpdateCommand(CheckData);
            _repo.SaveChanges();

            return NoContent();

        }

        // patch endpoing
        [HttpPatch("{id}")]
        public ActionResult PatchResource(int id,JsonPatchDocument<CommandUpdateDtos> patchDoc)
        {
            var commandModelFromrepo = _repo.GetCommandById(id);
            if(commandModelFromrepo == null)
            {
                return NotFound();
            }

            var CommandToPatch = _mapper.Map<CommandUpdateDtos>(commandModelFromrepo);
            patchDoc.ApplyTo(CommandToPatch, ModelState);

            if(!TryValidateModel(CommandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(CommandToPatch,commandModelFromrepo);
            _repo.UpdateCommand(commandModelFromrepo);
            _repo.SaveChanges();

            return NoContent();

        }

        // delete the resource endpoint
        [HttpDelete("{id}")]
        public ActionResult RemoveResource(int id)
        {
            var GetModelData = _repo.GetCommandById(id);
            if(GetModelData == null)
            {
                return NotFound();
            }

            _repo.DeleteCommand(GetModelData);

            return NoContent();
        }





        //end class
    }

    
    
}
