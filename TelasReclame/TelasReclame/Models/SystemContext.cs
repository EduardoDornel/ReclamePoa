﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasReclame
{
    public class SystemContext : DbContext
    {
        public DbSet<Models.Usuario> Usuarios { get; set; }
    }
}
