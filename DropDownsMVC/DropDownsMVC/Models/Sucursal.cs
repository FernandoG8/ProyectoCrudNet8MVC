namespace DropDownsMVC.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}
