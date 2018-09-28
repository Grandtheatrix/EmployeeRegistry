using EmployeeRegistry.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRegistry
{
    public partial class EmployeeRegistryMainPage : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllEmployees();
            }
        }

        protected void btnSubmitNew_Click(object sender, EventArgs e)
        {
            var newEmployee = new EmployeeCreateRequest();
            newEmployee.FirstName = txtFirstName.Text;
            newEmployee.LastName = txtLastName.Text;
            newEmployee.PhoneNumber = "(" + txtPhoneNumber.Text.Substring(0,3) + ") " + txtPhoneNumber.Text.Substring(3, 3) + "-" + txtPhoneNumber.Text.Substring(6, 4);
            newEmployee.Zipcode = txtZipcode.Text;
            newEmployee.HireDate = txtHireDate.Text;
            int newId = CreateEmployee(newEmployee);
            GetAllEmployees();
            ClearTextBoxes(Page);
        }
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }

        public int CreateEmployee(EmployeeCreateRequest req)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Post_Employee";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", req.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", req.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", req.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Zipcode", req.Zipcode);
                    cmd.Parameters.AddWithValue("@HireDate", req.HireDate);
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int id = (int)cmd.Parameters["@Id"].Value;
                    return id;
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    throw;
                }
            }
        }
        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblId = (Label)e.Item.FindControl("lblId");
                lblId.Text = ((EmployeeGetRequest)e.Item.DataItem).Id.ToString();

                Label lblFirstName = (Label)e.Item.FindControl("lblFirstName");
                lblFirstName.Text = ((EmployeeGetRequest)e.Item.DataItem).FirstName;

                Label lblLastName = (Label)e.Item.FindControl("lblLastName");
                lblLastName.Text = ((EmployeeGetRequest)e.Item.DataItem).LastName;

                Label lblPhoneNumber = (Label)e.Item.FindControl("lblPhoneNumber");
                lblPhoneNumber.Text = ((EmployeeGetRequest)e.Item.DataItem).PhoneNumber;

                Label lblHireDate = (Label)e.Item.FindControl("lblHireDate");
                lblHireDate.Text = ((EmployeeGetRequest)e.Item.DataItem).HireDate ;
            }
        }
        public void GetAllEmployees()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Get_Employees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<EmployeeGetRequest> employees = new List<EmployeeGetRequest>();

                    while (reader.Read())
                    {
                        var employee = new EmployeeGetRequest();

                        employee.Id = (int)reader["Id"];
                        employee.FirstName = (string)reader["FirstName"];
                        employee.LastName = (string)reader["LastName"];
                        employee.PhoneNumber = (string)reader["PhoneNumber"];
                        var dt = (DateTime)reader["HireDate"];
                        employee.HireDate = dt.ToShortDateString();

                        employees.Add(employee);
                    }

                    rpt.DataSource = employees;
                    rpt.DataBind();

                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var req = new QueryRequest();
            req.Query = txtSearch.Text;
            SearchEmployees(req);

        }
        public void SearchEmployees(QueryRequest req)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Search_Employees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Query", req.Query);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<EmployeeGetRequest> employees = new List<EmployeeGetRequest>();

                    while (reader.Read())
                    {
                        var employee = new EmployeeGetRequest();

                        employee.Id = (int)reader["Id"];
                        employee.FirstName = (string)reader["FirstName"];
                        employee.LastName = (string)reader["LastName"];
                        employee.PhoneNumber = (string)reader["PhoneNumber"];
                        var dt = (DateTime)reader["HireDate"];
                        employee.HireDate = dt.ToShortDateString();

                        employees.Add(employee);
                    };
                   
                    rpt.DataSource = employees;
                    rpt.DataBind();

                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            GetAllEmployees();
        }
    }
}