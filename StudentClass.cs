using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_system
{
    internal class StudentClass
    {
        DBconnect connect = new DBconnect();

        public bool insertStudent(string matricule, int numero, string nom, string prenoms, string sexe, DateTime date_naissance, string lieu_naissance, string adresse, string phone)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `Etudiant` VALUES (@mat,@num,@fname,@lname,@gd,@bdate,@bcountry,@adr,@ph)", connect.getconnection);

            //@mat,@num,@fname,@lname,@gd,@bdate,@bcountry,@adr,@ph
            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = matricule ;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = numero;
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = prenoms ;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = sexe;
            command.Parameters.Add("@bdate", MySqlDbType.Date).Value = date_naissance;
            command.Parameters.Add("@bcountry", MySqlDbType.VarChar).Value = lieu_naissance ;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = adresse;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;


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
        public DataTable getStudentlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            //MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable searchStudent(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `Etudiant` WHERE CONCAT(`Matricule`,`Numero`,`Nom`,`Prenoms`,`Adresse`,`Numero_de_telephone`, `Lieu_de_naissance`, `Date_de_naissance`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool updateStudent(string matricule, int numero, string nom, string prenoms, string sexe, DateTime date_naissance, string lieu_naissance, string adresse, string phone)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `Etudiant` SET `Numero`=@num, `Nom`=@fname, `Prenoms`=@lname, `Sexe`=@gd,`Date_de_naissance`=@bdate, `Lieu_de_naissance` =@bcountry, `Adresse`=@adr,`Numero_de_telephone`=@ph WHERE `Matricule`=@mat", connect.getconnection);

            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value = matricule;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = numero;
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = nom;
            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = prenoms;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = sexe;
            command.Parameters.Add("@bdate", MySqlDbType.Date).Value = date_naissance;
            command.Parameters.Add("@bcountry", MySqlDbType.VarChar).Value = lieu_naissance;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = adresse;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;

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

        public bool deleteStudent(string matricule)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `Etudiant` WHERE `Matricule` = @mat", connect.getconnection);
            command.Parameters.Add("@mat", MySqlDbType.VarChar).Value=matricule;

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
