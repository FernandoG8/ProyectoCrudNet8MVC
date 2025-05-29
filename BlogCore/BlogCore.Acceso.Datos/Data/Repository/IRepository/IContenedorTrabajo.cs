using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        // Aqui se deben de ir agregando todo los repositorios que se vayan creando
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider{ get; }
        void Save();
    }
}
