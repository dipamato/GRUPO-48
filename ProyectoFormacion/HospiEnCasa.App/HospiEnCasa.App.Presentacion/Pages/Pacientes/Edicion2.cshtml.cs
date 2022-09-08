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
    public class Edicion2Model : PageModel
    
    {
        
        private readonly IRepositorioPacientes _repoPaciente;
        [BindProperty]
        public Paciente paciente{get;set;}
        public Edicion2Model(IRepositorioPacientes repoPaciente)
        {
            _repoPaciente=repoPaciente;
        }
        public void OnGet()
        {
            paciente=new Paciente();
        }

        public async Task<IActionResult> OnPost()
        {
            paciente=_repoPaciente.ConsultarPacientePorTelefono(paciente.NumeroTelefono);
            if(paciente==null)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                return Page();
            }
          
        }
        public async Task<IActionResult> OnPostEdit()
        {
            paciente=_repoPaciente.ActualizarPaciente(paciente);
            if(paciente!=null)
            {
                return RedirectToPage("/Pacientes/Consulta");
            }
            return RedirectToPage("/Error");
        }
    }
}
