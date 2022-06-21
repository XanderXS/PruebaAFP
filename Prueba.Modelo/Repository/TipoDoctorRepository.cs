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
    public class TipoDoctorRepository : ITipoDoctorRepository
    {
        private readonly HospitalContext _ctx;

        public TipoDoctorRepository(HospitalContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<TipoDotor> createTipoDoctor(TipoDotor TipoDotor)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_TIPO_DOCTOR]  @TipoNombre, @TipoDescripcion";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@TipoNombre", SqlDbType.VarChar) { Value = TipoDotor.TipoNombre},
                        new SqlParameter("@TipoDescripcion", SqlDbType.VarChar) { Value = TipoDotor.TipoDescripcion},
                 };

                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return TipoDotor;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool deleteTipoDoctor(int Id)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_ELIMINAR_TIPO_DOCTOR]  @ID";
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

        public async Task<List<TipoDotor>> getTiposDoctor()
        {
            List<TipoDotor> tipos = await _ctx.TipoDotors.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_TIPO_DOCTOR]").ToListAsync();
            return tipos;
        }
    }
}
