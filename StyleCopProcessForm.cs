using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StyleCopProcess
{
    public partial class StyleCopProcessForm : Form
    {
        private StyleCopProcessModel _model;

        public StyleCopProcessForm(StyleCopProcessModel model)
        {
            InitializeComponent();
            _model = model;
        }

        // click process button
        private void ClickProcessButton(object sender, EventArgs e)
        {
            _saveFileDialog.Filter = "ReviewPal File | *.html";
            _saveFileDialog.DefaultExt = "html";
            System.Windows.Forms.DialogResult result = _saveFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    _model.process(_saveFileDialog.FileName, _warningMessageTextBox.Text);
                    _warningMessageTextBox.Text = "";
                    MessageBox.Show("Process OK");
                }
                catch
                {
                    MessageBox.Show("Input Invalid");
                }
            }
        }
    }
}
