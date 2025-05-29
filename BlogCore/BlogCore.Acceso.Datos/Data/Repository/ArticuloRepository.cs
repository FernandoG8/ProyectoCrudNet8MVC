using BlogCore.Models;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticuloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Articulo articulo)
        {
            var  objeDesdeDb = _db.Articulo.FirstOrDefault(c => c.Id == articulo.Id);
            objeDesdeDb.Nombre = articulo.Nombre;
            objeDesdeDb.Descripcion = articulo.Descripcion;
            objeDesdeDb.UrlImagen = articulo.UrlImagen;
            objeDesdeDb.CategoriaId = articulo.CategoriaId;
            
            //_db.SaveChanges();
        }
    }
    

}
