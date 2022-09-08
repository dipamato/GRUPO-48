using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class EdicionModel : PageModel
    {
        private readonly IRepositorioPacientes _repoPaciente;
        [BindProperty]
        public Paciente paciente{get;set;}
        public EdicionModel(IRepositorioPacientes repoPaciente)
        {
            _repoPaciente=repoPaciente;
        }
        public void OnGet(int pacienteId)
        {
            paciente=_repoPaciente.ConsultarPaciente(pacienteId);
        }

        public async Task<IActionResult> OnPost()
        {
            paciente=_repoPaciente.ActualizarPaciente(paciente);
            if(paciente==null){
                return Page();
            }
            return RedirectToPage("/Pacientes/Consulta");
        }
    }
}
