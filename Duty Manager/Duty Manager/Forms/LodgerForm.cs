using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Duty_Manager
{
    public partial class LodgerForm : Form
    {
        private Duty_Manager.Forms.LodgerListView listView1;
        public LodgerForm()
        {
            
            InitializeComponent();    
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void LodgerForm_Load(object sender, System.EventArgs e)
        {
        }

    }
}
