using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{
    internal class UEClass
    {
        DBconnect connect = new DBconnect();    

        public bool insertUE(string code, string desc, string level, string field, string semester, int credit)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Unite_Enseignement` VALUES (@code, @desc, @level, @field, @semester, @credit)", connect.getconnection);

            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = semester;
            command.Parameters.Add("@credit", MySqlDbType.Int32).Value = credit;

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

        public bool updateUE(string code, string desc, string level, string field, string semester, int credit)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Unite_Enseignement` SET `Libelle` = @desc, `CodeNiveau` = @level, `CodeParcours` = @field, `CodeSemestre` = @semester, `Credit` = @credit  WHERE `CodeUE` = @code", connect.getconnection);

            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = semester;
            command.Parameters.Add("@credit", MySqlDbType.Int32).Value = credit;

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

        public bool deleteUE(string code)
        {
            MySqlCommand command = new MySqlCommand("DELETE  FROM `Unite_Enseignement` WHERE `CodeUE` = @code", connect.getconnection);

            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;

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

        public DataTable getUElist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable searchUE(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Unite_Enseignement` WHERE CONCAT(`CodeUE`, `Libelle`,`CodeNiveau`,`CodeParcours`, `CodeSemestre`, `Credit`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
