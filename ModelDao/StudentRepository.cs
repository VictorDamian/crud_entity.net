using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDao
{
    public interface StudentRepository<Student>
    {
        void create(Student student);
        void update(Student student);
        void delete(Student student);
        bool getStudent(Student student);
        List<Student> getAll();
    }
}
