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
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QDFNGC7\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
       SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");


        public DataTable LoadDuLieuDangKy()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdDangKy = new SqlCommand("tp_xemDangKy", conn);
                cmdDangKy.CommandText = "tp_xemDangKy";
                cmdDangKy.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter daDangKy = new SqlDataAdapter(cmdDangKy);

                daDangKy.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            them_account();
            
            
        }
        private void them_account() {
            try
            {
                conn.Open();
                if(txtTenDangNhap.Text.Length<7 || txtTenDangNhap.Text.Length > 50)
                {
                    MessageBox.Show("Tên đăng nhập phải từ 7 đến 50 ký tự ! ");
                    return;
                }
                if (!KiemTraMatKhau(txtPass.Text))
                {
                    MessageBox.Show("Mật khẩu phải ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường và số!");
                    return;
                }

                SqlCommand cmdthemTaiKhoan = new SqlCommand("tp_ThemTaiKhoan", conn);
                cmdthemTaiKhoan.CommandType = CommandType.StoredProcedure;

                //them bien
                SqlParameter paTen = new SqlParameter("@tenDangNhap", txtTenDangNhap.Text);
                //them vao commnand
                cmdthemTaiKhoan.Parameters.Add(paTen);

                SqlParameter paMK = new SqlParameter("@matKhau", txtPass.Text);
                cmdthemTaiKhoan.Parameters.Add(paMK);

                SqlParameter paHoTen = new SqlParameter("@hoTen", txtHoTen.Text);
                cmdthemTaiKhoan.Parameters.Add(paHoTen);

                SqlParameter paEmail = new SqlParameter("@email", txtEmail.Text);
                cmdthemTaiKhoan.Parameters.Add(paEmail);

                SqlParameter paVaiTro = new SqlParameter("@vaiTro", cbVaitro.Text);
                cmdthemTaiKhoan.Parameters.Add(paVaiTro);

                SqlParameter paNgayTao = new SqlParameter("@ngayTao", dateNgayTao.Value);
                cmdthemTaiKhoan.Parameters.Add(paNgayTao);

                //thucthi
                if (cmdthemTaiKhoan.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Dang ky thanh cong");

                }
                else
                {
                    MessageBox.Show("Dang ky that bai");
                }

            }
            catch (SqlException ex)
            {
                // Kiểm tra mã lỗi SQL
                if (ex.Number == 2627 || ex.Number == 2601) // Mã lỗi UNIQUE KEY
                {
                    MessageBox.Show("Lỗi: Tên tài khoản đã tồn tại!");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                

                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
        // kiểm tra mk
        private bool KiemTraMatKhau(string matKhau)
        {
            if (matKhau.Length < 8) return false;
            bool coChuHoa = false, coChuThuong = false, coSo = false;

            foreach (char kyTu in matKhau)
            {
                if (char.IsUpper(kyTu)) coChuHoa = true;
                if (char.IsLower(kyTu)) coChuThuong = true;
                if (char.IsDigit(kyTu)) coSo = true;
            }

            return coChuHoa && coChuThuong && coSo;
        }
        private void FormDangKy_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?"
                , "Xác nhận thoát"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(thoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormDangKy_Load_1(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtPass.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            dateNgayTao.Value = DateTime.Now;
            cbVaitro.SelectedIndex = 0;
        }
    }
}
