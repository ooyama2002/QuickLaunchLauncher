using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Config = QuickLaunchLauncher.Form1.Config;

namespace QuickLaunchLauncher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Form1 _target;

        public void SetTarget(Form1 target)
        {
            this._target = target;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int workingAreaHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int workingAreaWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Left = workingAreaWidth / 2 - this.Width / 2;
            this.Top = workingAreaHeight / 2 - this.Height / 2;

            string h = _target.FormConfig.Horizontal.ToString();
            string v = _target.FormConfig.Vertical.ToString();

            ((RadioButton)grpPosition.Controls["rdo_" + h + "_" + v]).Checked = true;

            foreach (string b in Enum.GetNames(typeof(Config.EnumBackground)))
            {
                cmbBackground.Items.Add(b);
            }

            cmbBackground.Text = _target.FormConfig.Background.ToString();

            rdo_Left_Top.CheckedChanged += rdoPostions_CheckedChanged;
            rdo_Center_Top.CheckedChanged += rdoPostions_CheckedChanged;
            rdo_Right_Top.CheckedChanged += rdoPostions_CheckedChanged;
            rdo_Left_Bottom.CheckedChanged += rdoPostions_CheckedChanged;
            rdo_Center_Bottom.CheckedChanged += rdoPostions_CheckedChanged;
            rdo_Right_Bottom.CheckedChanged += rdoPostions_CheckedChanged;
            cmbBackground.SelectedIndexChanged += cmbBackground_SelectedIndexChanged;
        }

        private void rdoPostions_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;
            string[] nameArray = ((RadioButton)sender).Name.Split('_');
            Config.EnumHorizontal h = (Config.EnumHorizontal)Enum.Parse(typeof(Config.EnumHorizontal), nameArray[1]);
            Config.EnumVertical v = (Config.EnumVertical)Enum.Parse(typeof(Config.EnumVertical), nameArray[2]);
            _target.FormConfig.SetPosition(h, v, true);
        }

        private void cmbBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.EnumBackground b = (Config.EnumBackground)Enum.Parse(typeof(Config.EnumBackground), cmbBackground.Text);
            _target.FormConfig.SetBackground(b, true);
        }
    }
}
