using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandsAPI.Dtos;
using CommandsAPI.Models;

namespace CommandsAPI.AutoMapper_Profiles

{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            CreateMap<Commands, CommandReadDtos>();
            CreateMap<Commands, CommandCreateDtos>().ReverseMap();
            CreateMap<CommandUpdateDtos, Commands>().ReverseMap();
               
        }
    }
}
