using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SqlMagic.Lib
{
    public class AdoSqlExecutor : ISqlExecutor
    {
        public SqlResponse<T> Execute<T>(SqlRequest request)
        {
            try
            {

                string spName = "Analyse.csp_BehandelingZwarteLijst_s01";
                IDbDataParameter[] parameters = DBModule.Data.GetStoredProcedureParameters(spName);
                parameters.Single(p => p.ParameterName == "@ZorgverzekeraarId").Value = zorgverzekeraarId;
                parameters.Single(p => p.ParameterName == "@Peildatum").Value = peildatum;

                return DBModule.Data.ExecutePOCO<BehandelingZwarteLijst>(spName, parameters);
            }
            catch (SqlException sqlEx)
            {
                throw DataUtil.HandleSqlException(sqlEx);
            }

            return null;
        }
    }
}
