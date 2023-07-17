using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{
    internal class SemesterClass
    {
        DBconnect connect = new DBconnect();
        ManageClass management = new ManageClass();


        public bool insertSemester(string code, string desc, string level, DateTime start, DateTime end)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Semestre` VALUES (@code, @semester, @level, @start, @end)", connect.getconnection);

            command.Parameters.Add("@code",MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value=level;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@end", MySqlDbType.Date).Value = end;


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

        public bool updateSemester(string code, string desc, string level, DateTime start, DateTime end)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Semestre` SET `Semestre` = @semester, `CodeNiveau` = @level, `Debut` = @start, `Fin` = @end WHERE `CodeSemestre` = @code", connect.getconnection);

            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@semester", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@end", MySqlDbType.Date).Value = end;


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


        public bool deleteSemester(string code)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Semestre` WHERE `CodeSemestre` = @code", connect.getconnection);
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

        public DataTable searchSemester(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Semestre` WHERE CONCAT(`CodeSemestre`, `Semestre`, `CodeNiveau`, `Debut`, `Fin`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getSemesterlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


    }
}
