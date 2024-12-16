using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan_ver1._0
{
    public partial class form_thongtinSP_Report : Form
    {
        private string masp;
        public form_thongtinSP_Report(string ma)
        {
            InitializeComponent();
            this.masp = ma;
        }

        private void form_thongtinSP_Report_Load(object sender, EventArgs e)
        {
            XuatSP rp = new XuatSP();
            ParameterValues pa = new ParameterValues();
            ParameterDiscreteValue parameter = new ParameterDiscreteValue();

            parameter.Value = masp;
            pa.Add(parameter);
            rp.DataDefinition.ParameterFields["@MaSanPham"].ApplyCurrentValues(pa);
            crystalReportViewer1.ReportSource = rp;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
