using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para el artículo")]
        [Display(Name = "Nombre del Artículo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripcion del Artículo")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de Creación")]
        public string FechaCreacion{ get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen del Artículo")]
        public string UrlImagen { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

    }
}
