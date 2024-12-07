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
    public partial class f_hoadonxuat : Form
    {
        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        public f_hoadonxuat()
        {
            InitializeComponent();
        }

        private void f_hoadonxuat_Load(object sender, EventArgs e)
        {
            dgv_HDxuat.DataSource = loaddl_HDxuat();
            dgv_HDxuat.DefaultCellStyle.ForeColor = Color.Black;
        }
        private DataTable loaddl_HDxuat()
        {
            DataTable table = new DataTable();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("tp_xemHD", connect);
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
        private void btnThem_hdxuat_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("them_HDxuat", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter mahd = new SqlParameter("@mahd", txt_maHDxuat.Text);
                SqlParameter masp = new SqlParameter("@masp", txt_mSP_cuahang_HDxuat.Text);
                SqlParameter mach = new SqlParameter("@mach", txt_machHDxuat.Text);
                SqlParameter mabv = new SqlParameter("@manv", txt_maNV_HDxuat.Text);
                SqlParameter soluong = new SqlParameter("@soluong", txt_soluong_cuahang_HDxuat.Text);
                SqlParameter ngayxuat = new SqlParameter("@ngayxuat", date_dateXuat_hdxuat.Value.ToString());

                cmd.Parameters.Add(mahd);
                cmd.Parameters.Add(masp);
                cmd.Parameters.Add(mach);
                cmd.Parameters.Add(soluong);
                cmd.Parameters.Add(ngayxuat);
                cmd.Parameters.Add(mabv);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("them thanh cong ");
                }
                else
                {
                    MessageBox.Show("them that bai ");
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
            dgv_HDxuat.DataSource = loaddl_HDxuat();
        }

        private void dgv_HDxuat_Click(object sender, EventArgs e)
        {
            int dong = dgv_HDxuat.CurrentCell.RowIndex;
            txt_maHDxuat.Text = dgv_HDxuat.Rows[dong].Cells[0].Value.ToString();
            txt_mSP_cuahang_HDxuat.Text = dgv_HDxuat.Rows[dong].Cells[1].Value.ToString();
            txt_machHDxuat.Text = dgv_HDxuat.Rows[dong].Cells[2].Value.ToString();
            txt_maNV_HDxuat.Text = dgv_HDxuat.Rows[dong].Cells[3].Value.ToString();
            txt_soluong_cuahang_HDxuat.Text = dgv_HDxuat.Rows[dong].Cells[4].Value.ToString();
            object cellValue = dgv_HDxuat.Rows[dong].Cells[5].Value;
            if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime parsedDate))
            {
                // Gán giá trị đã chuyển đổi cho DateTimePicker
                date_dateXuat_hdxuat.Value = (DateTime)cellValue;
            }
        }

        private void btn_xoa_HDxuat_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("xoa_HDxuat", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter mahd = new SqlParameter("@mahd", txt_maHDxuat.Text);
                cmd.Parameters.Add(mahd);
                

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xoa thanh cong ");
                }
                else
                {
                    MessageBox.Show("Xoa that bai ");
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
            dgv_HDxuat.DataSource = loaddl_HDxuat();
        }

        private void btn_sua_HDxuat_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("sua_HDxuat", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter mahd = new SqlParameter("@ma", txt_maHDxuat.Text);
                cmd.Parameters.Add(mahd);
                SqlParameter mahd1 = new SqlParameter("@mahd", txt_maHDxuat.Text);
                cmd.Parameters.Add(mahd1);
                SqlParameter masp = new SqlParameter("@masp", txt_mSP_cuahang_HDxuat.Text);
                cmd.Parameters.Add(masp);
                SqlParameter mach = new SqlParameter("@mach", txt_machHDxuat.Text);
                cmd.Parameters.Add(mach);
                SqlParameter manv = new SqlParameter("@manv", txt_maNV_HDxuat.Text);
                cmd.Parameters.Add(manv);
                SqlParameter soluong = new SqlParameter("@soluong", txt_soluong_cuahang_HDxuat.Text);
                cmd.Parameters.Add(soluong);
                SqlParameter date = new SqlParameter("@ngayxuat", date_dateXuat_hdxuat.Value);
                cmd.Parameters.Add(date);



                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sua thanh cong ");
                }
                else
                {
                    MessageBox.Show("sua that bai ");
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
            dgv_HDxuat.DataSource = loaddl_HDxuat();
        }
    }
}
