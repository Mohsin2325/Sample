using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
namespace WCFApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior (InstanceContextMode =InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
         static int cont = 0;
        public string GetData(int value)
        {
            FaultDemo fd = new FaultDemo();
            SqlConnection con = null;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            try
            {
                con.Open();

                SqlDataAdapter ad = new SqlDataAdapter("select * from employee", con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                //SqlCommand cmd = new SqlCommand("sp_employeeTran", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                ////out int pm;
                //cmd.Parameters.AddWithValue("@site_name", "Mohsin");
                //SqlParameter Param = new SqlParameter("@id",SqlDbType.VarChar);
                //Param.Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(Param);
                //cmd.ExecuteNonQuery();
                //return Param.Value.ToString();

            }
            catch (Exception ex)
            {
                con.Close();
                fd.message = ex.Message.ToString();
                throw new FaultException<FaultDemo>(fd, "Divide by zero");

            }
            finally
            {
                con.Close();
            }
            return "Done";
            //try
            //{
            //    //cont = cont + 1;
            //    //return string.Format("You entered: {0}", cont);
            //    return (1 / cont).ToString();
            //}
            //catch (Exception ex)
            //{

            //    fd.message = ex.Message.ToString();
            //    throw new FaultException<FaultDemo>(fd, "Divide by zero");
            //}
            
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
