using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{
    internal class ECClass
    {
        DBconnect connect = new DBconnect();


        public bool insertEC(string code, string desc, int coefficient, string UE, string level, string field, string semester, int hour)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Element_Constitutif` VALUES (@code, @desc, @coeff, @UE, @level, @field, @semester, @hour);", connect.getconnection);

            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@coeff", MySqlDbType.Int32).Value = coefficient;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@UE", MySqlDbType.VarChar).Value = UE;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = semester;
            command.Parameters.Add("@hour", MySqlDbType.Int32).Value= hour;
            

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

        public bool updateEC(string code, string desc, int coefficient, string UE, string level, string field, string semester, int hour)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Element_Constitutif` SET `Libelle` = @desc, `Coefficient` = @coeff, `CodeUE` = @UE, `CodeNiveau` = @level, `CodeParcours` = @field, `CodeSemestre` = @semester, `Duree`= @hour  WHERE `CodeEC` = @code", connect.getconnection);

            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@coeff", MySqlDbType.Int32).Value = coefficient;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@UE", MySqlDbType.VarChar).Value = UE;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@field", MySqlDbType.VarChar).Value = field;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = semester;
            command.Parameters.Add("@hour", MySqlDbType.Int32).Value = hour;

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

        public bool deleteEC(string code)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Element_Constitutif` WHERE `CodeEC` = @code", connect.getconnection);

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


        public DataTable getEClist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable searchEC(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Element_Constitutif` WHERE CONCAT(`CodeEC` ,`Libelle`,`CodeUE`, `CodeNiveau`,`CodeParcours`, `CodeSemestre`, `Coefficient`, `Duree`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
