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
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;
        public SliderRepository(ApplicationDbContext db) : base(db)
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

        public void Update(Slider slider)
        {
            var  objeDesdeDb = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            objeDesdeDb.Nombre = slider.Nombre;
            objeDesdeDb.Estado = slider.Estado;
            objeDesdeDb.UrlImagen = slider.UrlImagen;
            //   _db.SaveChanges();
        }
    }
    

}
