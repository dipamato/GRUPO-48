using HospiEnCasa.App.Dominio;
using System.Collections.Generic;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPacientes
    
    {
        Paciente CrearPaciente(Paciente paciente);
        Paciente ConsultarPaciente(int idPaciente);
        Paciente ConsultarPacientePorTelefono(string NumeroTelefono);
        IEnumerable<Paciente> ConsultarPacientes();
        Paciente ActualizarPaciente(Paciente paciente);
        void EliminarPaciente(int idPaciente);
    }
}