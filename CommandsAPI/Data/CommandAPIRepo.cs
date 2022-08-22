using CommandsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsAPI.Data
{
    public class CommandAPIRepo : ICommandsRepo
    {
        private readonly CommndContext _context;

        public CommandAPIRepo(CommndContext context)
        {
            _context = context;
        }
        public void DeleteCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commands> GetAllData()
        {
           return  _context.Commands.ToList();

        }

        public Commands GetCommandById(int id)
        {
            var data = _context.Commands.FirstOrDefault(check => check.Id == id);
            return data;
        }

        public void InsertCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }
    }
}
