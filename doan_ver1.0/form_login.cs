using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan_ver1._0
{
    public partial class form_login : Form
    {
       // SqlConnection connect = new SqlConnection("Data Source=DESKTOP-QDFNGC7\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        public form_login()
        {
            InitializeComponent();
        }
        private void result(int i)
        {
            if (i == 1)
            {
                string vaitro = "";
                MessageBox.Show("Đăng nhập thành công ! ","Thông báo");
                getvaitro(ref vaitro);
                home_giaodien home = new home_giaodien(vaitro);
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại, vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu ", "Warring !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getvaitro(ref string vaitro)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("tp_get_vaitro", connect);   
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter user = new SqlParameter("@user",txt_user_admin);
                //cmd.Parameters.Add(user);
                cmd.Parameters.AddWithValue("@user", txt_user_admin.Text);

                vaitro = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
            
        }

        private void login()
        {
            try
            {
                connect.Open();
                SqlCommand login = new SqlCommand("dangnhap_taikhoan", connect);
                login.CommandType = CommandType.StoredProcedure;

                SqlParameter user = new SqlParameter("@user", txt_user_admin.Text);
                SqlParameter pass = new SqlParameter("@pass", txt_Pass_admin.Text);

                login.Parameters.Add(user);
                login.Parameters.Add(pass);

                if ((int)login.ExecuteScalar() > 0)
                {
                    result(1);
                }
                else
                {
                    result(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void btn_login_admin_Click(object sender, EventArgs e)
        {
            login();
            
        }

        private void form_login_Load(object sender, EventArgs e)
        {

        }
    }
}
