using Microsoft.EntityFrameworkCore;
using OoptiRH.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.DBAcess.Implementations
{
    public class OoptiRHContext : DbContext
    {
        public OoptiRHContext(DbContextOptions<OoptiRHContext> options)
           : base(options)
        { }

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ColloboratorJobHistory> colloboratorJobHistories { get; set; }
        public DbSet<Adresse> Adresses { get; set; }

    }
}
