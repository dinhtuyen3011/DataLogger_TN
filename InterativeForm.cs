using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DataLogger.Model;

namespace DataLogger
{
    public partial class InterativeForm : Form
    {
        private List<OldData> dataInteract = new List<OldData>();

        private readonly static string CHANEL1 = "Kênh 1";
        private readonly static string CHANEL2 = "Kênh 2";
        private readonly static string CHANEL3 = "Kênh 3";
        private readonly static string CHANEL4 = "Kênh 4";
        
        private readonly static string ADD = "+";
        private readonly static string SUB = "-";
        private readonly static string MULTI = "*";
        private string argument1 = "";
        private string argument2 = "";

        public string filePath;
        private List<string> chanels = new List<string>() { CHANEL1, CHANEL2, CHANEL3, CHANEL4 };
        private List<string> operands = new List<string>() { ADD, SUB, MULTI };
        public List<OldData> result = new List<OldData>();
        public string nameOfFunction = "";
        //public List<double> result = new List<double>();


        public InterativeForm(string csvPath = "")
        {
            filePath = csvPath;
            InitializeComponent();
        }
        private void readCSV()
        {
            try
            {
                List<string[]> rows = File.ReadAllLines(filePath).Select(x => x.Split(',')).ToList();

                rows.RemoveAt(0);

                for (int i = 0; i < rows.Count(); i++)
                {
                    for (int j = 1; j < rows[i].Length; j++)
                    {
                        dataInteract.Add(new OldData()
                        {

                            oldTime = Convert.ToDateTime(rows[i][0]),
                            Chanel = chanels[j - 1],
                            Value = float.Parse(rows[i][j])
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Operate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            argument1 = chanels.Where(idx => idx == Operate1_combobox.SelectedItem).ToArray()[0];

        }
        private string opr = "";
        private void Operand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            //do something
            opr = operands.Where(idx => idx == Operand_combobox.SelectedItem).ToArray()[0];
        }
        private void Operate2_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            argument2 = chanels.Where(idx => idx == Operate2_combobox.SelectedItem).ToArray()[0];


        }
        private void calculate(string arg1 = "", string op = "", string arg2 = "", bool all = false)
        {

            if (!all && arg1 != "" && arg2 != "")
            {
                var data = dataInteract.Where(d => d.Chanel == arg1).ToList();
                var data1 = dataInteract.Where(d => d.Chanel == arg2).ToList();
                if (op == "+")
                {
                    for (int i = 0; i < data.Count - 1; i++)
                    {
                        result.Add(new OldData()
                        {
                            oldTime = data[i].oldTime,
                            Value = Math.Round(data[i].Value + data1[i].Value, 3),
                            Chanel = "INTERACTIVE"
                        });
                    }
                }
                if (op == "-")
                {
                    for (int i = 0; i < data.Count - 1; i++)
                    {
                        result.Add(new OldData()
                        {
                            oldTime = data[i].oldTime,
                            Value = Math.Round(data[i].Value - data1[i].Value, 3),
                            Chanel = "INTERACTIVE"
                        });
                    }
                }
                if (op == "*")
                {
                    for (int i = 0; i < data.Count - 1; i++)
                    {
                        result.Add(new OldData()
                        {
                            oldTime = data[i].oldTime,
                            Value = Math.Round(data[i].Value * data1[i].Value, 3),
                            Chanel = "INTERACTIVE"
                        });
                    }
                }
            }
        }


        private void creatCombobox()
        {
            Operate1_combobox.DropDownStyle = ComboBoxStyle.DropDown;
            Operate1_combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Operate1_combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Operate1_combobox.ValueMember = "Id";
            Operate1_combobox.DisplayMember = "Name";

            Operand_combobox.DropDownStyle = ComboBoxStyle.DropDown;
            Operand_combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Operand_combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Operand_combobox.ValueMember = "Id";
            Operand_combobox.DisplayMember = "Name";

            Operate2_combobox.DropDownStyle = ComboBoxStyle.DropDown;
            Operate2_combobox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Operate2_combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
            Operate2_combobox.ValueMember = "Id";
            Operate2_combobox.DisplayMember = "Name";

            chanels.ForEach(idx => Operate1_combobox.Items.Add(idx));
            chanels.ForEach(idx => Operate2_combobox.Items.Add(idx));
            operands.ForEach(idx => Operand_combobox.Items.Add(idx));
        }
        private void InterativeForm_Load(object sender, EventArgs e)
        {
            readCSV();
            creatCombobox();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            calculate(argument1, opr, argument2);
            //nameOfFunction = Operate1_combobox.SelectedItem.ToString()+Operand_combobox.SelectedItem.ToString()+Operate2_combobox.SelectedItem.ToString();
            Close();
        }

        private void InterativeForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
    
}
