using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejemplo.Pages
{
    public class ProductosModel : PageModel
    {
        private string[] productos={"Pizza","Perros Calientes","Hamburguesa","Bebidas"};
        public List<string> listaProductos {get;set;}
        public void OnGet()
        {
            listaProductos =new List<string>();
            listaProductos.AddRange(productos);
        }
    }
}
