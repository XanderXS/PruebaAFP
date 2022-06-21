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
    public class CitaRepository : ICitaRepository
    {
        private readonly HospitalContext _ctx;

        public CitaRepository(HospitalContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Citum> createCita(Citum cita)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_CITA]  @PacienteID, @DoctorID, @FechaHora";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@PacienteID", SqlDbType.Int) { Value = cita.PacienteId},
                        new SqlParameter("@DoctorID", SqlDbType.Int) { Value = cita.DoctorId},
                        new SqlParameter("@FechaHora", SqlDbType.DateTime) { Value = cita.FechaHora},
                 };

                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return cita;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool deleteCita(int Id)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_ELIMINAR_CITA]  @ID";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = Id}
                 };
                _ctx.Database.ExecuteSqlRaw(spSQL, parameters);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<List<Citum>> getCitas()
        {
            List<Citum> citas = await _ctx.Cita.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_CITAS]").ToListAsync();
            return citas;
        }
    }
}
