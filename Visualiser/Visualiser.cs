namespace Visualiser
{
    public partial class Visualiser : Form
    {
        public Visualiser()
        {
            InitializeComponent();
        }

        private void btnPlot_ButtonClick(object sender, EventArgs e)
        {
            /*List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            for (double x = -5; x < 5; x += 0.01)
            {
                double y = Math.Pow(x, 2) + 3 * x + 3;
                xValues.Add(x);
                yValues.Add(y);
            }

            formsPlot1.Plot.AddScatterLines(xValues.ToArray(), yValues.ToArray());
            formsPlot1.Refresh();

            xValues.Clear();
            yValues.Clear();

            for (double x = -5; x < 5; x += 0.01)
            {
                double y = Math.Pow(x, 3) + 3 * x + 3;
                xValues.Add(x);
                yValues.Add(y);
            }

            formsPlot2.Plot.AddScatterLines(xValues.ToArray(), yValues.ToArray());
            formsPlot2.Refresh();

            xValues.Clear();
            yValues.Clear();

            for (double x = -5; x < 5; x += 0.01)
            {
                double y = Math.Pow(x, 4) + 3 * x + 3;
                xValues.Add(x);
                yValues.Add(y);
            }

            formsPlot3.Plot.AddScatterLines(xValues.ToArray(), yValues.ToArray());
            formsPlot3.Refresh();

            xValues.Clear();
            yValues.Clear();

            for (double x = -5; x < 5; x += 0.01)
            {
                double y = Math.Pow(x, 4) + 3 * x + 3;
                xValues.Add(x);
                yValues.Add(y);
            }

            formsPlot4.Plot.AddScatterLines(xValues.ToArray(), yValues.ToArray());
            formsPlot4.Refresh();
            */
        }

        private void Visualiser_Load(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // browse for the CSV file
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "CSV files|*.csv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // load the CSV file
                string[] lines = File.ReadAllLines(dlg.FileName);
                List<double> xValues = new List<double>();
                List<double> yValues = new List<double>();
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    double x = double.Parse(parts[0]);
                    double y = double.Parse(parts[1]);

                    xValues.Add(x);
                    yValues.Add(y);
                }



                // create a new scottplot forms plot thing
                ScottPlot.FormsPlot graph = new ScottPlot.FormsPlot();
                tableLayoutPanel1.Controls.Add(graph);
                graph.Dock = DockStyle.Fill;

                // display
                graph.Plot.AddScatter(xValues.ToArray(), yValues.ToArray());
                graph.Plot.Title(dlg.SafeFileName);
                graph.Refresh();
            }


        }
    }
}