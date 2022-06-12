using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFormsTestTaskCancel.Services.Contracts;

namespace WinFormsTestTaskCancel.Forms
{
	public partial class Form1 : Form
	{
		private readonly ITestService _testService ;
        private readonly ILogger _logger;
        public Form1(ILogger<Form1> logger, ITestService testService)
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
        private CancellationTokenSource cancelToken;
        private async void button3_MouseDown(object sender, MouseEventArgs e)
        {
            cancelToken = await _testService.DoZoomIn();
        }

        private async void button3_MouseUp(object sender, MouseEventArgs e)
        {
            cancelToken.Cancel();
            cancelToken.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
