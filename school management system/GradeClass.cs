using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{
    internal class GradeClass
    {
        DBconnect connect = new DBconnect();

        public bool insertGrade(string mat, string unity, string element, double score, string year)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Note` VALUES (@mat, @UE, @EC, @score, @year)", connect.getconnection);

            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;
            command.Parameters.Add("@UE", MySqlDbType.VarChar).Value = unity;
            command.Parameters.Add("@EC", MySqlDbType.VarChar).Value = element;
            command.Parameters.Add("@score", MySqlDbType.Double).Value = score;
            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = year;

            connect.openConnect();

            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public bool updateGrade(string mat, string unity, string element, double score, string year)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Note` SET `CodeUE` = @UE,`note`= @score ,`Annee` = @year WHERE `Matricule` = @mat AND `CodeEC` = @EC", connect.getconnection);
            //MySqlCommand command2 = new MySqlCommand("UPDATE `Note` SET `CodeUE` = @UE, `CodeEC` = @EC, `note`= @score ,`Annee` = @year WHERE `Matricule` = @mat" , connect.getconnection);
            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;
            command.Parameters.Add("@UE", MySqlDbType.VarChar).Value = unity;
            command.Parameters.Add("@EC", MySqlDbType.VarChar).Value = element;
            command.Parameters.Add("@score", MySqlDbType.Double).Value = score;
            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = year;


            /*command2.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;
            command2.Parameters.Add("@UE", MySqlDbType.VarChar).Value = unity;
            command2.Parameters.Add("@EC", MySqlDbType.VarChar).Value = element;
            command2.Parameters.Add("@score", MySqlDbType.Double).Value = score;
            command2.Parameters.Add("@year", MySqlDbType.VarChar).Value = year;*/
            // || command2.ExecuteNonQuery() == 1

            connect.openConnect();

            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public bool deleteGrade(string mat, string element)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Note` WHERE `Matricule`= @mat AND `CodeEC` = @EC", connect.getconnection);

            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;
            command.Parameters.Add("@EC", MySqlDbType.VarChar).Value = element;

            connect.openConnect();

            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public DataTable getScorelist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable searchScore(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Note` WHERE CONCAT(`Matricule`, `CodeUE`, `CodeEC`, `note`, `Annee`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
