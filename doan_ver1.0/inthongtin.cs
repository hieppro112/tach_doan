using CrystalDecisions.Shared;
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
    public partial class inthongtin : Form
    {
        private string ma_nvl;
        public inthongtin(string manv)
        {
            InitializeComponent();
            ma_nvl = manv;
        }
        //SqlConnection connect = new SqlConnection("Data Source=LAPTOP-BA92BEJG\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");


        private void inthongtin_Load(object sender, EventArgs e)
        {
            thongtinnhanvien nhanvien = new thongtinnhanvien();
            ParameterValues pvalue = new ParameterValues();
            ParameterDiscreteValue pDis = new ParameterDiscreteValue();

            pDis.Value = ma_nvl;
            pvalue.Add(pDis);
            nhanvien.DataDefinition.ParameterFields["@user"].ApplyCurrentValues(pvalue);
            crystalReportViewer1.ReportSource=nhanvien;
        }
    }
}
