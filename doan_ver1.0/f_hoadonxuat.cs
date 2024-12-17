using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
        private void show_report()
        {
           
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
            if (updatesp() == true)
            {
                them_HD();
            }
            else
            {
                MessageBox.Show("so luong khong du");
            }
            //updatesp();
            //them_HD();
            dgv_HDxuat.DataSource = loaddl_HDxuat();
        }
        private void them_HD()
        {
            try
            {


                if(connect.State == System.Data.ConnectionState.Closed)
                {
                    connect.Open();
                }
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
            catch (SqlException sql)
            {
                if (sql.Number == 2627)
                {
                    MessageBox.Show("mã hóa đơn đã tồn tại !");
                }
                else if (sql.Number == 547)
                {
                    MessageBox.Show("kiểm tra lại mã cửa hàng, sản phẩm,mã nhân viên không tồn tại!");
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
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    connect.Close();
                }
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

        private void rdbTimtheoma_CheckedChanged(object sender, EventArgs e)
        {
            txtTimtheoma.Enabled = rdt_seach_maHD.Checked;
            txt_seach_manv.Enabled = false;
            date_seach.Enabled = false;
            txtTimtheoma.Clear();
            txt_seach_manv.Clear();

            
        }

        private void rdt_seach_manv_CheckedChanged(object sender, EventArgs e)
        {
            txt_seach_manv.Enabled = rdt_seach_manv.Checked;
            txtTimtheoma.Enabled = false;
            txtTimtheoma.Clear();
            txt_seach_manv.Clear();
        }

        private void rdbTimtheodc_CheckedChanged(object sender, EventArgs e)
        {
            txt_seach_manv.Enabled = rdt_seach_manv.Enabled;
            date_seach.Enabled=false;
            txtTimtheoma.Enabled = false;
            txt_seach_manv.Enabled = false;
            txtTimtheoma.Clear();
            txt_seach_manv.Clear();
        }

        private void rdc_seach_date_CheckedChanged(object sender, EventArgs e)
        {
            date_seach.Enabled = true;
            txtTimtheoma.Enabled = false;
            txt_seach_manv.Enabled = false;
            txtTimtheoma.Clear();
            txt_seach_manv.Clear();

        }

        private DataTable seach_hd_xuat(string path,string store,string content)
        {
            DataTable table = new DataTable();  
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(path,connect);
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter x = new SqlParameter(store,content);
                cmd.Parameters.Add(x);

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
        private DataTable seach_hd_xuat_date(string path, string store,string store2, string content1,string content2)
        {
            DataTable table = new DataTable();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(path, connect);
                cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter x = new SqlParameter(store, content1);
                cmd.Parameters.Add(x);
                SqlParameter x2 = new SqlParameter(store2, content2);
                cmd.Parameters.Add(x2);

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

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if(rdt_seach_maHD.Checked == true)
            {
                dgv_HDxuat.DataSource = seach_hd_xuat("tp_seach_mahD", "@maHD", txtTimtheoma.Text);
            }
            else if(rdt_seach_manv.Checked == true)
            {
                dgv_HDxuat.DataSource = seach_hd_xuat("tp_seach_maNV", "@manv", txt_seach_manv.Text);

            }
            else if (rdc_seach_date.Checked == true)
            {
                dgv_HDxuat.DataSource = seach_hd_xuat_date("tp_search_ngayXuat", "@ThoiGianA", "@ThoiGianB", date_A.Value.ToString(), date_B.Value.ToString());
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage3)
            {
                dgv_HDxuat.Hide();
                tabControl1.Size = new System.Drawing.Size(800, 434);
                //crystalReportViewer1.ReportSource.Refresh();
                crystalReportViewer1.RefreshReport();

               
            }
            else
            {
                dgv_HDxuat.Show();

            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }
        private Boolean updatesp()
        {
            try
            {
                connect.Open();

                // Gọi Stored Procedure
                SqlCommand cmd = new SqlCommand("UpdateSoLuongSanPham", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số cho Stored Procedure
                cmd.Parameters.AddWithValue("@MaSanPham", txt_mSP_cuahang_HDxuat.Text);
                cmd.Parameters.AddWithValue("@SoLuongBan", txt_soluong_cuahang_HDxuat.Text);

                // Thực thi Stored Procedure
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                  // MessageBox.Show("Thêm HD thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Không đủ số lượng để bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect?.Close();
            }
            dgv_HDxuat.DataSource = loaddl_HDxuat();
            return false;
        }

        private void btn_report_HDxuat_Click(object sender, EventArgs e)
        {
            string maHD = txt_maHDxuat.Text;
            form_report_hdxuat report = new form_report_hdxuat(maHD);
            report.Show();
        }
    }
}
    
