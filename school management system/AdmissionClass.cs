using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{

    internal class AdmissionClass
    {
        DBconnect connect = new DBconnect();
        StudentClass student = new StudentClass();
        ManageClass manage = new ManageClass();
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            //MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool insertRegister(string mat, string level, string field, string year)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Inscription` VALUES (@mat, @level ,@field, @year)", connect.getconnection);

            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value=level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
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

        public DataTable searchRegister(string searchdata) 
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Inscription` WHERE CONCAT(`Matricule`, `CodeNiveau`, `CodeParcours`, `Annee`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateRegister(string mat, string level, string field, string year)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Inscription` SET  `CodeNiveau` = @level, `CodeParcours` = @field, `Annee` = @year WHERE `Matricule` = @mat", connect.getconnection);

            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
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

        public bool deleteRegister(string mat)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Inscription` WHERE `Matricule` = @mat", connect.getconnection);

            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = mat;

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
    }
}
