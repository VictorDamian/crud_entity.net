using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDao;
using ModelEntity;

namespace ModelBusiness
{
    public class StudentBusiness
    {
        private StudentDao studentDao;
        public StudentBusiness()
        {
            studentDao = new StudentDao();
        }
        // Validate id student state = 1
        public void create(Student student)
        {
            bool _check;
            string code = student.Id.ToString();
            int idStudent = 0;
            if(code == null)
            {
                student.State = 10;
            }
            else
            {
                try
                {
                    idStudent = Convert.ToInt32(student.Id);
                    _check = idStudent >= 10 && idStudent <= 99;
                    if (!_check)
                    {
                        student.State = 1;
                    }
                }catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            // Validate name student state = 2
            string name = student.Name;
            if (name == null)
            {
                student.State = 20;
            }
            else
            {
                name = student.Name.Trim();
                _check = name.Length > 0 && name.Length <= 50;
                if (_check)
                {
                    student.State = 2;
                }
            }
            // Validate last name student state = 3
            string lastname = student.Last_name;
            if (lastname == null)
            {
                student.State = 20;
            }
            else
            {
                lastname = student.Last_name.Trim();
                _check = lastname.Length > 0 && lastname.Length <= 50;
                if (_check)
                {
                    student.State = 3;
                }
            }
            // Validate cellphone student state = 4
            string cellphone = student.Cellphone;
            if (cellphone == null)
            {
                student.State = 20;
            }
            else
            {
                cellphone = student.Cellphone.Trim();
                _check = cellphone.Length > 0 && cellphone.Length <= 12;
                if (_check)
                {
                    student.State = 4;
                }
            }
            // Validate that not exist id student state = 5
            Student studentAux = new Student();
            studentAux.Id = student.Id;
            _check = !studentDao.getStudent(studentAux);
            if (!_check)
            {
                student.State = 5;
                return;
            }
            student.State = 99;
            studentDao.create(student);
        }
        public void update(Student student)
        {
            bool _check;
            // Validate name student state = 2
            string name = student.Name;
            if (name == null)
            {
                student.State = 20;
            }
            else
            {
                name = student.Name.Trim();
                _check = name.Length > 0 && name.Length <= 50;
                if (_check)
                {
                    student.State = 2;
                }
            }
            // Validate last name student state = 3
            string lastname = student.Last_name;
            if (lastname == null)
            {
                student.State = 20;
            }
            else
            {
                lastname = student.Last_name.Trim();
                _check = lastname.Length > 0 && lastname.Length <= 50;
                if (_check)
                {
                    student.State = 3;
                }
            }
            // Validate cellphone student state = 4
            string cellphone = student.Cellphone;
            if (cellphone == null)
            {
                student.State = 20;
            }
            else
            {
                cellphone = student.Cellphone.Trim();
                _check = cellphone.Length > 0 && cellphone.Length <= 12;
                if (_check)
                {
                    student.State = 4;
                }
            }
            student.State = 99;
            studentDao.create(student);
        }
        public void delete(Student student)
        {
            bool _check;
            Student studentAux = new Student();
            studentAux.Id = student.Id;
            _check = studentDao.getStudent(studentAux);
            if (!_check)
            {
                student.State = 33;
                return;
            }
            student.State = 99;
            studentDao.delete(student);
        }
        public bool getStudent(Student student)
        {
            return studentDao.getStudent(student);
        }
        public List<Student> getAll()
        {
            return studentDao.getAll();
        }
    }
}
