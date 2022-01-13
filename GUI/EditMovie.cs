using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieCRUD.GUI
{
    public partial class EditMovie : Form
    {
        public string _movId;
        private readonly MainMenu _parent;
        public EditMovie(string movId, MainMenu parent)
        {
            InitializeComponent();
            _parent = parent;
            _movId = movId;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtRilis.CustomFormat = "yyyy/dd/MM";
            Kelas.Movie mov = new Kelas.Movie(_movId, textBox1.Text.Trim(), textBox2.Text.Trim(), dtRilis.Value.Date);
            if (MessageBox.Show("Are you sure want to update!!!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Kelas.Koneksi.UpdateMovie(mov, _movId);
                _parent.Display();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
