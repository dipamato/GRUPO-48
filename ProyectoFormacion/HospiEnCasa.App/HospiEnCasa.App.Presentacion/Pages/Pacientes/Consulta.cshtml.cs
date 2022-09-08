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
    public class ConsultaModel : PageModel
    {
        private readonly IRepositorioPacientes _repoPaciente;

        public IEnumerable<Paciente> listaPaciente{get;set;}
        public ConsultaModel(IRepositorioPacientes repoPacientes)
        {
            _repoPaciente=repoPacientes;
          
        }
        public void OnGet(int pacienteId)
        {
            
            listaPaciente=_repoPaciente.ConsultarPacientes();
            _repoPaciente.EliminarPaciente(pacienteId);
        }
    }
}
