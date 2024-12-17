using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan_ver1._0
{
    public partial class Info_people : Form
    {
        //SqlConnection connect = new SqlConnection("Data Source=DESKTOP-QDFNGC7\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");
        //SqlConnection connect1 = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");
        //SqlConnection connect = new SqlConnection("Data Source=LAPTOP-BA92BEJG\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        public Info_people(List<String> info)
        {
            InitializeComponent();
            check_dlnhan(info);
            date_ngaytao.MaxDate = DateTime.Now;

        }

        private void check_dlnhan(List<String> info)
        {
            if (info != null) {
                cb_matk.Text = info[0].ToString().Trim();
                cb_user.Text = info[1].ToString().Trim();
                cb_pass.Text = info[2].ToString().Trim();
                cb_name.Text = info[3].ToString().Trim();
                cb_email.Text = info[4].ToString().Trim();
                cb_vaitro.Text = info[5].ToString().Trim();
                DateTime dt;
                if (DateTime.TryParse(info[6].ToString().Trim(),out dt))
                {
                    date_ngaytao.Value = dt;
                }
            }
        }
        private void Info_people_Load(object sender, EventArgs e)
        {

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("tp_SuaTaiKhoan",connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter user = new SqlParameter("@tenDangNhap",cb_user.Text);
                SqlParameter pass = new SqlParameter("@matKhauNew", cb_pass.Text);
                SqlParameter name = new SqlParameter("@hoTenNew", cb_name.Text);
                SqlParameter email = new SqlParameter("@emailNew", cb_email.Text);
                SqlParameter vaitro = new SqlParameter("@vaiTroNew", cb_vaitro.Text);
                SqlParameter date = new SqlParameter("@ngayTaoNew", date_ngaytao.Value);

                cmd.Parameters.Add(user);
                cmd.Parameters.Add(pass);
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(vaitro);
                cmd.Parameters.Add(date);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công !!");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại :<<");

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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            xoa_account();
            this.Close();
        }
        private void xoa_account()
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("tp_XoaTaiKhoan", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter user = new SqlParameter("@tenDangNhap", cb_user.Text);
                cmd.Parameters.Add(user);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thành công !!");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại :<<");

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

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Xác nhận thoát", "Bạn có chắc muốn thoát không !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void btn_report_people_Click(object sender, EventArgs e)
        {
            string maTaiKhoan = cb_user.Text;
            inthongtin info = new inthongtin(maTaiKhoan);
            info.Show();
        }

       
    }
}
