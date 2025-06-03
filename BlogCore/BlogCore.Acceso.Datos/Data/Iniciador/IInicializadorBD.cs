using BlogCore.Data;
using BlogCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Iniciador
{
    public interface IInicializadorBD
    {
        void Inicializar();
    }
}
