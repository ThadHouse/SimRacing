using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimConnector;

namespace SimDisplay
{
    public partial class MainForm : Form
    {
        DataCollector _simData;
        public MainForm()
        {
            InitializeComponent();
            threadTimer.Stop();
        }

        private void threadTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
