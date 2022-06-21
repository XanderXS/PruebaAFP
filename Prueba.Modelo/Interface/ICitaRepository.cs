using Prueba.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo.Interface
{
    public interface ICitaRepository
    {
        Task<List<Citum>> getCitas();
        Task<Citum> createCita(Citum cita);
        bool deleteCita(int Id);
    }
}
