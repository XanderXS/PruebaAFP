using Prueba.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo.Interface
{
    public interface IPacienteRepository
    {
        Task<Paciente> createPaciente(Paciente paciente);
        Task<Paciente> updatePaciente(Paciente paciente);
        bool deletePaciente(int id);
        Task<List<Paciente>> GetPacientes();
        Task<Paciente> GetPacienteById(int id);
    }
}
