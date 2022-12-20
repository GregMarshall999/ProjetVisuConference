using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisioConference.Main.Models;

namespace VisioConference.Main.Data
{
    public class VisioConferenceMainContext : DbContext
    {
        public VisioConferenceMainContext (DbContextOptions<VisioConferenceMainContext> options)
            : base(options)
        {
        }

        public DbSet<VisioConference.Main.Models.Movie> Movie { get; set; } = default!;
    }
}
