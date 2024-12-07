﻿using System;
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
        }
        private void btnThem_Sp_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                if (string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ đơn giá và số lượng.");
                    return;
                }



                // Tính thành tiền
                double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

                // Hiển thị thành tiền lên textbox
                txtThanhTien.Text = thanhTien.ToString();

                // Tiến hành thêm sản phẩm vào cơ sở dữ liệu

                SqlCommand cmdThem = new SqlCommand("tp_ThemSanPham", connect);
                cmdThem.CommandType = CommandType.StoredProcedure;

                SqlParameter ma = new SqlParameter("@MaSanPham", txtMa_sp.Text);
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
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
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

        private void btnSua_Sp_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng nhập đủ thông tin
                if (string.IsNullOrWhiteSpace(txtMa_sp.Text) || string.IsNullOrWhiteSpace(txtDonGia.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ mã sản phẩm, đơn giá và số lượng.");
                    return;
                }




                // Tính thành tiền
                double thanhTien = double.Parse(txtDonGia.Text) * int.Parse(txtSoLuong.Text);

                // Tiến hành sửa sản phẩm trong cơ sở dữ liệu
                connect.Open();
                SqlCommand cmdSua = new SqlCommand("tp_SuaSanPham", connect);
                cmdSua.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào câu lệnh
                cmdSua.Parameters.Add(new SqlParameter("@MaSanPham", txtMa_sp.Text));   // Mã sản phẩm
                cmdSua.Parameters.Add(new SqlParameter("@TenSanPham", txtTenSp.Text));   // Tên sản phẩm
                cmdSua.Parameters.Add(new SqlParameter("@SoLuong", txtSoLuong.Text));            // Số lượng
                cmdSua.Parameters.Add(new SqlParameter("@DonGia", txtDonGia.Text));              // Đơn giá
                cmdSua.Parameters.Add(new SqlParameter("@ThanhTien", thanhTien));        // Thành tiền
                cmdSua.Parameters.Add(new SqlParameter("@DanhMuc", cbDanhMuc_Sp.Text));    // Danh mục

                // Kiểm tra kết quả thực thi
                cmdSua.ExecuteNonQuery();

                MessageBox.Show("Cập nhật sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            // Load lại dữ liệu
            dataGV_sanPham.DataSource = loaddl_SanPham();
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


            MessageBox.Show("Dữ liệu đã được làm mới!");
        }

        private void f_sanpham_Load(object sender, EventArgs e)
        {
           dataGV_sanPham.DataSource = loaddl_SanPham();
        }
    }
}
