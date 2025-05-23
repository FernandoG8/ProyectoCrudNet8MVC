using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models
{
    public class Contacto
    {
        [Key]//  no es necesario, pero es una buena practica porque se infiere que es un "key" por el Id
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Celular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email{ get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;




    }
}
