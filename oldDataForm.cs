
using DataLogger.Model;
using Serial_Oscilloscope;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataLogger
{
    public partial class oldDataForm : Form
    {
        Point? prevPosition_chart2 = null;
        ToolTip tooltip_chart2 = new ToolTip();
        ToolTip tooltip_interact = new ToolTip();
        private readonly static string CHANEL1 = "Kênh 1";
        private readonly static string CHANEL2 = "Kênh 2";
        private readonly static string CHANEL3 = "Kênh 3";
        private readonly static string CHANEL4 = "Kênh 4";
        private readonly static string INTERACTIVE = "Tương tác";

        private List<string> chanels = new List<string>() { CHANEL1, CHANEL2, CHANEL3, CHANEL4, INTERACTIVE};

        private List<OldData> oldDatas = new List<OldData>();

        public string CSV;

        public string getCSV() => CSV;

        public oldDataForm(string csvPath = "")
        {
            CSV = csvPath;

            InitializeComponent();
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            //chart2.Series[0].XValueType = ChartValueType.DateTime;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd"+ "HH:mm:ss";
            chart2.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;

            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDotDot;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart2.ChartAreas[0].CursorX.AutoScroll = true;
            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart2.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 0.5D;
            chart2.ChartAreas[0].CursorX.LineColor = Color.Gray;
            chart2.ChartAreas[0].AxisX.ScaleView.MinSize = 1;
            chart2.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
            chart2.ChartAreas[0].AxisX.Title = "Thời điểm";
            chart2.ChartAreas[0].AxisY.Title = "Điện áp (V )";
            chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
            chart2.ChartAreas[0].CursorY.AutoScroll = true;
            chart2.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorY.Interval = 0.001;
            chart2.ChartAreas[0].CursorY.LineColor = Color.Gray;
            chart2.MouseWheel += chart2_MouseWheels;
            CheckForIllegalCrossThreadCalls = false;
            
        }
        
        private void chart2_MouseWheels(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart2.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }
            }
            catch
            {
            }
            // mouseMove

            var pos = e.Location;
            if (prevPosition_chart2.HasValue && pos == prevPosition_chart2.Value)
                return;
            tooltip_chart2.RemoveAll();
            prevPosition_chart2 = pos;
            var results = chart2.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        var channel = result.Series.ToString();
                        var y_value = Math.Round(prop.YValues[0], 3);
                        tooltip_chart2.Show(channel.Remove(0,7)+", Thời điểm: " +prop.AxisLabel.ToString()+ ", Value= " + y_value, this.chart2,
                                        pos.X, pos.Y - 15);
                    }
                }
            }
            
        }
        
        private void readCSV()
        {
            List<string[]> rows = File.ReadAllLines(CSV).Select(x => x.Split(',')).ToList();

            rows.RemoveAt(0);

            for(int i = 0; i < rows.Count(); i++)
            {
                for(int j = 1; j < rows[i].Length; j ++)
                {
                    oldDatas.Add(new OldData()
                    {
                        oldTime = Convert.ToDateTime(rows[i][0]),
                        Chanel = chanels[j - 1],
                        Value = float.Parse(rows[i][j])
                    }); ;
                }
            }
        }
        private void draw(string chanel = "", bool all = false)
        {
            if(!all && chanel != "")
            {
                var data = oldDatas.Where(d => d.Chanel == chanel).ToList();
                data.ForEach(d =>
                {
                    chart2.Series[d.Chanel].Points.AddXY(d.oldTime.ToString("d-M-yyyy HH:mm:ss"), d.Value);
                    
                });
            } 
            else {
                oldDatas.ForEach(d =>
                {
                    chart2.Series[d.Chanel].Points.AddXY(d.oldTime.ToString("d-M-yyyy HH:mm:ss"), d.Value);
                });
            }

        }
        private void channel1Displays_CheckStateChanged(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            if (channel1Displays.Checked)
            {
                
                allDisplays.Checked = false;
                draw(CHANEL1);
            }
            else 
            {
                chart2.Series[0].Points.Clear();
                
            }
        }
        private void channel2Displays_CheckStateChanged(object sender, EventArgs e)
        {
            chart2.Series[1].Points.Clear();
            if (channel2Displays.Checked)
            {
                allDisplays.Checked = false;
                draw(CHANEL2);
            }
            else
            {
                chart2.Series[1].Points.Clear();
                
            }
        }
        private void channel3Displays_CheckStateChanged(object sender, EventArgs e)
        {
            chart2.Series[2].Points.Clear();
            if (channel3Displays.Checked)
            {
                allDisplays.Checked = false;
                draw(CHANEL3);
            }
            else
            {
                chart2.Series[2].Points.Clear();
                
            }
        }
        private void channel4Displays_CheckStateChanged(object sender, EventArgs e)
        {
            chart2.Series[3].Points.Clear();
            if (channel4Displays.Checked)
            {
                allDisplays.Checked = false;
                draw(CHANEL4);
            }
            else
            {
                chart2.Series[3].Points.Clear();
            }
        }
        private void allDisplays_CheckStateChanged(object sender, EventArgs e)
        {
            if (allDisplays.Checked)
            {
                channel1Displays.Checked = false;
                channel2Displays.Checked = false;
                channel3Displays.Checked = false;
                channel4Displays.Checked = false;
                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();
                chart2.Series[2].Points.Clear();
                chart2.Series[3].Points.Clear();
                draw("", true);
            }
            else
            {
                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();
                chart2.Series[2].Points.Clear();
                chart2.Series[3].Points.Clear();
            }
        }

        private void oldDataForm_Load_1(object sender, EventArgs e)
        {
            readCSV();

            chart2.Series.Clear();

            chanels.ForEach(c =>
            {
                chart2.Series.Add(c);
                chart2.Series[c].ChartType = SeriesChartType.Line;
                chart2.Series[c].Color = c == CHANEL1 ? Color.Red : c == CHANEL2 ? Color.Green : c == CHANEL3 ? Color.Blue: c==CHANEL4? Color.Brown : Color.Gray ;
                
                
            });
        }
        private void toArray()
        {
            //chanels.ForEach(c=>c==)
        }
        List<OldData> a = new List<OldData>();
        private void interactiveSelection_Click(object sender, EventArgs e)
        {
            try
            {
                InterativeForm interativeForm = new InterativeForm(CSV);
                interativeForm.ShowDialog();

                interativeForm.result.ForEach(rst =>
                {
                    chart2.Series[4].Points.AddXY(rst.oldTime.ToString("d-M-yyyy HH:mm:ss"), rst.Value);
                });
            }
            catch (Exception)
            {
                return;
            }
        }
       
    }
}
