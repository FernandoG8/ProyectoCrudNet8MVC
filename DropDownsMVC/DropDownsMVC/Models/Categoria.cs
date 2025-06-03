namespace DropDownsMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //Foreign key to sucursal
        public int SucursalId { get; set; }

        //propiedad de navegación
        public Sucursal Sucursal { get; set; }
    }
}
