using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeDetails.Models
{
    public class EmployeeDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["EmployeeDetailsContext"].ToString();
            con = new SqlConnection(constring);
        }
        public bool AddEmployee(Employee smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_EmpInsertUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeName", smodel.EmployeeName);
            cmd.Parameters.AddWithValue("@PhoneNumber", smodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Description", smodel.Description);
            cmd.Parameters.AddWithValue("@EmpRank", smodel.EmpRank);
            cmd.Parameters.AddWithValue("@EmailID", smodel.EmailID);
            cmd.Parameters.AddWithValue("@UserID", smodel.UserID);
            cmd.Parameters.AddWithValue("@Pwd", smodel.Pwd);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();



            if (i >= 1)
                return true;
            else
                return false;
        }
        public List<Employee> GetEmployee()
        {
            connection();
            List<Employee> Employeeslist = new List<Employee>();

            SqlCommand cmd = new SqlCommand("sp_fetchtbl_EmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Employeeslist.Add(
                    new Employee
                    {
                        EmpID = Convert.ToInt32(dr["EmpID"]),
                        EmployeeName = Convert.ToString(dr["EmployeeName"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Description = Convert.ToString(dr["Description"]),
                        EmpRank = Convert.ToString(dr["EmpRank"]),
                        EmailID = Convert.ToString(dr["EmailID"])

                        

                    });
            }
            return Employeeslist;

        }
        //
        public List<Employee> GetEmployeesForEdit()
        {
            connection();
            List<Employee> Employeeslist = new List<Employee>();

            SqlCommand cmd = new SqlCommand("sp_fetchtbl_EmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Employeeslist.Add(
                    new Employee
                    {
                        EmpID = Convert.ToInt32(dr["EmpID"]),
                        EmployeeName = Convert.ToString(dr["EmployeeName"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Description = Convert.ToString(dr["Description"]),
                        EmpRank = Convert.ToString(dr["EmpRank"]),
                        EmailID = Convert.ToString(dr["EmailID"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        Pwd = Convert.ToString(dr["Pwd"])



                    });
            }
            return Employeeslist;

        }
        public bool UpdateDetails(Employee smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_EmpInsertUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.EmpID);
            cmd.Parameters.AddWithValue("@EmployeeName", smodel.EmployeeName);
            cmd.Parameters.AddWithValue("@PhoneNumber", smodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Description", smodel.Description);
            cmd.Parameters.AddWithValue("@EmpRank", smodel.EmpRank);
            cmd.Parameters.AddWithValue("@EmailID", smodel.EmailID);
            cmd.Parameters.AddWithValue("@UserID", smodel.UserID);
            cmd.Parameters.AddWithValue("@Pwd", smodel.Pwd);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool DeleteEmployee(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("sp_EmployeeDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


    }
}