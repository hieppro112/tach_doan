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
    public partial class f_sanpham : Form
    {
        //SqlConnection connect = new SqlConnection("Data Source=DESKTOP-QDFNGC7\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
       SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        public f_sanpham()
        {
            InitializeComponent();
        }
        private void btnXoa_Sp_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmdXoa = new SqlCommand("tp_XoaSanPham", connect);
                cmdXoa.CommandType = CommandType.StoredProcedure;

                SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);
                cmdXoa.Parameters.Add(ma);

                if (cmdXoa.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thành công ! ");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại ! ");
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
            dataGV_sanPham.DataSource = loaddl_SanPham();
            
            data_GV_timKiem.DataSource = loaddl_SanPham();
        }
        private void btnThem_Sp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa_sp.Text) ||
                string.IsNullOrWhiteSpace(txtTenSp.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text) ||
                string.IsNullOrWhiteSpace(cbDanhMuc_Sp.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo");
                return;
            }

            try
            {


                connect.Open();

                DateTime ngayNhap = dateNgaySinh.Value;
                DateTime ngayHienTai = DateTime.Now;
                DateTime baThangTruoc = ngayHienTai.AddMonths(-3);


                int soLuong;
                double donGia;

                if (!int.TryParse(txtSoLuong.Text, out soLuong) || !double.TryParse(txtDonGia.Text, out donGia))
                {
                    MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ.", "Thông báo");
                    return;
                }

                // Tính thành tiền
                double thanhTien = donGia * soLuong;
                txtThanhTien.Text = thanhTien.ToString();


                SqlCommand cmdThem = new SqlCommand("tp_ThemSanPham", connect);
                cmdThem.CommandType = CommandType.StoredProcedure;

                cmdThem.Parameters.AddWithValue("@MaSanPham", txtMa_sp.Text);
                cmdThem.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                cmdThem.Parameters.AddWithValue("@TenSanPham", txtTenSp.Text);
                cmdThem.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
                cmdThem.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
                cmdThem.Parameters.AddWithValue("@ThanhTien", thanhTien);
                cmdThem.Parameters.AddWithValue("@DanhMuc", cbDanhMuc_Sp.Text);

                if (cmdThem.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!");

                    // Kiểm tra nếu ngày nhập cách đây >= 3 tháng
                    if (ngayNhap <= baThangTruoc)
                    {
                        // Cập nhật DataGridView Hàng Tồn
                        dataHangTon.DataSource = LoadHangTonKho();
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.");
                }
            }
            catch ( SqlException sql)
            {
                if(sql.Number == 2627)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại !", "Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm sản phẩm: " + ex.Message, "Thông báo");
            }
            finally
            {

                connect.Close();
            }


            dataGV_sanPham.DataSource = loaddl_SanPham();
            data_GV_timKiem.DataSource = loaddl_SanPham();
        }


        public DataTable loaddl_SanPham()
        {
            DataTable dataTable = new DataTable();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("tp_xemkho", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter hienThi = new SqlDataAdapter(cmd);
                hienThi.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return null;
        }

       



        private void btnLamMoi_Sp_Click_1(object sender, EventArgs e)
        {
            try
            {

                dataGV_sanPham.DataSource = loaddl_SanPham();


                txtMa_sp.Clear();
                txtTenSp.Clear();
                txtSoLuong.Clear();
                txtDonGia.Clear();
                txtThanhTien.Clear();
                cbDanhMuc_Sp.SelectedIndex = -1;



                MessageBox.Show("Dữ liệu đã được làm mới!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void panel_sanPham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_TK_timKiem_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();

                // Tạo lệnh SQL và thêm tham số
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;

                // Kiểm tra điều kiện tìm kiếm và thực hiện theo từng loại
                if (!string.IsNullOrWhiteSpace(txt_TK_MaSP.Text))
                {
                    cmd.CommandText = "sp_timKiem_MaSanPham";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSanPham", txt_TK_MaSP.Text);
                }
                else if (!string.IsNullOrWhiteSpace(txt_TK_Ten.Text))
                {
                    cmd.CommandText = "sp_timKiem_TenSP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenSanPham", txt_TK_Ten.Text);
                }
                else if (!string.IsNullOrWhiteSpace(cmb_TK_DanhMuc.Text))
                {
                    cmd.CommandText = "sp_timKiem_DanhMuc";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DanhMuc", cmb_TK_DanhMuc.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.");
                    return;
                }


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                data_GV_timKiem.DataSource = dt;


                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào.");
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

       

        private void f_sanpham_Load(object sender, EventArgs e)
        {
           
                dataGV_sanPham.DataSource = loaddl_SanPham();
                dataGV_sanPham.DefaultCellStyle.ForeColor = Color.Black;
                data_GV_timKiem.DataSource = loaddl_SanPham();
                data_GV_timKiem.DefaultCellStyle.ForeColor = Color.Black;
                dataHangTon.DataSource = LoadHangTonKho();
                dataHangTon.DefaultCellStyle.ForeColor = Color.Black;

                Color commonColor = ColorTranslator.FromHtml("#3498DB"); 
                Color hoverColor = ColorTranslator.FromHtml("#2980B9"); 

            Button[] buttons = { btnThem_Sp, btnXoa_Sp, btnCapNhat, btnLamMoi_Sp, btn_TK_timKiem, btn_TK_LamMoi,btnXuat };

            foreach (Button btn in buttons)
            {
                btn.BackColor = commonColor;
                btn.ForeColor = Color.White; 
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.MouseOverBackColor = hoverColor; 
                btn.Cursor = Cursors.Hand; 
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage3)
            {
                dataHangTon.DataSource = LoadHangTonKho();
            }
            if (tabControl1.SelectedTab == tabPage4)
            {
                crystalReportViewer1.RefreshReport();
            }
        }

        private void txt_TK_MaSP_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rad_TK_Ma_CheckedChanged(object sender, EventArgs e)
        {
               txt_TK_MaSP.Enabled = rad_TK_Ma.Checked;
               txt_TK_Ten.Enabled = false;
               cmb_TK_DanhMuc.Enabled = false;
        }

        private void rad_TK_Ten_CheckedChanged(object sender, EventArgs e)
        {
            txt_TK_Ten.Enabled = rad_TK_Ten.Checked;
              txt_TK_MaSP.Enabled = false;
               cmb_TK_DanhMuc.Enabled = false;
        }

        private void rad_TK_DanhMuc_CheckedChanged(object sender, EventArgs e)
        {
            cmb_TK_DanhMuc.Enabled = rad_TK_DanhMuc.Checked;
              txt_TK_MaSP.Enabled = false;
             txt_TK_Ten.Enabled = false;
        }

        private void btn_TK_LamMoi_Click(object sender, EventArgs e)
        {
            txt_TK_MaSP.Clear();
             txt_TK_Ten.Clear();
              cmb_TK_DanhMuc.SelectedIndex = -1;

            data_GV_timKiem.DataSource = loaddl_SanPham();
        }

        private void data_GV_timKiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_GV_timKiem_Click(object sender, EventArgs e)
        {

        }

        private void dataGV_sanPham_Click(object sender, EventArgs e)
        {
            int dong = dataGV_sanPham.CurrentCell.RowIndex;


            // Gán các giá trị khác
            txtMa_sp.Text = dataGV_sanPham.Rows[dong].Cells[1].Value.ToString();
            txtTenSp.Text = dataGV_sanPham.Rows[dong].Cells[2].Value.ToString();
            dateNgaySinh.Text = dataGV_sanPham.Rows[dong].Cells[3].Value.ToString();
            txtSoLuong.Text = dataGV_sanPham.Rows[dong].Cells[4].Value.ToString();
            txtDonGia.Text = dataGV_sanPham.Rows[dong].Cells[5].Value.ToString();
            txtThanhTien.Text = dataGV_sanPham.Rows[dong].Cells[6].Value.ToString();
            cbDanhMuc_Sp.Text = dataGV_sanPham.Rows[dong].Cells[7].Value.ToString();
       }

        private void cbDanhMuc_Sp_DropDown(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
            try
            {
                connect.Open();
                if (string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ đơn giá và số lượng.");
                    return;
                }



           
                double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

                
                txtThanhTien.Text = thanhTien.ToString();

        

                SqlCommand cmdThem = new SqlCommand("tp_CapNhat", connect);
                cmdThem.CommandType = CommandType.StoredProcedure;

                SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);

                SqlParameter ngayNhap = new SqlParameter("@NgayNhap", dateNgaySinh.Value);
                cmdThem.Parameters.Add(ngayNhap);

                cmdThem.Parameters.Add(ma);
                SqlParameter ten = new SqlParameter("@TenSanPham", txtTenSp.Text);
                cmdThem.Parameters.Add(ten);
                SqlParameter soLuongParam = new SqlParameter("@SoLuong", txtSoLuong.Text);
                cmdThem.Parameters.Add(soLuongParam);
                SqlParameter donGiaParam = new SqlParameter("@DonGia", txtDonGia.Text);
                cmdThem.Parameters.Add(donGiaParam);
                SqlParameter thanhTienParam = new SqlParameter("@ThanhTien", thanhTien);
                cmdThem.Parameters.Add(thanhTienParam);
                SqlParameter danhMuc = new SqlParameter("@DanhMuc", cbDanhMuc_Sp.Text);
                cmdThem.Parameters.Add(danhMuc);


                if (cmdThem.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
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
            dataGV_sanPham.DataSource = loaddl_SanPham();
            data_GV_timKiem.DataSource = loaddl_SanPham();
        }
        // hàng tồn
        private DataTable LoadHangTonKho()
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (connect.State== System.Data.ConnectionState.Closed)
                {
                    connect.Open();
                }

                // Lấy dữ liệu các sản phẩm có ngày nhập cách đây 3 tháng hoặc hơn
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM SanPham WHERE NgayNhap <= DATEADD(MONTH, -3, GETDATE())",
                    connect
                );

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                connect.Close();
            }

            return dataTable;
        }



        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataHangTon_Click(object sender, EventArgs e)
        {
            int dong = dataHangTon.CurrentCell.RowIndex;


           
           txtMaSP_hangton.Text = dataHangTon.Rows[dong].Cells[1].Value.ToString();
            txtTenSP_hangTon.Text = dataHangTon.Rows[dong].Cells[2].Value.ToString();
            dateNgayNhap_HangTon.Text = dataHangTon.Rows[dong].Cells[3].Value.ToString();
            txtSoLuong_hangTon.Text = dataHangTon.Rows[dong].Cells[4].Value.ToString();
            txtDonGia_hangton.Text = dataHangTon.Rows[dong].Cells[5].Value.ToString();
            txtThanhTien_HangTon.Text = dataHangTon.Rows[dong].Cells[6].Value.ToString();
            cmbDanhMuc_hangTon.Text = dataHangTon.Rows[dong].Cells[7].Value.ToString();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGV_sanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string baoCao = txtMa_sp.Text;
            form_thongtinSP_Report report = new form_thongtinSP_Report(baoCao);
            report.Show();
        }
    }
}
