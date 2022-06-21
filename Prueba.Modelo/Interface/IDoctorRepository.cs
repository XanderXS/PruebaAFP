using Prueba.Modelo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Modelo.Interface
{
    public interface IDoctorRepository
    {
        Task<Doctor> createDoctor(Doctor doctor);
        Task<Doctor> updateDoctor(Doctor doctor);
        bool deleteDoctor(int id);
        Task<List<Doctor>> GetDoctores();
        Task<Doctor> GetDoctorById(int id);
    }
}
