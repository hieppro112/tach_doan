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
    public partial class home_giaodien : Form
    {
        public home_giaodien(string vaitro)
        {
            InitializeComponent();
            panel_HDxuat.Hide();
            //panel_sanpham.Hide();
            //pannel_cuahang.Hide();
            quyen_admin(vaitro);
        }
        //tim kiếm danh sách 

        private void quyen_admin(string vaitro)
        {
            if (vaitro != null)
            {
                if (vaitro != "Admin")
                {
                    panel_nhanvien_info.Hide();
                    app_account.Enabled = false;
                }
            }
        }
        // SqlConnection connect = new SqlConnection("Data Source=DESKTOP-QDFNGC7\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");


        private DataTable loaddl_nhanvien()
        {
            DataTable table = new DataTable();
            try
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand("tp_xemTaiKhoan", connect);
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
        //private void home_giaodien_Load(object sender, EventArgs e)
        //{
        //    table_info_accout.DataSource = loaddl_nhanvien();
        //    table_info_accout.DefaultCellStyle.ForeColor = Color.Black;
        //    dataGV_sanPham.DataSource = loaddl_SanPham();
        //    dataGV_sanPham.DefaultCellStyle.ForeColor = Color.Black;
        //    data_GV_timKiem.DataSource = loaddl_SanPham();
        //    data_GV_timKiem.DefaultCellStyle.ForeColor = Color.Black;
        //    dgv_HDxuat.DataSource = loaddl_HDxuat();
        //    dgv_HDxuat.DefaultCellStyle.ForeColor = Color.Black;
        //    dgv_nhanvien.DataSource = loaddl_nhanvien();
        //    dgv_nhanvien.DefaultCellStyle.ForeColor = Color.Black;
        //    cb_seach_nhanvien.SelectedIndex = 0;
        //    panel_nhanvien_info.Hide();
        //    dgvCuaHang1.DataSource = loaddl_cuahan();
        //    dgvCuaHang1.DefaultCellStyle.ForeColor = Color.Black;
        //    dgvTimKiem.DefaultCellStyle.ForeColor = Color.Black;

        //    load_first();

        //}
        //private void load_first()
        //{
        //    panel_nhanvien_info.Hide();
        //    pannel_cuahang.Hide();
        //    panel_sanpham.Hide();
        //    panel_xuathoadon.Hide();
        //    panel_banner.Show();
        //}
        private void table_info_accout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> l = new List<string>();
            laydl_accout(l);
            Info_people info_People = new Info_people(l);
            info_People.Owner = this;
            info_People.FormClosed += new FormClosedEventHandler(home_giaodien_FormClosed);
            info_People.ShowDialog();
        }

        private void laydl_accout(List<String> list)
        {
            int dong = dgv_nhanvien.CurrentCell.RowIndex;
            for (int i = 0; i < dgv_nhanvien.ColumnCount; i++)
            {
                list.Add(dgv_nhanvien.Rows[dong].Cells[i].Value.ToString());
            }
        }

        private void app_account_Click(object sender, EventArgs e)
        {
            panel_HDxuat.Hide();
            panel_banner.Hide();
            panel_main.Hide();
            panel_nhanvien_info.Show();
            app_account.BackColor = System.Drawing.Color.Red;

        }


        private void home_giaodien_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgv_nhanvien.DataSource = loaddl_nhanvien();
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            FormDangKy dangky = new FormDangKy();
            dangky.Owner = this;
            dangky.FormClosed += new FormClosedEventHandler(home_giaodien_FormClosed);
            dangky.ShowDialog();
        }


        //private void app_SanPham_Click(object sender, EventArgs e)
        //{
        //    pannel_cuahang.Hide();
        //    panel_sanpham.Show();
        //    panel_HDxuat.Hide();
        //    panel_banner.Hide();
        //    panel_nhanvien_info.Hide();
        //}

        //private void btnThem_Sp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        connect.Open();
        //        if (string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
        //        {
        //            MessageBox.Show("Vui lòng nhập đủ đơn giá và số lượng.");
        //            return;
        //        }



        //        // Tính thành tiền
        //        double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

        //        // Hiển thị thành tiền lên textbox
        //        txtThanhTien.Text = thanhTien.ToString();

        //        // Tiến hành thêm sản phẩm vào cơ sở dữ liệu

        //        SqlCommand cmdThem = new SqlCommand("tp_ThemSanPham", connect);
        //        cmdThem.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);
        //        cmdThem.Parameters.Add(ma);
        //        SqlParameter ten = new SqlParameter("@TenSanPham", txtTenSp.Text);
        //        cmdThem.Parameters.Add(ten);
        //        SqlParameter soLuongParam = new SqlParameter("@SoLuong", txtSoLuong.Text);
        //        cmdThem.Parameters.Add(soLuongParam);
        //        SqlParameter donGiaParam = new SqlParameter("@DonGia", txtDonGia.Text);
        //        cmdThem.Parameters.Add(donGiaParam);
        //        SqlParameter thanhTienParam = new SqlParameter("@ThanhTien", thanhTien);
        //        cmdThem.Parameters.Add(thanhTienParam);
        //        SqlParameter danhMuc = new SqlParameter("@DanhMuc", cbDanhMuc_Sp.Text);
        //        cmdThem.Parameters.Add(danhMuc);


        //        if (cmdThem.ExecuteNonQuery() > 0)
        //        {
        //            MessageBox.Show("Thêm thành công!");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm thất bại!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }
        //    dataGV_sanPham.DataSource = loaddl_SanPham();
        //    data_GV_timKiem.DataSource = loaddl_SanPham();
        //}

        //private void dataGV_sanPham_Click(object sender, EventArgs e)
        //{
        //    int dong = dataGV_sanPham.CurrentCell.RowIndex;


        //    // Gán các giá trị khác
        //    txtMa_sp.Text = dataGV_sanPham.Rows[dong].Cells[1].Value.ToString();
        //    txtTenSp.Text = dataGV_sanPham.Rows[dong].Cells[2].Value.ToString();
        //    txtSoLuong.Text = dataGV_sanPham.Rows[dong].Cells[4].Value.ToString();
        //    txtDonGia.Text = dataGV_sanPham.Rows[dong].Cells[5].Value.ToString();
        //    txtThanhTien.Text = dataGV_sanPham.Rows[dong].Cells[6].Value.ToString();
        //    cbDanhMuc_Sp.Text = dataGV_sanPham.Rows[dong].Cells[7].Value.ToString();

        //}

        private void table_info_accout_DoubleClick(object sender, EventArgs e)
        {

        }
        //hien thi nhan vien 
        private void hienthi_f_sp()
        {
            f_sanpham f_Sanpham = new f_sanpham();
            f_Sanpham.TopLevel = false;
            f_Sanpham.FormBorderStyle = FormBorderStyle.None;
            f_Sanpham.Dock = DockStyle.Fill;

            panel_main.Controls.Clear();
            panel_main.Controls.Add(f_Sanpham);

            f_Sanpham.Show();
        }

        //seach nhan vien
        private void btn_seach_click(object sender, EventArgs e)
        {
            seach_nhanvien();
        }
        private void seach_nhanvien()
        {
            int vitri = cb_seach_nhanvien.SelectedIndex;
            switch (vitri)
            {
                case 0:
                    dgv_nhanvien.DataSource = seach_sql("seach_maTK", "@maTK");
                    break;
                case 1:
                    dgv_nhanvien.DataSource = seach_sql("seach_user", "@user");
                    break;

                case 2:
                    dgv_nhanvien.DataSource = seach_sql("seach_name", "@name");
                    break;
                case 3:
                    dgv_nhanvien.DataSource = seach_sql("seach_email", "@email");
                    break;
                case 4:
                    dgv_nhanvien.DataSource = seach_sql("seach_vaitro", "@vaitro");
                    break;

                default:
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp"); break;
            }
        }

        private DataTable seach_sql(string sql, string data)
        {
            DataTable table = new DataTable();
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(sql, connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter a = new SqlParameter(data, txt_seach_nhanvien.Text);
                cmd.Parameters.Add(a);
                cmd.ExecuteNonQuery();

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

        //private void btnXoa_Sp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        connect.Open();
        //        SqlCommand cmdXoa = new SqlCommand("tp_XoaSanPham", connect);
        //        cmdXoa.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);
        //        cmdXoa.Parameters.Add(ma);

        //        if (cmdXoa.ExecuteNonQuery() > 0)
        //        {
        //            MessageBox.Show("Xóa thành công ! ");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa thất bại ! ");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }
        //    dataGV_sanPham.DataSource = loaddl_SanPham();
        //}

        //private void btnSua_Sp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Kiểm tra nếu người dùng nhập đủ thông tin
        //        if (string.IsNullOrWhiteSpace(txtMa_sp.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
        //        {
        //            MessageBox.Show("Vui lòng nhập đủ mã sản phẩm, đơn giá và số lượng.");
        //            return;
        //        }




        //        // Tính thành tiền
        //        double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

        //        // Tiến hành sửa sản phẩm trong cơ sở dữ liệu
        //        connect.Open();
        //        SqlCommand cmdSua = new SqlCommand("tp_SuaSanPham", connect);
        //        cmdSua.CommandType = CommandType.StoredProcedure;

        //        // Thêm các tham số vào câu lệnh
        //        cmdSua.Parameters.Add(new SqlParameter("@MaSanPham", txtMa_sp.Text));   // Mã sản phẩm
        //        cmdSua.Parameters.Add(new SqlParameter("@TenSanPham", txtTenSp.Text));   // Tên sản phẩm
        //        cmdSua.Parameters.Add(new SqlParameter("@SoLuong", txtSoLuong.Text));            // Số lượng
        //        cmdSua.Parameters.Add(new SqlParameter("@DonGia", txtDonGia.Text));              // Đơn giá
        //        cmdSua.Parameters.Add(new SqlParameter("@ThanhTien", thanhTien));        // Thành tiền
        //        cmdSua.Parameters.Add(new SqlParameter("@DanhMuc", cbDanhMuc_Sp.Text));    // Danh mục

        //        // Kiểm tra kết quả thực thi
        //        cmdSua.ExecuteNonQuery();

        //        MessageBox.Show("Cập nhật sản phẩm thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }

        //    // Load lại dữ liệu
        //    dataGV_sanPham.DataSource = loaddl_SanPham();
        //}

        //private void btnLamMoi_Sp_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        dataGV_sanPham.DataSource = loaddl_SanPham();


        //        txtMa_sp.Clear();
        //        txtTenSp.Clear();
        //        txtSoLuong.Clear();
        //        txtDonGia.Clear();
        //        txtThanhTien.Clear();


        //        MessageBox.Show("Dữ liệu đã được làm mới!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}

        private void panel_sanPham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void home_giaodien_Load(object sender, EventArgs e)
        {
            dgv_nhanvien.DataSource = loaddl_nhanvien();
            dgv_nhanvien.DefaultCellStyle.ForeColor = Color.Black;
            cb_seach_nhanvien.SelectedIndex = 0;
            
        }

        private void doi_color_app()
        {
            
        }

        private void app_SanPham_Click(object sender, EventArgs e)
        {
            panel_nhanvien_info.Hide();
            panel_banner.Hide();
            panel_main.Show();
            hienthi_f_cuahang();
        }

        private void hienthi_f_cuahang()
        {
            f_cuahang f_cuahang = new f_cuahang();
            f_cuahang.TopLevel = false;
            f_cuahang.FormBorderStyle = FormBorderStyle.None;
            f_cuahang.Dock = DockStyle.Fill;
            panel_main.Controls.Clear();
            panel_main.Controls.Add(f_cuahang);
            f_cuahang.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txt_seach_nhanvien.Clear();
            dgv_nhanvien.DataSource = loaddl_nhanvien();

        }

        private void app_hoadon_Click(object sender, EventArgs e)
        {
            

            panel_banner.Hide();
            panel_nhanvien_info.Hide();
            panel_main.Show(); 
            hienthi_f_xuatHD();
        }
        private void hienthi_f_xuatHD()
        {
            f_hoadonxuat f_hoadonxuat = new f_hoadonxuat();
            f_hoadonxuat.TopLevel = false;
            f_hoadonxuat.FormBorderStyle = FormBorderStyle.None;
            f_hoadonxuat.Dock = DockStyle.Fill;
            panel_main.Controls.Clear();
            panel_main.Controls.Add(f_hoadonxuat);

            f_hoadonxuat.Show();

        }

        private void app_logout_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("xac nhan thoat ","ban da chon dang xuat, ban co chac ?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel_main_Click(object sender, EventArgs e)
        {
            app_account.BackColor = System.Drawing.Color.Red;
        }


        //private void btn_TK_timKiem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        connect.Open();

        //        // Tạo lệnh SQL và thêm tham số
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = connect;

        //        // Kiểm tra điều kiện tìm kiếm và thực hiện theo từng loại
        //        if (!string.IsNullOrWhiteSpace(txt_TK_MaSP.Text))
        //        {
        //            cmd.CommandText = "sp_timKiem_MaSanPham";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@MaSanPham", txt_TK_MaSP.Text);
        //        }
        //        else if (!string.IsNullOrWhiteSpace(txt_TK_Ten.Text))
        //        {
        //            cmd.CommandText = "sp_timKiem_TenSP";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@TenSanPham", txt_TK_Ten.Text);
        //        }
        //        else if (!string.IsNullOrWhiteSpace(cmb_TK_DanhMuc.Text))
        //        {
        //            cmd.CommandText = "sp_timKiem_DanhMuc";
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DanhMuc", cmb_TK_DanhMuc.Text);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.");
        //            return;
        //        }


        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);


        //        data_GV_timKiem.DataSource = dt;


        //        if (dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("Không tìm thấy sản phẩm nào.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }
        //}

        //private void rad_TK_Ma_CheckedChanged(object sender, EventArgs e)
        //{
        //    txt_TK_MaSP.Enabled = rad_TK_Ma.Checked;
        //    txt_TK_Ten.Enabled = false;
        //    cmb_TK_DanhMuc.Enabled = false;
        //}

        //private void rad_TK_Ten_CheckedChanged(object sender, EventArgs e)
        //{
        //    txt_TK_Ten.Enabled = rad_TK_Ten.Checked;
        //    txt_TK_MaSP.Enabled = false;
        //    cmb_TK_DanhMuc.Enabled = false;
        //}

        //private void rad_TK_DanhMuc_CheckedChanged(object sender, EventArgs e)
        //{
        //    cmb_TK_DanhMuc.Enabled = rad_TK_DanhMuc.Checked;
        //    txt_TK_MaSP.Enabled = false;
        //    txt_TK_Ten.Enabled = false;
        //}

        //private void btn_TK_LamMoi_Click(object sender, EventArgs e)
        //{
        //    txt_TK_MaSP.Clear();
        //    txt_TK_Ten.Clear();
        //    cmb_TK_DanhMuc.SelectedIndex = -1;  


        //   data_GV_timKiem.DataSource = loaddl_SanPham(); 


        //    MessageBox.Show("Dữ liệu đã được làm mới!");
        //}

        //private void app_cuahang_Click(object sender, EventArgs e)
        //{
        //    pannel_cuahang.Show();
        //    panel_sanpham.Hide();
        //    panel_HDxuat.Hide();
        //    panel_banner.Hide();
        //    panel_xuathoadon.Hide();
        //    panel_nhanvien_info.Hide();
        //    hienthi_sp();
        //}

        //private void panel_account_Paint(object sender, PaintEventArgs e)
        //{

    }
}

//hóa đơn
//    private DataTable loaddl_HDxuat()
//    {
//        DataTable table = new DataTable();
//        try
//        {
//            connect.Open();
//            SqlCommand cmd  = new SqlCommand("tp_xemHD",connect);
//            cmd.CommandType = CommandType.StoredProcedure;

//            SqlDataAdapter hienthi = new SqlDataAdapter(cmd);
//            hienthi.Fill(table);

//            return table;

//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//        return null;
//    }

//    private void panel1_Paint(object sender, PaintEventArgs e)
//    {

//    }



//    private void pannel_cuahang_Paint(object sender, PaintEventArgs e)
//    {

//    }
//    private DataTable loaddl_cuahan()
//    {
//        DataTable table = new DataTable();
//        try
//        {
//            connect.Open();
//            SqlCommand cmd = new SqlCommand("tp_xem_cuahang", connect);
//            cmd.CommandType = CommandType.StoredProcedure;

//            SqlDataAdapter hienthi = new SqlDataAdapter(cmd);
//            hienthi.Fill(table);

//            return table;
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//        return null;
//    }

//    private void app_hoadon_Click(object sender, EventArgs e)
//    {
//        pannel_cuahang.Hide();
//        panel_sanpham.Hide();
//        panel_xuathoadon.Show();
//        panel_banner.Hide();
//        panel_nhanvien_info.Hide();
//    }

//    private void btnThem_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmdThemCuaHang = new SqlCommand("tp_ThemCuaHang");
//            cmdThemCuaHang.CommandText = "tp_ThemCuaHang";
//            cmdThemCuaHang.CommandType = CommandType.StoredProcedure;
//            cmdThemCuaHang.Connection = connect;

//            SqlParameter paTenCH = new SqlParameter("@tenCuaHang", txtTenCH.Text);
//            cmdThemCuaHang.Parameters.Add(paTenCH);

//            SqlParameter paDiaChi = new SqlParameter("@diaChi", txtDiachi.Text);
//            cmdThemCuaHang.Parameters.Add(paDiaChi);

//            SqlParameter paSoDT = new SqlParameter("@soDienThoai", txtSoDT.Text);
//            cmdThemCuaHang.Parameters.Add(paSoDT);

//            if (cmdThemCuaHang.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("Them cua hang thanh cong");

//            }
//            else
//            {
//                MessageBox.Show("Them cua hang that bai");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//        dgvCuaHang1.DataSource = loaddl_cuahan();
//    }
//    private void them_HD(int soluong)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmd  = new SqlCommand("them_HDxuat",connect);
//            cmd.CommandType = CommandType.StoredProcedure;

//            SqlParameter mahd = new SqlParameter("@mahd",txt_maHDxuat.Text);
//            SqlParameter masp = new SqlParameter("@masp", txt_maHDxuat.Text);
//            SqlParameter mach = new SqlParameter("@mach", txt_machHDxuat.Text);
//            SqlParameter manv = new SqlParameter("@manv", txt_maNV_HDxuat.Text);
//            SqlParameter sl = new SqlParameter("@soluong", txt_soluong_cuahang_HDxuat.Text);
//            SqlParameter ngayxuat = new SqlParameter("@ngayxuat", date_dateXuat_hdxuat.Value);

//            cmd.Parameters.Add(mahd);
//            cmd.Parameters.Add(masp);
//            cmd.Parameters.Add(mach);
//            cmd.Parameters.Add(manv);
//            cmd.Parameters.Add(sl);
//            cmd.Parameters.Add(ngayxuat);

//            cmd.ExecuteNonQuery();
//            if (cmd.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("them hoa don thanh cong");

//            }
//            else
//            {
//                MessageBox.Show("them hoa don that bai !!");
//            }


//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//    }

//    private void dgvCuaHang1_Click(object sender, EventArgs e)
//    {
//        int dong = dgvCuaHang1.CurrentCell.RowIndex;
//        txtMaCH.Text = dgvCuaHang1.Rows[dong].Cells[0].Value.ToString();
//        txtTenCH.Text = dgvCuaHang1.Rows[dong].Cells[1].Value.ToString();
//        txtDiachi.Text = dgvCuaHang1.Rows[dong].Cells[2].Value.ToString();
//        txtSoDT.Text = dgvCuaHang1.Rows[dong].Cells[3].Value.ToString();
//    }

//    private void dataGV_sanPham_Click_1(object sender, EventArgs e)
//    {
//        int dong = dataGV_sanPham.CurrentCell.RowIndex;
//        txtMa_sp.Text = dataGV_sanPham.Rows[dong].Cells[1].Value.ToString();
//        txtTenSp.Text = dataGV_sanPham.Rows[dong].Cells[2].Value.ToString();
//        txtSoLuong.Text = dataGV_sanPham.Rows[dong].Cells[4].Value.ToString();
//        txtDonGia.Text = dataGV_sanPham.Rows[dong].Cells[5].Value.ToString();
//        txtThanhTien.Text = dataGV_sanPham.Rows[dong].Cells[6].Value.ToString();
//        cbDanhMuc_Sp.Text = dataGV_sanPham.Rows[dong].Cells[7].Value.ToString();
//    }

//    private void button1_Click(object sender, EventArgs e)
//    {
//        FormDangKy frdangky = new FormDangKy();
//        frdangky.ShowDialog();
//    }

//    private void pictureBox3_Click(object sender, EventArgs e)
//    {
//        txt_seach_nhanvien.Clear();
//        dgv_nhanvien.DataSource = loaddl_nhanvien();
//    }

//    private void btnXoa_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmdXoaCH = new SqlCommand("tp_XoaCuaHang");
//            cmdXoaCH.CommandText = "tp_xoaCuaHang";
//            cmdXoaCH.CommandType = CommandType.StoredProcedure;
//            cmdXoaCH.Connection = connect;

//            //them bien
//            SqlParameter paMaCH = new SqlParameter("@maCuaHang", txtMaCH.Text);
//            cmdXoaCH.Parameters.Add(paMaCH);

//            if (cmdXoaCH.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("Xoa cua hang thanh cong");

//            }
//            else
//            {
//                MessageBox.Show("Xoa cua hang that bai");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);

//        }
//        finally
//        {
//            connect.Close();
//        }
//        dgvCuaHang1.DataSource = loaddl_cuahan();
//    }

//    private void btnSua_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmdSuaCH = new SqlCommand("tp_SuaCuaHang");
//            cmdSuaCH.CommandType = CommandType.StoredProcedure;
//            cmdSuaCH.Connection = connect;


//            SqlParameter paMaCH = new SqlParameter("@maCuaHang", txtMaCH.Text);
//            cmdSuaCH.Parameters.Add(paMaCH);

//            SqlParameter paTenCH = new SqlParameter("@tenCuaHang", txtTenCH.Text);
//            cmdSuaCH.Parameters.Add(paTenCH);

//            SqlParameter paDiaChi = new SqlParameter("@diaChi", txtDiachi.Text);
//            cmdSuaCH.Parameters.Add(paDiaChi);

//            SqlParameter paSoDT = new SqlParameter("@soDienThoai", txtSoDT.Text);
//            cmdSuaCH.Parameters.Add(paSoDT);

//            //thucthi
//            if (cmdSuaCH.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("Sua cua hang thanh cong");

//            }
//            else
//            {
//                MessageBox.Show("Sua cua hang that bai");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);

//        }
//        finally
//        {
//            connect.Close();
//        }
//        dgvCuaHang1.DataSource = loaddl_cuahan();
//    }

//    private void btnLammoi1_Click(object sender, EventArgs e)
//    {
//        txtMaCH.Clear();
//        txtTenCH.Clear();
//        txtDiachi.Clear();
//        txtSoDT.Clear();

//        dgvCuaHang1.DataSource = loaddl_cuahan();

//        MessageBox.Show("Dữ liệu đã được làm mới! ");
//    }

//    private void rdbTimtheodc_CheckedChanged(object sender, EventArgs e)
//    {
//        txtTimtheodc.Enabled = rdbTimtheodc.Checked;
//        txtTimtheoten.Enabled = false;
//        txtTimtheoma.Enabled = false;
//    }

//    private void rdbTimtheoten_CheckedChanged(object sender, EventArgs e)
//    {
//        txtTimtheoten.Enabled = rdbTimtheoten.Checked;
//        txtTimtheoma.Enabled = false;
//        txtTimtheodc.Enabled = false;
//    }

//    private void rdbTimtheoma_CheckedChanged(object sender, EventArgs e)
//    {
//        txtTimtheoma.Enabled = rdbTimtheoma.Checked;
//        txtTimtheoten.Enabled = false;
//        txtTimtheodc.Enabled = false;
//        txtTimtheoma.Clear();
//        txtTimtheoten.Clear();
//        txtTimtheodc.Clear();
//    }

//    private void btnTimkiem_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = connect;

//            if (!string.IsNullOrWhiteSpace(txtTimtheoma.Text))
//            {
//                cmd.CommandText = "seach_MaCH";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@maCuaHang", txtTimtheoma.Text.Trim());

//            }
//            else if (!string.IsNullOrWhiteSpace(txtTimtheoten.Text))
//            {
//                cmd.CommandText = "seach_TenCH";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@tenCuaHang", txtTimtheoten.Text);
//            }
//            else if (!string.IsNullOrWhiteSpace(txtTimtheodc.Text))
//            {
//                cmd.CommandText = "seach_DiaChi";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@diaChi", txtTimtheodc.Text);
//            }
//            else
//            {
//                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm. ");
//                return;
//            }
//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataTable dt = new DataTable();
//            adapter.Fill(dt);

//            dgvTimKiem.DataSource = dt;

//            if (dt.Rows.Count == 0)
//            {
//                MessageBox.Show("Không tìm thấy kết quả nào.");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show("Lỗi: " + ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//    }

//    private void btnThem_Sp_Click_1(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            if (string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
//            {
//                MessageBox.Show("Vui lòng nhập đủ đơn giá và số lượng.");
//                return;
//            }



//            // Tính thành tiền
//            double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

//            // Hiển thị thành tiền lên textbox
//            txtThanhTien.Text = thanhTien.ToString();

//            // Tiến hành thêm sản phẩm vào cơ sở dữ liệu

//            SqlCommand cmdThem = new SqlCommand("tp_ThemSanPham", connect);
//            cmdThem.CommandType = CommandType.StoredProcedure;

//            SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);
//            cmdThem.Parameters.Add(ma);
//            SqlParameter ten = new SqlParameter("@TenSanPham", txtTenSp.Text);
//            cmdThem.Parameters.Add(ten);
//            SqlParameter soLuongParam = new SqlParameter("@SoLuong", txtSoLuong.Text);
//            cmdThem.Parameters.Add(soLuongParam);
//            SqlParameter donGiaParam = new SqlParameter("@DonGia", txtDonGia.Text);
//            cmdThem.Parameters.Add(donGiaParam);
//            SqlParameter thanhTienParam = new SqlParameter("@ThanhTien", thanhTien);
//            cmdThem.Parameters.Add(thanhTienParam);
//            SqlParameter danhMuc = new SqlParameter("@DanhMuc", cbDanhMuc_Sp.Text);
//            cmdThem.Parameters.Add(danhMuc);


//            if (cmdThem.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("Thêm thành công!");
//            }
//            else
//            {
//                MessageBox.Show("Thêm thất bại!");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//        dataGV_sanPham.DataSource = loaddl_SanPham();
//        data_GV_timKiem.DataSource = loaddl_SanPham();
//    }

//    private void btnXoa_Sp_Click_1(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmdXoa = new SqlCommand("tp_XoaSanPham", connect);
//            cmdXoa.CommandType = CommandType.StoredProcedure;

//            SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);
//            cmdXoa.Parameters.Add(ma);

//            if (cmdXoa.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("Xóa thành công ! ");
//            }
//            else
//            {
//                MessageBox.Show("Xóa thất bại ! ");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//        dataGV_sanPham.DataSource = loaddl_SanPham();
//    }

//    private void btnSua_Sp_Click_1(object sender, EventArgs e)
//    {
//        try
//        {
//            // Kiểm tra nếu người dùng nhập đủ thông tin
//            if (string.IsNullOrWhiteSpace(txtMa_sp.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
//            {
//                MessageBox.Show("Vui lòng nhập đủ mã sản phẩm, đơn giá và số lượng.");
//                return;
//            }




//            // Tính thành tiền
//            double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

//            // Tiến hành sửa sản phẩm trong cơ sở dữ liệu
//            connect.Open();
//            SqlCommand cmdSua = new SqlCommand("tp_SuaSanPham", connect);
//            cmdSua.CommandType = CommandType.StoredProcedure;

//            // Thêm các tham số vào câu lệnh
//            cmdSua.Parameters.Add(new SqlParameter("@MaSanPham", txtMa_sp.Text));   // Mã sản phẩm
//            cmdSua.Parameters.Add(new SqlParameter("@TenSanPham", txtTenSp.Text));   // Tên sản phẩm
//            cmdSua.Parameters.Add(new SqlParameter("@SoLuong", txtSoLuong.Text));            // Số lượng
//            cmdSua.Parameters.Add(new SqlParameter("@DonGia", txtDonGia.Text));              // Đơn giá
//            cmdSua.Parameters.Add(new SqlParameter("@ThanhTien", thanhTien));        // Thành tiền
//            cmdSua.Parameters.Add(new SqlParameter("@DanhMuc", cbDanhMuc_Sp.Text));    // Danh mục

//            // Kiểm tra kết quả thực thi
//            cmdSua.ExecuteNonQuery();

//            MessageBox.Show("Cập nhật sản phẩm thành công!");
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show("Lỗi: " + ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }

//        // Load lại dữ liệu
//        dataGV_sanPham.DataSource = loaddl_SanPham();
//    }

//    private void btnLamMoi_Sp_Click_2(object sender, EventArgs e)
//    {
//        dataGV_sanPham.DataSource = loaddl_SanPham();


//        txtMa_sp.Clear();
//        txtTenSp.Clear();
//        txtSoLuong.Clear();
//        txtDonGia.Clear();
//        txtThanhTien.Clear();
//    }

//    private void rad_TK_Ma_CheckedChanged_1(object sender, EventArgs e)
//    {
//        txt_TK_MaSP.Enabled = rad_TK_Ma.Checked;
//        txt_TK_Ten.Enabled = false;
//        cmb_TK_DanhMuc.Enabled = false;
//        txt_TK_MaSP.Clear();
//        txt_TK_Ten.Clear();
//        cmb_TK_DanhMuc.SelectedIndex = 0;
//    }

//    private void rad_TK_Ten_Click(object sender, EventArgs e)
//    {
//        txt_TK_Ten.Enabled = rad_TK_Ten.Checked;
//        txt_TK_MaSP.Enabled = false;
//        cmb_TK_DanhMuc.Enabled = false;
//        txt_TK_MaSP.Clear();
//        txt_TK_Ten.Clear();
//        cmb_TK_DanhMuc.SelectedIndex = 0;
//    }

//    private void rad_TK_DanhMuc_CheckedChanged_1(object sender, EventArgs e)
//    {
//        txt_TK_Ten.Enabled = rad_TK_Ten.Checked;
//        txt_TK_MaSP.Enabled = false;
//        cmb_TK_DanhMuc.Enabled = false;
//        txt_TK_MaSP.Clear();
//        txt_TK_Ten.Clear();
//        cmb_TK_DanhMuc.Enabled = true;
//        cmb_TK_DanhMuc.SelectedIndex = 0;
//    }

//    private void btn_TK_timKiem_Click_1(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();

//            // Tạo lệnh SQL và thêm tham số
//            SqlCommand cmd = new SqlCommand();
//            cmd.Connection = connect;

//            // Kiểm tra điều kiện tìm kiếm và thực hiện theo từng loại
//            if (!string.IsNullOrWhiteSpace(txt_TK_MaSP.Text))
//            {
//                cmd.CommandText = "sp_timKiem_MaSanPham";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@MaSanPham", txt_TK_MaSP.Text);
//            }
//            else if (!string.IsNullOrWhiteSpace(txt_TK_Ten.Text))
//            {
//                cmd.CommandText = "sp_timKiem_TenSP";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@TenSanPham", txt_TK_Ten.Text);
//            }
//            else if (!string.IsNullOrWhiteSpace(cmb_TK_DanhMuc.Text))
//            {
//                cmd.CommandText = "sp_timKiem_DanhMuc";
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@DanhMuc", cmb_TK_DanhMuc.Text);
//            }
//            else
//            {
//                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.");
//                return;
//            }


//            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//            DataTable dt = new DataTable();
//            adapter.Fill(dt);


//            data_GV_timKiem.DataSource = dt;


//            if (dt.Rows.Count == 0)
//            {
//                MessageBox.Show("Không tìm thấy sản phẩm nào.");
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show("Lỗi: " + ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//    }

//    private void btn_TK_LamMoi_Click_1(object sender, EventArgs e)
//    {
//        txt_TK_MaSP.Clear();
//        txt_TK_Ten.Clear();
//        cmb_TK_DanhMuc.SelectedIndex = -1;


//        data_GV_timKiem.DataSource = loaddl_SanPham();


//        MessageBox.Show("Dữ liệu đã được làm mới!");
//    }

//    private void dgv_HDxuat_Click(object sender, EventArgs e)
//    {
//        int dong = dgv_HDxuat.CurrentCell.RowIndex;
//        txt_maHDxuat.Text = dgv_HDxuat.Rows[dong].Cells[0].Value.ToString();
//        txt_mSP_cuahang_HDxuat.Text = dgv_HDxuat.Rows[dong].Cells[1].Value.ToString();
//        txt_machHDxuat.Text = dgv_HDxuat.Rows[dong].Cells[2].Value.ToString();
//        txt_maNV_HDxuat.Text = dgv_HDxuat.Rows[dong].Cells[3].Value.ToString();
//        txt_soluong_cuahang_HDxuat.Text = dgv_HDxuat.Rows[dong].Cells[4].Value.ToString();
//        object cellValue = dgv_HDxuat.Rows[dong].Cells[5].Value;
//        if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime parsedDate))
//        {
//            // Gán giá trị đã chuyển đổi cho DateTimePicker
//            date_dateXuat_hdxuat.Value = (DateTime)cellValue;
//        }

//    }

//    private void btn_xuathang_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            connect.Open();
//            SqlCommand cmd = new SqlCommand("them_HDxuat",connect);
//            cmd.CommandType = CommandType.StoredProcedure;

//            SqlParameter mahd = new SqlParameter("@mahd", txt_maHDxuat.Text);
//            SqlParameter masp = new SqlParameter("@masp", txt_mSP_cuahang_HDxuat.Text);
//            SqlParameter mach = new SqlParameter("@mach", txt_machHDxuat.Text);
//            SqlParameter mabv = new SqlParameter("@manv", txt_maNV_HDxuat.Text);
//            SqlParameter soluong = new SqlParameter("@soluong", txt_soluong_cuahang_HDxuat.Text);
//            SqlParameter ngayxuat = new SqlParameter("@ngayxuat", date_dateXuat_hdxuat.Value.ToString());

//            cmd.Parameters.Add(mahd);
//            cmd.Parameters.Add(masp);
//            cmd.Parameters.Add(mach);
//            cmd.Parameters.Add(soluong);
//            cmd.Parameters.Add(ngayxuat);
//            cmd.Parameters.Add(mabv);

//            if (cmd.ExecuteNonQuery() > 0)
//            {
//                MessageBox.Show("them thanh cong ");
//            }
//            else
//            {
//                MessageBox.Show("them that bai ");
//            }

//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message);
//        }
//        finally
//        {
//            connect.Close();
//        }
//        dgv_HDxuat.DataSource = loaddl_HDxuat();
//    }

//    private void app_SanPham_DoubleClick(object sender, EventArgs e)
//    {



//    }
//private void hienthi_sp()
//{
//    f_sanpham f_Sanpham = new f_sanpham();
//    f_Sanpham.TopLevel = false;
//    f_Sanpham.FormBorderStyle = FormBorderStyle.None;
//    f_Sanpham.Dock = DockStyle.Fill;

//    panel_sanpham.Controls.Clear();
//    panel_sanpham.Controls.Add(f_Sanpham);

//    f_Sanpham.Show();
//}
//}
//}

