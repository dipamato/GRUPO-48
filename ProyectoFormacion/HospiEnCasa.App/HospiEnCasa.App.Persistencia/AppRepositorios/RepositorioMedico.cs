using HospiEnCasa.App.Dominio;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext = new AppContext();

        public Medico CrearMedico(Medico medico)
        {
            var medicoA=_appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoA.Entity;
        }

        public Medico ConsultarMedico(int idMedico)
        {
            return _appContext.Medicos.FirstOrDefault(m=>m.Id==idMedico);
        }
        public IEnumerable<Medico> ConsultarMedicos()
        {
           return _appContext.Medicos;
        }
        public Medico ActualizarMedico(Medico medico)
        {
            var resultado=_appContext.Medicos.FirstOrDefault(m=>m.Id==medico.Id);
            if(resultado!=null){
                resultado.Nombre=medico.Nombre;
                resultado.Apellidos=medico.Apellidos;
                resultado.NumeroTelefono=medico.NumeroTelefono;
                resultado.Genero=medico.Genero;
                resultado.Especialidad=medico.Especialidad;
                resultado.Codigo=medico.Codigo;
                resultado.RegistroRethus=medico.RegistroRethus;

                _appContext.SaveChanges();
            }
            return resultado;
        }

        public void EliminarMedico(int idMedico)
        {
            var medicoE=_appContext.Medicos.FirstOrDefault(m=>m.Id==idMedico);
            if(medicoE!=null)
            {
                _appContext.Medicos.Remove(medicoE);
                _appContext.SaveChanges();
            }

        }

        public List<SelectListItem> ConsultaMedicosxNombre()
        {
           return _appContext.Medicos.Select(m=> new SelectListItem
            {
                Text=(m.Nombre+" "+m.Apellidos+"-"+m.Especialidad+" "+m.Codigo),
                Value= m.Nombre.ToString()
            }).ToList();
        }

        public Medico ConsultarMedicoxCodigo(string codigo)
        {
            return _appContext.Medicos.FirstOrDefault(m=>m.Codigo==codigo);
        }
    }
}