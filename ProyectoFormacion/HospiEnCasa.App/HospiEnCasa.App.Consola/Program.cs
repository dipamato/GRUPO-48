using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;


namespace HospiEnCasa.App.Consola
{
    class Program
    {
       // private static IRepositorioPacientes _repoPaciente=new RepositorioPacientes(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CrearPaciente();
            //EliminarPaciente();
            
            
        }
        
/*
        private static void EliminarPaciente()
        {
            _repoPaciente.EliminarPaciente(1);
        }
        private static void CrearPaciente(){
            var paciente=new Paciente
            {
                Nombre="Andrea",
                Apellidos="Yaima",
                NumeroTelefono="7890123",
                Genero =Genero.Femenino,
                Direccion="Carrera 15 Calle 46",
                Longitud = 8.64F,
                Latitud= -2.68F,
                Ciudad= "Medellin",
                FechaNacimiento=new DateTime (1998,05,16)
            };
            _repoPaciente.CrearPaciente(paciente);
        }*/
    }
}
