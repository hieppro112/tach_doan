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
    public partial class form_report_hdxuat : Form
    {
        private string ma_HDxuat;
        public form_report_hdxuat(string ma)
        {
            InitializeComponent();
            ma_HDxuat = ma;
        }

        private void form_report_hdxuat_Load(object sender, EventArgs e)
        {
            report_maHD rp = new report_maHD();
            ParameterValues parameterValue = new ParameterValues();
            ParameterDiscreteValue paravl = new ParameterDiscreteValue();

            paravl.Value = ma_HDxuat;
            parameterValue.Add(paravl);
            rp.DataDefinition.ParameterFields["@maHD"].ApplyCurrentValues(parameterValue);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
