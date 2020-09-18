using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ModelEntity;
using System.Threading.Tasks;

namespace ModelDao
{
    public class StudentDao:StudentRepository<Student>
    {
        private DBConnection dBConnection;
        private SqlCommand sqlCommand;
        public StudentDao()
        {
            dBConnection = DBConnection.stateConnection();
        }

        public void create(Student student)
        {
            string _create = 
                "INSERT INTO STUDENTS(ID,NAME,LASTNAME,CELLPHONE)" +
                "VALUES('"+student.Id+"','"+student.Name+"','"+student.Last_name+"','"+student.Cellphone+"')";
            try
            {
                sqlCommand = new SqlCommand(_create, dBConnection.getConnection());
                dBConnection.getConnection().Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dBConnection.getConnection().Close();
                dBConnection.closeConnection();
            }
        }

        public void delete(Student student)
        {
            string _dalete =
                "DELETE FROM STUDENTS WHERE ID='" + student.Id + "'";
            try
            {
                sqlCommand = new SqlCommand(_dalete, dBConnection.getConnection());
                dBConnection.getConnection().Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dBConnection.getConnection().Close();
                dBConnection.closeConnection();
            }
        }

        public void update(Student student)
        {
            string _update =
                "UPDATE STUDENTS SET ID='"+student.Name+"',NAME='"+student.Name+"',LASTNAME='"+student.Last_name+"',CELLPHONE='"+student.Cellphone+"' WHERE ID='"+student.Id+"'";
            try
            {
                sqlCommand = new SqlCommand(_update, dBConnection.getConnection());
                dBConnection.getConnection().Open();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dBConnection.getConnection().Close();
                dBConnection.closeConnection();
            }
        }
        
        public bool getStudent(Student student)
        {
            bool _findRecords;
            string getStudent = "SELECT * FROM STUDENTS WHERE ID='"+student.Id+"'";
            try
            {
                sqlCommand = new SqlCommand(getStudent, dBConnection.getConnection());
                dBConnection.getConnection().Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                _findRecords = reader.Read();
                if (_findRecords)
                {
                    student.Id = Convert.ToInt32(reader[0].ToString());
                    student.Name = reader[1].ToString();
                    student.Last_name = reader[2].ToString();
                    student.Cellphone = reader[3].ToString();
                    student.State = 99;
                }
                else
                {
                    student.State = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dBConnection.getConnection().Close();
                dBConnection.closeConnection();
            }
            return _findRecords;
        }
        public List<Student> getAll()
        {
            List<Student> _listStudents = new List<Student>();
            string getAll = "SELECT * FROM STUDENTS";
            try
            {
                sqlCommand = new SqlCommand(getAll, dBConnection.getConnection());
                dBConnection.getConnection().Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader[0].ToString());
                    student.Name = reader[1].ToString();
                    student.Last_name = reader[2].ToString();
                    student.Cellphone = reader[3].ToString();
                    _listStudents.Add(student);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dBConnection.getConnection().Close();
                dBConnection.closeConnection();
            }
            return _listStudents;
        }
    }
}
