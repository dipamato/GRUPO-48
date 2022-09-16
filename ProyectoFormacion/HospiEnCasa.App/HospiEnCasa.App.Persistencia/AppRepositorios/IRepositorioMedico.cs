using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioMedico
    
    {
        Medico CrearMedico(Medico medico);
        Medico ConsultarMedico(int idMedico);
        //Medico ConsultarMedicoPorTelefono(string NumeroTelefono);
        IEnumerable<Medico> ConsultarMedicos();
        Medico ActualizarMedico(Medico medico);
        void EliminarMedico(int idMedico);
        List<SelectListItem> ConsultaMedicosxNombre();
        Medico ConsultarMedicoxCodigo(string codigo);
    }
}