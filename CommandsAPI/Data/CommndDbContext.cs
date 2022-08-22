using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommandsAPI.Models;

namespace CommandsAPI.Data
{
    // While you can think of the DbContext class as a representation of the
    //Database, you could think of a DbSet as a representation of a table in the
    //Database.That is, we are telling our DbContext class that we want to “model”
    //our Commands in the Database(so we can persistently store them as a table).

    public class CommndContext:DbContext
    {
        public CommndContext(DbContextOptions<CommndContext> options):base (options)
        {

        }

        public DbSet<Commands> Commands { get; set; }
    }
}
