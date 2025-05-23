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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Categoria categoria)
        {
            var  objeDesdeDb = _db.Categoria.FirstOrDefault(c => c.Id == categoria.Id);
            objeDesdeDb.Nombre = categoria.Nombre;
            objeDesdeDb.Orden = categoria.Orden;
            _db.SaveChanges();
        }
    }
    

}
