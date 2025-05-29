using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                // Guardar en la base de datos
                _contenedorTrabajo.Categoria.Update(categoria);

                _contenedorTrabajo.Save();
                TempData["success"] = "Categoria creada correctamente";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                // Guardar en la base de datos
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                TempData["success"] = "Categoria creada correctamente";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if(categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        //region llamadas a la  API
        #region
        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _contenedorTrabajo.Categoria.GetAll()});
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDB = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDB == null)
            {
                return Json(new { success = false, message = "Error al eliminar la categoria" });
            }
            _contenedorTrabajo.Categoria.Remove(objFromDB);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoria eliminada correctamente" });
        }
        #endregion
    }
}
