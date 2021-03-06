﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9 {
	public partial class CalcWindow : Form {

		const int NO_ITEMS = 1000000000;

		public CalcWindow() {
			InitializeComponent();
		}

		private void DisableButtons() {
			btnSynchronous.Enabled = btnThread.Enabled = btnTask.Enabled = btnAwaitAsync.Enabled = false;
		}

		private void EnableButtons() {
			btnSynchronous.Enabled = btnThread.Enabled = btnTask.Enabled = btnAwaitAsync.Enabled = true;
		}

		private long CalcSum1() {
			long sum = 0;
			for (int i = 0; i < NO_ITEMS; i++)
				sum += i;
			return sum;
		}
        private Task<long> CalcSum2()
        {
            return Task.Factory.StartNew(()=> { return CalcSum1(); });
        }

        private void SynchronousButtonHandler(object sender, EventArgs e) {
			txtResult.Text = "";
			DisableButtons();

			txtResult.Text = CalcSum1().ToString();

			EnableButtons();
		}

		private void ThreadButtonHandler(object sender, EventArgs e) {
            txtResult.Text = "";
            DisableButtons();

            Thread thread = new Thread(() => {
                long sum = CalcSum1();

                txtResult.Invoke(new Action(()=> { txtResult.Text = sum.ToString(); }));
                EnableButtons();
            });

            thread.Start();
        }

		private void TaskButtonHandler(object sender, EventArgs e) {
            DisableButtons();

            // Access to UI thread managed obbjects not possible per default
            Task<long> calcTask = Task.Factory.StartNew(() => {
                return CalcSum1();
            });

            // synchroniztaion context so task can access the other threads objects
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            calcTask.ContinueWith((sum)=> {
                txtResult.Text = sum.Result.ToString();
                EnableButtons();
            }, uiScheduler);
		}

        private async void AwaitAsyncButtonHandler(object sender, EventArgs e)
        {
            txtResult.Text = "";
            DisableButtons();

            // Leaves this method right after taks start
            var result = await CalcSum2();
            // Returns to here after task is done with the same context asit was before the start.
            txtResult.Text = result.ToString();

            EnableButtons();
        }
    }
}
