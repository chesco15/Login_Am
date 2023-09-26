using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_AM.Models
{
    public class Registro_Model
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string PApellido { get; set; }
        [Required]
        public string SApellido { get; set; }

        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
