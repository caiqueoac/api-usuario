﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_usuario.Models;


namespace api_usuario.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
