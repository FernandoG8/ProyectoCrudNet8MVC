using System.Diagnostics;
using DropDownsMVC.Datos;
using DropDownsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DropDownsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext contexto)
        {
            _logger = logger;
            _context = contexto;
        }

        public IActionResult Index()
        {
            var sucursales = _context.Sucursales.ToList();
            var viewModel = new DropDownsVM
            {
                Sucursales = sucursales
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult ObtenerCategorias(int sucursalId)
        {
            var categorias = _context.Categorias
                .Where(c => c.SucursalId == sucursalId)
                .ToList();
            return Json(categorias);
        }

        [HttpGet]
        public JsonResult ObtenerProductos(int categoriaId)
        {
            var productos = _context.Productos
                .Where(c => c.CategoriaId == categoriaId)
                .ToList();
            return Json(productos);
        }
    }

}
