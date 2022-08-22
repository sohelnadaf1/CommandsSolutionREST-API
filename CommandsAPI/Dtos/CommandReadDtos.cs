using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsAPI.Dtos
{
    public class CommandReadDtos
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        //public string Plateform { get; set; }
        public string CommandLine { get; set; }
    }
}
