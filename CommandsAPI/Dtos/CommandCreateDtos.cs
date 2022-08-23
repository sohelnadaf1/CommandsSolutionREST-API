using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsAPI.Dtos
{
    public class CommandCreateDtos
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Plateform { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}
