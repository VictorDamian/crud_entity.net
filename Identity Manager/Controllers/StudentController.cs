using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity;
using ModelBusiness;

namespace Identity_Manager.Controllers
{
    public class StudentController : Controller
    {
        private StudentBusiness studentBusiness;
        public StudentController()
        {
            studentBusiness = new StudentBusiness();
        }
        // GET: Student
        public ActionResult Index()
        {
            List<Student> listStudents = studentBusiness.getAll();
            return View(listStudents);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            //msg
            msgInicio();
            studentBusiness.create(student);
            msgErrorRegistration(student);
            return View();
        }
        public void msgInicio()
        {
            ViewBag.msgStart = "User registration form";
        }
        public void  msgErrorRegistration(Student student)
        {
            switch (student.State)
            {
                case 10:
                    ViewBag.msgError = "Campo codigo vacio";
                    break;
                case 1:
                    ViewBag.msgError = "Longitud id exedido, solo se permiten < 100 y > 1";
                    break;
                case 100:
                    ViewBag.msgError = "Solo numeros";
                    break;
                    // validate name
                case 20:
                    ViewBag.msgError = "campo nombre vacio";
                    break;
                case 2:
                    ViewBag.msgError = "Excedio la longitud de la cadena, solo son 50";
                    break;
                    // validate lastname
                case 30:
                    ViewBag.msgError = "campo apellido vacio";
                    break;
                case 3:
                    ViewBag.msgError = "Excedio la longitud de la cadena, solo son 50";
                    break;
                    // validate celphone
                case 40:
                    ViewBag.msgError = "campo telefopno vacio";
                    break;
                case 4:
                    ViewBag.msgError = "Excedio la longitud de la cadena, solo son 12";
                    break;
                case 5:
                    ViewBag.msgSuccess = "Student [" + student.Id + "]already exists";
                    break;
                case 99:
                    ViewBag.msgSuccess = "Student [" + student.Name + "]already register";
                    break;
            }
        }
    }
}