using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MovieCRUD
{
    
    public partial class MainMenu : Form
    {
        private static Random random = new Random();
        public string movIdSend;
        Kelas.Koneksi koneksi = new Kelas.Koneksi();
        public MainMenu()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Kelas.Koneksi.DisplaySearch("SELECT * FROM tblmovie", gridMovie);
        }

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kelas.Movie mov = new Kelas.Movie(RandomString(10), txtJudul.Text.Trim(), txtGenre.Text.Trim(), dtRilis.Value.Date);
            Kelas.Koneksi.AddMovie(mov);
            Display();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Kelas.Koneksi.DisplaySearch("SELECT movTitle, movGenre, movDate FROM tblmovie WHERE movTitle LIKE '%"+ txtSearch.Text +"%'", gridMovie);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void gridMovie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                movIdSend = gridMovie.Rows[e.RowIndex].Cells[2].Value.ToString();
                GUI.EditMovie editMovie = new GUI.EditMovie(movIdSend, this);
                editMovie.ShowDialog();
            }
            if(e.ColumnIndex == 1)
            {
                if(MessageBox.Show("Are you sure want to delete!!!", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Kelas.Koneksi.DeleteMovie(gridMovie.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }


        private void actorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actor_List actor_List = new Actor_List();
            actor_List.Show();
            this.Hide();
        }

        private void directorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectorList directorList = new DirectorList();
            directorList.Show();
            this.Hide();
        }

        private void detailMovieListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailMovie detailMovie = new DetailMovie();
            detailMovie.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtJudul.Text = txtGenre.Text = string.Empty;
        }
    }
}
