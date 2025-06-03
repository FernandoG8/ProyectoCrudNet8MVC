using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net.WebSockets;

namespace BlogCore.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public HomeController(IContenedorTrabajo contenedorTrabajo, ILogger<HomeController> logger)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _logger = logger;

        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    HomeVM homeVM = new HomeVM()
        //    {
        //        Sliders = _contenedorTrabajo.Slider.GetAll(),
        //        ListArticulos = _contenedorTrabajo.Articulo.GetAll()
        //    };
        //    ViewBag.IsHome = true; // Para indicar que estamos en la pagina de inicio
        //    return View(homeVM);
        //}
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 6)
        {
            var articulos = _contenedorTrabajo.Articulo.AsQueryable();
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);
            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
                ListArticulos = paginatedEntries.ToList(),
                PageIndex=page,
                TotalPages = (int)Math.Ceiling(articulos.Count() / (double)pageSize)
            };
            ViewBag.IsHome = true; // Para indicar que estamos en la pagina de inicio
            return View(homeVM);
        }
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var articulo = _contenedorTrabajo.Articulo.Get(id);
            return View(articulo);
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

        //Para buscador
        [HttpGet]
        public IActionResult ResultadoBusqueda(string searchString, int page = 1, int pageSize = 6)
        {
            var articulos = _contenedorTrabajo.Articulo.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                articulos = articulos.Where(e => e.Nombre.Contains(searchString));
            }
            //Paginar los resultadosq
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);

            //creacion del modelo de la vista
            var model = new ListaPaginada<Articulo>(paginatedEntries.ToList(), articulos.Count(), page, pageSize, searchString);
            return View(model);
        }
      }
    }
