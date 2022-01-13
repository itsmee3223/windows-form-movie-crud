using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MovieCRUD.Kelas
{
    class Koneksi
    {

        public static MySqlConnection getConn()
        {

            string connStr = "server=localhost;user=root;database=cobaaa;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!.\n" + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return conn;
        }
        public static void AddMovie(Movie mov)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string sql = "INSERT INTO tblmovie VALUES(@MovId, @MovTitle, @MovGenre, @MovDate)";
            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = mov.MovId;
            cmd.Parameters.Add("@MovTitle", MySqlDbType.VarChar).Value = mov.MovTitle;
            cmd.Parameters.Add("@MovGenre", MySqlDbType.VarChar).Value = mov.MovGenre;
            cmd.Parameters.Add("@MovDate", MySqlDbType.VarChar).Value = mov.MovDate.ToString("yyyy-MM-dd HH:mm");
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Movie Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Data gagal disimpan\n" + ex, "info",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }
        
        public static void AddDirectors(Director directors)
        {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                string sql = "INSERT INTO tbldirector VALUES(@DirId, @DirName, @DirGender, @MovId)";
                MySqlConnection con = getConn();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@DirId", MySqlDbType.VarChar).Value = directors.DirId;
                cmd.Parameters.Add("@DirName", MySqlDbType.VarChar).Value = directors.DirName;
                cmd.Parameters.Add("@DirGender", MySqlDbType.VarChar).Value = directors.DirGender;
                cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = directors.MovId;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Director Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data gagal disimpan\n" + ex, "info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
        }

        public static void DeleteDirector(string id)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string sql = "DELETE FROM tbldirector WHERE dirId = @movId";

            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public static void UpdateDirector(Director dir, string id)
        {
            string sql = "UPDATE tbldirector SET dirName = @Name, dirGender = @Gender, movId = @MovId WHERE dirId = @IDDD";
            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = dir.DirName;
            cmd.Parameters.Add("@Gender", MySqlDbType.VarChar).Value = dir.DirGender;
            cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = dir.MovId;
            cmd.Parameters.Add("@IDDD", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updateed Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal disimpan\n" + ex, "info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        public static void AddActors(Actor actors)
        {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                string sql = "INSERT INTO tblactor VALUES(@ActId, @ActName, @ActGender, @MovId)";
                MySqlConnection con = getConn();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ActId", MySqlDbType.VarChar).Value = actors.ActId;
                cmd.Parameters.Add("@ActName", MySqlDbType.VarChar).Value = actors.ActName;
                cmd.Parameters.Add("@ActGender", MySqlDbType.VarChar).Value = actors.ActGender;
                cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = actors.MovId;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Actors Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data gagal disimpan\n" + ex, "info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
        }
        public static void UpdateActor(Actor act, string id)
        {
            string sql = "UPDATE tblactor SET actName = @Name, actGender = @Gender, movId = @MovId WHERE actId = @IDDD";
            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = act.ActName;
            cmd.Parameters.Add("@Gender", MySqlDbType.VarChar).Value = act.ActGender;
            cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = act.MovId;
            cmd.Parameters.Add("@IDDD", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updateed Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data gagal disimpan\n" + ex, "info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }
        public static void DeleteActor(string id)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string sql = "DELETE FROM tblactor WHERE actId = @movId";

            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public static void UpdateMovie(Movie mov, string id)
        {
            string sql = "UPDATE tblmovie SET movTitle = @MovTitle, movGenre = @MovGenre, movDate = @MovDate WHERE movId = @movId";
            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@movId", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@MovTitle", MySqlDbType.VarChar).Value = mov.MovTitle;
            cmd.Parameters.Add("@MovGenre", MySqlDbType.VarChar).Value = mov.MovGenre;
            cmd.Parameters.Add("@MovDate", MySqlDbType.DateTime).Value = mov.MovDate.ToString("yyyy-MM-dd HH:mm");
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updateed Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Data gagal disimpan\n" + ex, "info",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        public static void DeleteMovie(string id)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string sql = "DELETE FROM tblmovie WHERE movId = @movId";

            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MovId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public static void DisplaySearch(string query, DataGridView dgv)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string sql = query;
            MySqlConnection con = getConn();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
