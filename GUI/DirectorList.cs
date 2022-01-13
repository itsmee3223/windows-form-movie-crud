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
    public partial class DirectorList : Form
    {
        private static Random random = new Random();
        string movId, dirId;
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

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public DirectorList()
        {
            InitializeComponent();
            Display();
            getMovie();
        }

        private void movieListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
            this.Close();
        }

        private void actorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actor_List actor_List = new Actor_List();
            actor_List.Show();
            this.Hide();
            this.Close();
        }

        private void detailMovieListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailMovie detailMovie = new DetailMovie();
            detailMovie.Show();
            this.Hide();
            this.Close();
        }

        public void Display()
        {
            Kelas.Koneksi.DisplaySearch("SELECT tbldirector.dirName, tbldirector.dirGender, tblmovie.movTitle, tbldirector.dirId FROM tbldirector INNER JOIN tblmovie ON tblmovie.movId = tbldirector.movId GROUP BY tbldirector.dirId", gridMovie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kelas.Director Directors = new Kelas.Director(RandomString(10), textBox2.Text.Trim(), cb1.SelectedItem.ToString(), movId);
            Kelas.Koneksi.AddDirectors(Directors);
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

        private void gridMovie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = gridMovie.Rows[e.RowIndex].Cells[0].Value.ToString();
            cb1.Text = gridMovie.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = gridMovie.Rows[e.RowIndex].Cells[2].Value.ToString();
            dirId = gridMovie.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kelas.Director update = new Kelas.Director(dirId, textBox2.Text, cb1.SelectedItem.ToString(), movId);
            Kelas.Koneksi.UpdateDirector(update, dirId);
            Display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kelas.Koneksi.DeleteDirector(dirId);
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = cb1.Text = comboBox1.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Kelas.Koneksi.DisplaySearch("SELECT tbldirector.`dirName`, tbldirector.`dirGender`, tblmovie.movTitle, tbldirector.dirId FROM tbldirector INNER JOIN tblmovie ON tblmovie.movId = tbldirector.movId WHERE tbldirector.`dirName` LIKE '%" + textBox1.Text + "%'", gridMovie);
        }
    }
}
