using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCrud.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult GetData()
        {
            using (StudentDBEntities db = new StudentDBEntities())
            {
                List<StudentTable> studList = db.StudentTables.ToList<StudentTable>();

                return Json(new { data = studList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult StoreOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new StudentTable());

            else
            {
                using (StudentDBEntities db = new StudentDBEntities())
                {
                    return View(db.StudentTables.Where(x => x.StudentID == id).FirstOrDefault<StudentTable>());
                }                                                              //Returns first element found that satisfies condition or
                                                                               //the default element if no element found
            }
        }


        [HttpPost]

        public ActionResult StoreOrEdit (StudentTable studentObj) //Adding a new studentObject as method parameter
        {
            using (StudentDBEntities db = new StudentDBEntities())
            {
                if(studentObj.StudentID == 0) //If student doesn't exist
                {
                    db.StudentTables.Add(studentObj); //Add new student
                    db.SaveChanges(); //Update database
                    return Json(new { success = true, message = "Saved succesfully", JsonRequestBehavior.AllowGet }); //return json response
                }

                else
                {
                    db.Entry(studentObj).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
                }
            }
        }

        //Delete action method

        public ActionResult Delete(int id)
        {
            using (StudentDBEntities db = new StudentDBEntities())
            {
                StudentTable emp = db.StudentTables.Where(x => x.StudentID == id).FirstOrDefault<StudentTable>();
                                                                                  //Returns first element found that satisfies condition or
                                                                                  //the default element if no element found
                db.StudentTables.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Succesfully", JsonRequestBehavior.AllowGet });
            }
        }

    }
}