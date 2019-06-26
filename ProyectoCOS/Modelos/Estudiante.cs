using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCOS.Modelos
{
    public class Estudiante
    {
        private long matricula;
        private string nombre;
        private string apellido_paterno;
        private string apellido_materno;
        private int edad;
        private string correo_electronico;
        private string curp;
        private string password;

        public Estudiante(long matricula, string nombre, string apellido_paterno, string apellido_materno, int edad, string correo_electronico, string curp, string password)
        {
            this.Matricula = matricula;
            this.Nombre = nombre;
            this.Apellido_paterno = apellido_paterno;
            this.Apellido_materno = apellido_materno;
            this.Edad = edad;
            this.Correo_electronico = correo_electronico;
            this.Curp = curp;
            this.Password = password;
        }

        public Estudiante GetEstudiante(long matricula)
        {
            Estudiante estudiante = null;
            Conexion con = new Conexion();
            SqlCommand command = new SqlCommand("SELECT * FROM Estudiantes;", con.Conn);
            //con.Conn.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                estudiante = new Estudiante(
                        sqlDataReader.GetInt64(0),
                        sqlDataReader.GetString(1),
                        sqlDataReader.GetString(2),
                        sqlDataReader.GetString(3),
                        sqlDataReader.GetInt32(4),
                        sqlDataReader.GetString(5),
                        sqlDataReader.GetString(6),
                        sqlDataReader.GetString(7)
                    );
            }
            return estudiante;
        }

        public long Matricula { get => matricula; set => matricula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido_paterno { get => apellido_paterno; set => apellido_paterno = value; }
        public string Apellido_materno { get => apellido_materno; set => apellido_materno = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Correo_electronico { get => correo_electronico; set => correo_electronico = value; }
        public string Curp { get => curp; set => curp = value; }
        public string Password { get => password; set => password = value; }
    }
}
