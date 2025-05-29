using BlogCore.Models;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()

            });      
            }

        public void Update(Categoria categoria)
        {
            var  objeDesdeDb = _db.Categoria.FirstOrDefault(c => c.Id == categoria.Id);
            objeDesdeDb.Nombre = categoria.Nombre;
            objeDesdeDb.Orden = categoria.Orden;
         //   _db.SaveChanges();
        }
    }
    

}
