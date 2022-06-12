using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTestTaskCancel.Services.Contracts;

namespace WinFormsTestTaskCancel.Forms
{
    public partial class Form2 : Form
    {
        private readonly ITestService _testService;
        public Form2(ITestService testService)
        {
            InitializeComponent();
            _testService = testService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var txt = _testService.GetIp();
            this.label1.Text = txt;
        }
    }
}
