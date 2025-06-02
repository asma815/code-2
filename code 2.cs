using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class EmployeeManagementSystem : Form
{
    public EmployeeManagementSystem()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEEKBHE\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cnn = new SqlCommand("insert into Employee values(@employeeid,@employeename,@email,@salary)", con))
                {
                    cnn.Parameters.AddWithValue("@EmployeeId", int.Parse(textBox1.Text));
                    cnn.Parameters.AddWithValue("@EmployeeName", textBox2.Text);
                    cnn.Parameters.AddWithValue("@Email", textBox3.Text);
                    cnn.Parameters.AddWithValue("@Salary", Convert.ToDecimal(textBox4.Text));
                    cnn.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Saved Successfully");
            DisplayRecords();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DisplayRecords()
    {
        try
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEEKBHE\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"))
            {
                using (SqlCommand cnn = new SqlCommand("select * from Employee", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cnn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEEKBHE\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cnn = new SqlCommand("delete Employee where employeeid=@employeeid", con))
                {
                    cnn.Parameters.AddWithValue("@EmployeeId", int.Parse(textBox1.Text));
                    cnn.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Record Deleted Successfully");
            DisplayRecords();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void EmployeeManagementSystem_Load(object sender, EventArgs e)
    {
        DisplayRecords();
        try
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HEEKBHE\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True"))
            {
                using (SqlCommand cnn = new SqlCommand("select * from Employee", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cnn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    label8.Text = dt.Rows.Count.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}

