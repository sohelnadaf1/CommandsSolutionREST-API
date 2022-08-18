using CommandsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsAPI.Data
{
   public interface ICommandsRepo
    {
        bool SaveChanges();
        IEnumerable<Commands> GetAllData();
        Commands GetCommandById(int id);
        void InsertCommand(Commands cmd);
        void UpdateCommand(Commands cmd);
        void DeleteCommand(Commands cmd);

    }
}
