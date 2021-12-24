using System;
using System.Collections.Generic;

#nullable disable

namespace Agenda.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
    }
}
