using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsTestTaskCancel.Services.Contracts;

namespace WinFormsTestTaskCancel.Forms
{
	public partial class Form1 : Form
	{
		private readonly ITestService _testService;
        private readonly ILogger _logger;
        public Form1(ITestService testService, ILogger<Form1> logger)
        {
            InitializeComponent();
            _testService = testService;
            _logger = logger;
            _logger.LogInformation("test");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var txt = _testService.GetHelloWorld("ab");
            this.label1.Text = txt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFactory.GetForm<Form2>().ShowDialog();
        }
    }
}
