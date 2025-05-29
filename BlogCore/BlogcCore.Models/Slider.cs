using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para el Slider")]
        [Display(Name = "Nombre del Slider")]
        public string Nombre { get; set; }

        [Required]

        public bool Estado { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Nombre Slider")]
        public string UrlImagen { get; set; }


    }
}
