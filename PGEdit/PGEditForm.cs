using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PanzerGeneralEdit {
	public partial class PGEditForm : Form {
		public PGEditForm() {
			InitializeComponent();
			create_object_message();
		}

		private void textBox4_TextChanged(object sender, EventArgs e) {

		}

		private void button1_Click(object sender, EventArgs e) {
			change_to_prev();
		}

		private void button2_Click(object sender, EventArgs e) {
			change_to_next();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			change_unit( lb_unit.SelectedIndex );
		}

		private void FileToolStripMenuItem_Click(object sender, EventArgs e) {
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				init_the_reader( openFileDialog1.FileName );
			}
		}

		private void label2_Click(object sender, EventArgs e) {

		}

		private void label9_Click(object sender, EventArgs e) {

		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void textBox7_TextChanged(object sender, EventArgs e) {

		}

		private void button3_Click(object sender, EventArgs e) {
			apply_modify();
			lb_unit.Items[cur_i] = tb_name.Text;
		}

		private void tb_TextChanged(object sender, EventArgs e) {
			store_button.Enabled = true;
		}

		private void EndToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void tb_MouseHover(object sender, EventArgs e) {
			proc_mouse_hover( sender );
		}

		private void tb_MouseLeave(object sender, EventArgs e) {
			proc_mouse_leave( sender );
		}

		private void tb_Enter(object sender, EventArgs e) {
			proc_mouse_hover( sender );
		}
	}
}
