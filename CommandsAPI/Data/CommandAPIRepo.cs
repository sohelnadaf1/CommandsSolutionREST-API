using CommandsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsAPI.Data
{
    public class CommandAPIRepo : ICommandsRepo
    {
        public void DeleteCommand(Commands cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commands> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Commands GetCommandById(int id)
        {
            throw new NotImplementedException();
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
