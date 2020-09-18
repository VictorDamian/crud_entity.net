using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class Student
    {
        /// <summary>
        /// Create attributes of the class
        /// </summary>
        private int _id;
        private String _name;
        private String _last_name;
        private String _cellphone;
        /// param: the attribute state handles errors
        private int _state;
        public Student() { }
        private Student(int id)
        {
            this.Id = id;
        }
        
        public Student(int id, String name, String last_name, String cellphone, int state)
        {
            this.Id = id;
            this.Name = name;
            this.Last_name = last_name;
            this.Cellphone = cellphone;
            this.State = state;
        }
        // Generate getters and setters
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Last_name { get => _last_name; set => _last_name = value; }
        public String Cellphone { get => _cellphone; set => _cellphone = value; }
        public int State { get => _state; set => _state = value; }
    }
}
