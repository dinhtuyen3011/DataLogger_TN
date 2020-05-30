using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLogger
{
    public partial class GetValueToSaveData : Form
    {

        public GetValueToSaveData()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.ShowUpDown = true;

        }
        public DateTime timeToSave { get; private set; }


        private void GetValueToSaveData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DateTime.Compare(DateTime.Now, dateTimePicker1.Value) > 0)
            {
                MessageBox.Show("Bạn đang chọn thời gian trong quá khứ");
                e.Cancel = true;

            }
            else
            {
                e.Cancel = false;
            }
        }
        private void GetValueToSaveData_FormClosed(object sender, FormClosedEventArgs e)
        {
            timeToSave = dateTimePicker1.Value;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
