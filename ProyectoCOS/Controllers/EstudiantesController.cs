using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCOS.Modelos;

namespace ProyectoCOS.Controllers
{

    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        // GET: api/Estudiantes
        [HttpGet(Name = "GetEstudiante")]
        public string GetEstudiante()
        {
            Conexion con = new Conexion();
            SqlCommand command = new SqlCommand("SELECT * FROM Estudiantes;", con.Conn);
            //con.Conn.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            var items = new Dictionary<object, Dictionary<string, object>>();
            while (sqlDataReader.Read())
            {
                var item = new Dictionary<string, object>(sqlDataReader.FieldCount - 1);
                for (var i = 1; i < sqlDataReader.FieldCount; i++)
                {
                    item[sqlDataReader.GetName(i)] = sqlDataReader.GetValue(i);
                }
                items[sqlDataReader.GetValue(0)] = item;
            }
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}", Name = "GetEstudiantePorID")]
        public string GetEstudiantePorId(int id)
        {
            Conexion con = new Conexion();
            SqlCommand command = new SqlCommand("SELECT * FROM Estudiantes WHERE matricula = " + id + ";", con.Conn);
            //con.Conn.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            var items = new Dictionary<object, Dictionary<string, object>>();
            while (sqlDataReader.Read())
            {
                var item = new Dictionary<string, object>(sqlDataReader.FieldCount - 1);
                for (var i = 1; i < sqlDataReader.FieldCount; i++)
                {
                    item[sqlDataReader.GetName(i)] = sqlDataReader.GetValue(i);
                }
                items[sqlDataReader.GetValue(0)] = item;
            }
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        // POST: api/Estudiantes
        [HttpPost]
        public HttpResponseMessage PostEstudiante([FromBody] Estudiante estudiante)
        {
            HttpResponseMessage http;
            Conexion con = new Conexion();
            SqlCommand command = new SqlCommand(
            "INSERT into Estudiantes (nombre, apellido_paterno, apellido_materno, edad, correo_electronico, curp, [password]) values" +
                " ('" + estudiante.Nombre + "','" + estudiante.Apellido_paterno + "','" + estudiante.Apellido_materno + "'," + estudiante.Edad + ",'" + estudiante.Correo_electronico + "','" + estudiante.Curp + "','" + estudiante.Password + "');", con.Conn);
            int rows = command.ExecuteNonQuery();
            if (rows > 0)
            {
                http = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                http = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return http;
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutEstudiantePorId(int id, [FromBody] Estudiante estudiante)
        {
            Estudiante est = estudiante.GetEstudiante(Convert.ToInt64(id));
            HttpResponseMessage http;
            string correo;
            string password;
            string curp;
            int edad;
            if (est == null)
            {
                http = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                if(estudiante.Correo_electronico != null)
                {
                    correo = estudiante.Correo_electronico;
                }
                else
                {
                    correo = est.Correo_electronico;
                }
                if (estudiante.Edad > 0)
                {
                    edad = estudiante.Edad;
                }
                else
                {
                    edad = est.Edad;
                }
                if (estudiante.Curp != null)
                {
                    curp = estudiante.Curp;
                }
                else
                {
                    curp = est.Curp;
                }
                if (estudiante.Password != null)
                {
                    password = estudiante.Password;
                }
                else
                {
                    password = est.Password;
                }
                Conexion con = new Conexion();
                SqlCommand command = new SqlCommand("UPDATE Estudiantes SET correo_electronico = '" + correo + "', curp = '"+ curp +"', edad = " + edad + ", [password] = '" + password +"' WHERE matricula = " + id, con.Conn);
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    http = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    http = new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            return http;
        }

        // PUT: api/Estudiantes
        [HttpPut]
        public HttpResponseMessage PutEstudiantes([FromBody] List<Estudiante> estudiantes)
        {
            HttpResponseMessage http;
            //int contadorErrores = 0;
            http = new HttpResponseMessage(HttpStatusCode.NotFound);
            for (int i = 0; i < estudiantes.Count; i++)
            {
                if(estudiantes[i].GetEstudiante(estudiantes[i].Matricula) != null)
                {
                    Estudiante est = estudiantes[i].GetEstudiante(estudiantes[i].Matricula);
                    string correo;
                    string password;
                    string curp;
                    int edad;
                    if (estudiantes[i].Correo_electronico != null)
                    {
                        correo = estudiantes[i].Correo_electronico;
                    }
                    else
                    {
                        correo = est.Correo_electronico;
                    }
                    if (estudiantes[i].Edad > 0)
                    {
                        edad = estudiantes[i].Edad;
                    }
                    else
                    {
                        edad = est.Edad;
                    }
                    if (estudiantes[i].Curp != null)
                    {
                        curp = estudiantes[i].Curp;
                    }
                    else
                    {
                        curp = est.Curp;
                    }
                    if (estudiantes[i].Password != null)
                    {
                        password = estudiantes[i].Password;
                    }
                    else
                    {
                        password = est.Password;
                    }
                    Conexion con = new Conexion();
                    SqlCommand command = new SqlCommand("UPDATE Estudiantes SET correo_electronico = '" + correo + "', curp = '" + curp + "', edad = " + edad + ", [password] = '" + password + "' WHERE matricula = " + estudiantes[i].Matricula, con.Conn);
                    int rows = command.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        http = new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    else
                    {
                        http = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    http = new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
           
            return http;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage http;
            Conexion con = new Conexion();
            SqlCommand command = new SqlCommand("DELETE FROM Estudiantes WHERE matricula = " + id + ";", con.Conn);
            //con.Conn.Open();
            int rows = command.ExecuteNonQuery();
            if (rows > 0)
            {
                http = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                http = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return http;
        }
    }
}
