using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCO1_Opersys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myConn;
            String myConnection = "datasource=localhost;database=wdi;port=3306;username=root;password=mysqldev";
            dataGridView1.AutoResizeColumns();
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                myConn = new MySqlConnection(myConnection);
                Console.WriteLine("Success");

                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "select * from databyyear;";
                myConn.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = command;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dt;
                dataGridView1.DataSource = bSource;
                sda.Update(dt);
                sw.Stop();
                timeElapsed.Text = sw.Elapsed.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Failed");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
