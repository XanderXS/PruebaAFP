using Prueba.Modelo.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prueba.Modelo.Interface;
using System.Data;

namespace Prueba.Modelo.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalContext _ctx;

        public DoctorRepository(HospitalContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Doctor> createDoctor(Doctor doctor)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_DOCTOR]  @Nombre, @TipoID";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = doctor.Nombre},
                        new SqlParameter("@TipoID", SqlDbType.Int) { Value = doctor.TipoId},
                 };

                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return doctor;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool deleteDoctor(int id)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_ELIMINAR_DOCTOR]  @ID";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = id}
                 };
                _ctx.Database.ExecuteSqlRaw(spSQL, parameters);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public Task<Doctor> GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetDoctores()
        {
            List<Doctor> doctores = await _ctx.Doctors.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_DOCTORES]").ToListAsync();
            return doctores;
        }

        public async Task<Doctor> updateDoctor(Doctor doctor)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_UPDATE_DOCTOR]  @ID,@Nombre, @TipoID";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = doctor.DoctorId},
                        new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = doctor.Nombre},
                        new SqlParameter("@TipoID", SqlDbType.Int) { Value = doctor.TipoId},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return doctor;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
