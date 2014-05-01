using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Duty_Manager.Forms
{
    class LodgerListView : ListView 
    {

        private ListViewItem li;
        private int X = 0;
        private int Y = 0;
        private string subItemText;
        private int subItemSelected = 0;

        List<Lodger> lodgers;
        List<Duty> duties;
        private System.Windows.Forms.TextBox editBox = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.ComboBox cmbBox = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;

        public LodgerListView()
		{
            duties = DutyParser.LoadDuties();
            foreach (Duty d in duties)
            {
                cmbBox.Items.Add(d.Description);
            }

            cmbBox.Size = new System.Drawing.Size(0, 0);
            cmbBox.Location = new System.Drawing.Point(0, 0);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.cmbBox });
            cmbBox.SelectedIndexChanged += new System.EventHandler(this.CmbSelected);
            cmbBox.LostFocus += new System.EventHandler(this.CmbFocusOver);
            cmbBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbKeyPress);
            cmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            cmbBox.BackColor = Color.SkyBlue;
            cmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBox.Hide();

            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();

            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																			this.columnHeader1,
																			this.columnHeader2,
																			this.columnHeader3,
																			this.columnHeader4});

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SMKMouseDown);
            this.DoubleClick += new System.EventHandler(this.SMKDoubleClick);

            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Floor";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kitchen";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 700;

            editBox.Size = new System.Drawing.Size(0, 0);
            editBox.Location = new System.Drawing.Point(0, 0);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.editBox });
            editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
            editBox.LostFocus += new System.EventHandler(this.FocusOver);
            editBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            editBox.BackColor = Color.LightYellow;
            editBox.BorderStyle = BorderStyle.Fixed3D;
            editBox.Hide();
            editBox.Text = "";

            lodgers = LodgerParser.LoadLodgers();
            foreach (Lodger l in lodgers)
            {
                ListViewItem item1 = new ListViewItem(l.Name);
                item1.SubItems.Add(l.FloorNumber.ToString());
                item1.SubItems.Add(getKitchen(l));
                item1.SubItems.Add(getDuty(l, duties));
                this.Items.Add(item1);
            }
        }

        private string getKitchen(Lodger l)
        {
            if (l.IsKitchen == 0)
                return "no";
            else
                return "yes";
        }
        private string getDuty(Lodger l, List<Duty> duties)
        {
            foreach (Duty d in duties)
            {
                if (d.DutyId == l.PresetDuty)
                    return d.Description;
            }
            return "none";
        }

        private void CmbKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 27)
            {
                cmbBox.Hide();
            }
        }

        private void CmbSelected(object sender, System.EventArgs e)
        {
            int sel = cmbBox.SelectedIndex;
            if (sel >= 0)
            {
                string itemSel = cmbBox.Items[sel].ToString();
                li.SubItems[subItemSelected].Text = itemSel;
            }
        }

        private void CmbFocusOver(object sender, System.EventArgs e)
        {
            cmbBox.Hide();
        }

        private void EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( e.KeyChar == 13 ) 
			{
				li.SubItems[subItemSelected].Text = editBox.Text;
				editBox.Hide();
			}

			if ( e.KeyChar == 27 ) 
				editBox.Hide();
		}

		private void FocusOver(object sender, System.EventArgs e)
		{
			li.SubItems[subItemSelected].Text = editBox.Text;
			editBox.Hide();
		}

		public  void SMKDoubleClick(object sender, System.EventArgs e)
		{
			// Check the subitem clicked .
			int nStart = X ;
			int spos = 0 ; 
			int epos = this.Columns[0].Width ;
			for ( int i=0; i < this.Columns.Count ; i++)
			{
				if ( nStart > spos && nStart < epos ) 
				{
					subItemSelected = i ;
					break; 
				}
				
				spos = epos ; 
				epos += this.Columns[i].Width;
			}

			Console.WriteLine("SUB ITEM SELECTED = " + li.SubItems[subItemSelected].Text);
			subItemText = li.SubItems[subItemSelected].Text ;

			string colName = this.Columns[subItemSelected].Text ;
			if ( colName == "Continent" ) 
			{
				Rectangle r = new Rectangle(spos , li.Bounds.Y , epos , li.Bounds.Bottom);
				cmbBox.Size  = new System.Drawing.Size(epos - spos , li.Bounds.Bottom-li.Bounds.Top);
				cmbBox.Location = new System.Drawing.Point(spos , li.Bounds.Y);
				cmbBox.Show() ;
				cmbBox.Text = subItemText;
				cmbBox.SelectAll() ;
				cmbBox.Focus();
			}
			else
			{
				Rectangle r = new Rectangle(spos , li.Bounds.Y , epos , li.Bounds.Bottom);
				editBox.Size  = new System.Drawing.Size(epos - spos , li.Bounds.Bottom-li.Bounds.Top);
				editBox.Location = new System.Drawing.Point(spos , li.Bounds.Y);
				editBox.Show() ;
				editBox.Text = subItemText;
				editBox.SelectAll() ;
				editBox.Focus();
			}
		}

		public void SMKMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			li = this.GetItemAt(e.X , e.Y);
			X = e.X ;
			Y = e.Y ;
		}


    }
}
