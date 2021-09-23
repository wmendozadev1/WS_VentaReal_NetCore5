using System;
using System.Collections.Generic;

#nullable disable

namespace WS_VentaReal_NetCore5.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
    }
}
