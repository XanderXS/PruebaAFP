using Prueba.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo.Interface
{
    public interface ITipoDoctorRepository
    {
        Task<List<TipoDotor>> getTiposDoctor();
        Task<TipoDotor> createTipoDoctor(TipoDotor TipoDotor);
        bool deleteTipoDoctor(int Id);
    }
}
