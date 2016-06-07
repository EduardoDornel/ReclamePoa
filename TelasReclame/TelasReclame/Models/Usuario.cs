﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelasReclame.Models
{
    public class Usuario
    {   
        
        // Propriedades     
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }

        public string Senha { get; set; }
        public string Bairro { get; set; }

    }
}
