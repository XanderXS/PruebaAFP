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
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly HospitalContext _ctx;

        public DiagnosticoRepository(HospitalContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Diagnostico> createDiagnostico(Diagnostico diagnostico)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_DIAGNOSTICO]  @CitaID, @Resumen";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@CitaID", SqlDbType.VarChar) { Value = diagnostico.CitaId},
                        new SqlParameter("@Resumen", SqlDbType.VarChar) { Value = diagnostico.Resumen},
                 };

                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return diagnostico;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool deleteDiagnostico(int Id)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_ELIMINAR_DIAGNOSTICO]  @ID";
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

        public async Task<List<Diagnostico>> getDiagnostico()
        {
            List<Diagnostico> d = await _ctx.Diagnosticos.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_GIAGNOSTICOS]").ToListAsync();
            return d;
        }
    }
}
