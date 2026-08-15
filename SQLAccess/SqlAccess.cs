using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SQLAccess
{
    public class SqlAccess
    {

        private static string strConnetionString = ConfigurationManager.ConnectionStrings["E10"].ToString();
     
        #region SQL
        public DataSet GetBySQL(string sp, SqlParameter[] parameters)
        {
            DataSet InfoList = new DataSet();
            using (SqlConnection connection = new SqlConnection(strConnetionString))
            {
                SqlCommand comandoSql = new SqlCommand(sp, connection);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //AGREGAR PARAMETROS
                comandoSql.Parameters.AddRange(parameters);
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }

                    SqlDataAdapter da = new SqlDataAdapter(comandoSql);
                    da.Fill(InfoList);

                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error GetReport :{0} \n{1}", sp, ex.Message), ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }

            return InfoList;


        }

        public DataSet GetBySQL(string sp)
        {
            DataSet InfoList = new DataSet();

            using (SqlConnection connection = new SqlConnection(strConnetionString))
            {

                SqlCommand comandoSql = new SqlCommand(sp, connection);
                comandoSql.CommandType = CommandType.StoredProcedure;

                //AGREGAR PARAMETROS
                //comandoSql.Parameters.AddRange(parameters);
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }

                    SqlDataAdapter da = new SqlDataAdapter(comandoSql);
                    da.Fill(InfoList);

                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error GetReport :{0} \n{1}", sp, ex.Message), ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }

            return InfoList;


        }

        public bool GetBySQL_bool(string sp)
        {
            bool updated = false;
            DataSet InfoList = new DataSet();

            using (SqlConnection connection = new SqlConnection(strConnetionString))
            {

                SqlCommand comandoSql = new SqlCommand(sp, connection);
                comandoSql.CommandType = CommandType.StoredProcedure;

                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }

                    int count = 0;
                    IAsyncResult result = comandoSql.BeginExecuteNonQuery();
                    while (!result.IsCompleted)
                    {
                        count++;
                    }

                    comandoSql.EndExecuteNonQuery(result);
                    string este = String.Format("Command complete. Affected {0} rows.", count);
                }
                catch (Exception ex)
                {
                    updated = true;
                   
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }

            return updated;
        }

        #endregion

        delegate bool DType(string input);

        public bool AsynUpdProductionStatus(string sp)
        {
            bool data = false;
            DType method = new DType(GetBySQL_bool);

            IAsyncResult a = method.BeginInvoke(sp, (res) =>
            {
                data = method.EndInvoke(res);
            }
            , null);

            return data;
        }

        public bool validDS(DataSet ds)
        {
            bool valid = false;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    valid = true;
                }
            }


            return valid;
        }

        public bool validDT(DataTable dt)
        {
            bool valid = false;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    valid = true;
                }
            }


            return valid;
        }

        public bool GetBySQL_bool_KPI(string sp)
        {


            bool updated = false;
            DataSet InfoList = new DataSet();

            using (SqlConnection connection = new SqlConnection(strConnetionString))
            {

                SqlCommand comandoSql = new SqlCommand(sp,
                    connection);
                comandoSql.CommandType = CommandType.StoredProcedure;
                //AGREGAR PARAMETROS
                comandoSql.Parameters.AddRange(parametersKPI);

                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }

                    IAsyncResult result = comandoSql.BeginExecuteNonQuery();
                    while (!result.IsCompleted)
                    {
                      
                    }
                    

                    comandoSql.EndExecuteNonQuery(result);

                }
                catch (Exception ex)
                {
                    updated = true;
                    //  throw new Exception(string.Format("Error GetReport :{0} \n{1}", sp, ex.Message), ex);
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                }
            }

            return updated;

        }


        #region KPI
        SqlParameter[] parametersKPI;

        public bool AsynUpdProductionStatus_KPI(string sp, SqlParameter[] parameters)
        {
            parametersKPI = parameters;
            bool data = false;
            DType method = new DType(GetBySQL_bool_KPI);


            IAsyncResult a = method.BeginInvoke(sp, (res) =>
            {
                data = method.EndInvoke(res);
            }
            , parameters);

            return data;
        }

         #endregion
    }
}
