using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan_ver1._0
{
    public partial class f_cuahang : Form
    {
        public f_cuahang()
        {
            InitializeComponent();
        }

        private void f_cuahang_Load(object sender, EventArgs e)
        {
            dgvCuaHang1.DataSource = loaddl_cuahan();
            dgvCuaHang1.DefaultCellStyle.ForeColor = Color.Black;
            dgvTimKiem.DataSource = loaddl_cuahan();
            dgvTimKiem.DefaultCellStyle.ForeColor = Color.Black;
        }
        // SqlConnection connect = new SqlConnection("Data Source=LAPTOP-BA92BEJG\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");
        //SqlConnection connect = new SqlConnection("Data Source=LAPTOP-BA92BEJG\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");
        private DataTable loaddl_cuahan()
        {
            DataTable table = new DataTable();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("tp_xem_cuahang", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter hienthi = new SqlDataAdapter(cmd);
                hienthi.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdThemCuaHang = new SqlCommand("tp_ThemCuaHang");
                cmdThemCuaHang.CommandText = "tp_ThemCuaHang";
                cmdThemCuaHang.CommandType = CommandType.StoredProcedure;
                cmdThemCuaHang.Connection = connect;

                SqlParameter paTenCH = new SqlParameter("@tenCuaHang", txtTenCH.Text);
                cmdThemCuaHang.Parameters.Add(paTenCH);

                SqlParameter paDiaChi = new SqlParameter("@diaChi", txtDiachi.Text);
                cmdThemCuaHang.Parameters.Add(paDiaChi);

                SqlParameter paSoDT = new SqlParameter("@soDienThoai", txtSoDT.Text);
                cmdThemCuaHang.Parameters.Add(paSoDT);

                if (cmdThemCuaHang.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Them cua hang thanh cong");

                }
                else
                {
                    MessageBox.Show("Them cua hang that bai");
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
            dgvCuaHang1.DataSource = loaddl_cuahan();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdXoaCH = new SqlCommand("tp_XoaCuaHang");
                cmdXoaCH.CommandText = "tp_xoaCuaHang";
                cmdXoaCH.CommandType = CommandType.StoredProcedure;
                cmdXoaCH.Connection = connect;

                //them bien
                SqlParameter paMaCH = new SqlParameter("@maCuaHang", txtMaCH.Text);
                cmdXoaCH.Parameters.Add(paMaCH);

                if (cmdXoaCH.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xoa cua hang thanh cong");

                }
                else
                {
                    MessageBox.Show("Xoa cua hang that bai");
                }
            }
            catch (SqlException sql)
            {

                if (sql.Number == 547)
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại !");
                }
                else
                {
                    MessageBox.Show(sql.Number.ToString());
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
            dgvCuaHang1.DataSource = loaddl_cuahan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdSuaCH = new SqlCommand("tp_SuaCuaHang");
                cmdSuaCH.CommandType = CommandType.StoredProcedure;
                cmdSuaCH.Connection = connect;


                SqlParameter paMaCH = new SqlParameter("@maCuaHang", txtMaCH.Text);
                cmdSuaCH.Parameters.Add(paMaCH);

                SqlParameter paTenCH = new SqlParameter("@tenCuaHang", txtTenCH.Text);
                cmdSuaCH.Parameters.Add(paTenCH);

                SqlParameter paDiaChi = new SqlParameter("@diaChi", txtDiachi.Text);
                cmdSuaCH.Parameters.Add(paDiaChi);

                SqlParameter paSoDT = new SqlParameter("@soDienThoai", txtSoDT.Text);
                cmdSuaCH.Parameters.Add(paSoDT);

                //thucthi
                if (cmdSuaCH.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sua cua hang thanh cong");

                }
                else
                {
                    MessageBox.Show("Sua cua hang that bai");
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
            dgvCuaHang1.DataSource = loaddl_cuahan();
        }


        private void btnLammoi1_Click(object sender, EventArgs e)
        {
            txtMaCH.Clear();
            txtTenCH.Clear();
            txtDiachi.Clear();
            txtSoDT.Clear();

            dgvCuaHang1.DataSource = loaddl_cuahan();

            MessageBox.Show("Dữ liệu đã được làm mới! ");
        }

        private void rdbTimtheoma_CheckedChanged(object sender, EventArgs e)
        {
            txtTimtheoma.Enabled = rdbTimtheoma.Checked;
            txtTimtheoten.Enabled = false;
            txtTimtheodc.Enabled = false;
            txtTimtheoma.Clear();
            txtTimtheoten.Clear();
            txtTimtheodc.Clear();
        }

        private void rdbTimtheoten_CheckedChanged(object sender, EventArgs e)
        {
            txtTimtheoten.Enabled = rdbTimtheoten.Checked;
            txtTimtheoma.Enabled = false;
            txtTimtheodc.Enabled = false;
        }

        private void rdbTimtheodc_CheckedChanged(object sender, EventArgs e)
        {
            txtTimtheodc.Enabled = rdbTimtheodc.Checked;
            txtTimtheoten.Enabled = false;
            txtTimtheoma.Enabled = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;

                if (!string.IsNullOrWhiteSpace(txtTimtheoma.Text))
                {
                    cmd.CommandText = "seach_MaCH";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maCuaHang", txtTimtheoma.Text.Trim());

                }
                else if (!string.IsNullOrWhiteSpace(txtTimtheoten.Text))
                {
                    cmd.CommandText = "seach_TenCH";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenCuaHang", txtTimtheoten.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txtTimtheodc.Text))
                {
                    cmd.CommandText = "seach_DiaChi";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@diaChi", txtTimtheodc.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin tìm kiếm. ");
                    return;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvTimKiem.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        private void dgvCuaHang1_Click(object sender, EventArgs e)
        {
            int dong = dgvCuaHang1.CurrentCell.RowIndex;
            txtMaCH.Text = dgvCuaHang1.Rows[dong].Cells[0].Value.ToString();
            txtTenCH.Text = dgvCuaHang1.Rows[dong].Cells[1].Value.ToString();
            txtDiachi.Text = dgvCuaHang1.Rows[dong].Cells[2].Value.ToString();
            txtSoDT.Text = dgvCuaHang1.Rows[dong].Cells[3].Value.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void control_cuahang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
           
        }

        private void control_cuahang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (control_cuahang.SelectedTab == tabPage5)
            {
                dgvCuaHang1.DataSource = loaddl_cuahan();
            }
            if (control_cuahang.SelectedTab == tabPage1)
            {
                crystalReportViewer1.RefreshReport();
            }
        }
    }
}
