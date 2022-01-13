using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MovieCRUD
{
    public partial class DetailMovie : Form
    {
        public void Display()
        {
            Kelas.Koneksi.DisplaySearch("SELECT tblactor.actName, tblactor.actGender, tbldirector.dirName, tbldirector.dirGender, tblmovie.movTitle, tblmovie.movGenre, tblmovie.movDate FROM tblactor INNER JOIN tblmovie ON tblmovie.movId = tblactor.movId INNER JOIN tbldirector ON tbldirector.movId = tblmovie.movId", gridMovie);
        }
        public DetailMovie()
        {
            InitializeComponent();
            this.Display();
        }

        private void movieListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Kelas.Koneksi.DisplaySearch("SELECT tblactor.actName, tblactor.actGender, tbldirector.dirName, tbldirector.dirGender, tblmovie.movTitle, tblmovie.movGenre, tblmovie.movDate FROM tblactor INNER JOIN tblmovie ON tblmovie.movId = tblactor.movId INNER JOIN tbldirector ON tbldirector.movId = tblmovie.movId WHERE tblactor.actName LIKE '%" + txtSearch.Text + "%'", gridMovie);
        }
    }
}
