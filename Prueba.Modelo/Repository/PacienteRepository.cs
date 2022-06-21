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
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HospitalContext _ctx;

        public PacienteRepository(HospitalContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Paciente> createPaciente(Paciente paciente)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_PACIENTE]  @Nombre";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = paciente.Nombre},
                 };

                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return paciente;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool deletePaciente(int id)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_ELIMINAR_PACIENTE]  @ID";
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

        public async Task<Paciente> GetPacienteById(int id)
        {
            Paciente paciente = await _ctx.Pacientes.FromSqlRaw("EXECUTE [dbo].[SP_GET_PACIENTE] @ID = " + id).FirstOrDefaultAsync();
            return paciente;
        }

        public async Task<List<Paciente>> GetPacientes()
        {
            List<Paciente> pacientes = await _ctx.Pacientes.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_PACIENTES]").ToListAsync();
            return pacientes;
        }

        public async Task<Paciente> updatePaciente(Paciente paciente)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_MODIFICAR_PACIENTE]  @ID,@Nombre";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = paciente.PacienteId},
                        new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = paciente.Nombre},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return paciente;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
