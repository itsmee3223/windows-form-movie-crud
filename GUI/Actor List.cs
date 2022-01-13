using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;

namespace MovieCRUD
{
    public partial class Actor_List : Form
    {
        private static Random random = new Random();
        string movId, actId;
        public void getMovie()
        {
            using (MySqlConnection con = Kelas.Koneksi.getConn())
            {
                var query = "SELECT movTitle FROM tblmovie";
                using (var command = new MySqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("movTitle"));
                        }
                    }
                }
            }
        }
        public Actor_List()
        {
            InitializeComponent();
            Display();
            getMovie();
        }

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void movieListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu mainmenu = new MainMenu();
            mainmenu.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            Kelas.Koneksi.DisplaySearch("SELECT tblactor.actName, tblactor.actGender, tblmovie.movTitle, tblactor.actId FROM tblactor INNER JOIN tblmovie ON tblmovie.movId = tblactor.movId GROUP BY tblactor.actId", gridMovie);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Kelas.Koneksi.DisplaySearch("SELECT tblactor.actName, tblactor.actGender, tblmovie.movTitle, tblactor.actId FROM tblactor INNER JOIN tblmovie ON tblmovie.movId = tblactor.movId WHERE tblactor.actName LIKE '%" + txtSearch.Text + "%'" , gridMovie);
        }

        private void Actor_List_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kelas.Actor act = new Kelas.Actor(RandomString(10), txtActor.Text.Trim(), cb1.SelectedItem.ToString(), movId);
            Kelas.Koneksi.AddActors(act);
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kelas.Actor update = new Kelas.Actor(actId, txtActor.Text, cb1.SelectedItem.ToString(), movId);
            Kelas.Koneksi.UpdateActor(update, actId);
            Display();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT movId FROM tblmovie WHERE movTitle = @idddd;";

            MySqlConnection con = Kelas.Koneksi.getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@idddd", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
            try
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movId = reader.GetString("movId");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed.\n" + ex, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kelas.Koneksi.DeleteActor(actId);
            Display();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtActor.Text = cb1.Text = comboBox1.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void gridMovie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtActor.Text = gridMovie.Rows[e.RowIndex].Cells[0].Value.ToString();
            cb1.Text = gridMovie.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = gridMovie.Rows[e.RowIndex].Cells[2].Value.ToString();
            actId = gridMovie.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
