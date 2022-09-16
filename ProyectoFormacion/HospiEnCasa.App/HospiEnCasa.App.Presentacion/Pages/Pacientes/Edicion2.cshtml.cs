using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class Edicion2Model : PageModel
    
    {
        
        private readonly IRepositorioPacientes _repoPaciente;
        private readonly IRepositorioMedico _repoMedico;
        [BindProperty]
        public Paciente paciente{get;set;}
        [BindProperty]
        public Medico medico{get;set;}
        public List<SelectListItem> Nombres{get;set;}
        public Edicion2Model(IRepositorioPacientes repoPaciente,IRepositorioMedico repoMedico)
        {
            _repoPaciente=repoPaciente;
            _repoMedico=repoMedico;
        }
        public void OnGet()
        {
            paciente=new Paciente();
            Nombres = new List<SelectListItem>();
            Nombres=_repoMedico.ConsultaMedicosxNombre();
            medico=new Medico();
        }

        public async Task<IActionResult> OnPost()
        {
            Nombres=_repoMedico.ConsultaMedicosxNombre();
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
            string aux=Request.Form["valor"];
            Console.WriteLine(aux);
            var x=aux.Split(' ');
            Console.WriteLine(x[2]);
            medico=_repoMedico.ConsultarMedicoxCodigo(x[2]);
            Console.WriteLine(medico.Nombre);
            paciente.Medico=medico;
            paciente=_repoPaciente.ActualizarPaciente(paciente);
            if(paciente!=null)
            {
                return RedirectToPage("/Pacientes/Consulta");
            }
            return RedirectToPage("/Error");
        }
    }
}
