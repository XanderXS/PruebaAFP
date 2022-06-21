using Prueba.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo.Interface
{
    public interface IDiagnosticoRepository
    {
        Task<List<Diagnostico>> getDiagnostico();
        Task<Diagnostico> createDiagnostico(Diagnostico diagnostico);
        bool deleteDiagnostico(int Id);
    }
}
