using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public class LoadingButton : Form1
    {
        private Label lblLoading;

        public LoadingButton()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Loading Animation Example";
            this.Size = new System.Drawing.Size(750, 500);

            lblLoading = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(150, 200),
                Text = ""
            };

            this.Controls.Add(lblLoading);

            // Adding event handlers to existing buttons
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Click += async (sender, e) => await ShowLoadingAsync();
                }
            }
        }

        private async Task ShowLoadingAsync()
        {
            lblLoading.Text = "Loading...";
            await Task.Delay(2000); // Simulate a loading delay
            lblLoading.Text = "";
        }
    }
}
