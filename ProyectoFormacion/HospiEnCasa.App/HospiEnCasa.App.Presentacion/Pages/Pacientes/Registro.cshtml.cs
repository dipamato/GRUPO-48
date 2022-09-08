using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class RegistroModel : PageModel
    {
        private readonly IRepositorioPacientes _repoPaciente;

        public RegistroModel (IRepositorioPacientes repoPaciente)
        {
            _repoPaciente=repoPaciente;
        }

        [BindProperty]
        public Paciente paciente {get;set;}
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid){
                return Page();
            }
            _repoPaciente.CrearPaciente(paciente);
            return RedirectToPage("/Index");
        }
    }
}
