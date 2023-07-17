using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{
    internal class ManageClass
    {
        DBconnect connect = new DBconnect();


        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            //MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        


        public bool insertLevel(string level, string description)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Niveau` VALUES (@level, @desc)", connect.getconnection);

            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = description;

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

        public bool updateLevel(string level, string description)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Niveau` SET `Niveau` = @desc WHERE `CodeNiveau` = @level", connect.getconnection);

            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = description;

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

        public bool deleteLevel(string level)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Niveau` WHERE `CodeNiveau` = @level", connect.getconnection);
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;

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


        public bool insertField(string field, string description)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Parcours` VALUES (@field, @desc)", connect.getconnection);

            command.Parameters.Add("@field", MySqlDbType.VarChar).Value=field;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = description;

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

        public bool updateField(string field, string description)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Parcours` SET `Parcours` = @desc WHERE `CodeParcours` = @field", connect.getconnection);

            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = description;

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

        public bool deleteField(string field)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Parcours` WHERE `CodeParcours` = @field", connect.getconnection);
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;


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

        public bool insertClass(string Class, string level, string field)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Grade` VALUES (@grade, @level, @field)", connect.getconnection);

            command.Parameters.Add("@grade", MySqlDbType.VarChar).Value = Class;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;

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

        public bool updateClass(string Class, string level, string field)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Grade` SET `CodeParcours` = @field, `CodeNiveau` = @level WHERE `CodeGrade` = @grade", connect.getconnection);

            command.Parameters.Add("@grade", MySqlDbType.VarChar).Value = Class;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;

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

        public bool deleteClass(string Class)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Grade` WHERE `CodeGrade` = @grade", connect.getconnection);
            command.Parameters.Add("@grade", MySqlDbType.VarChar).Value = Class;

            
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
