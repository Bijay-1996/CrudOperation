using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudOperation.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        string con = @"Data Source=BIJAY\SQLEXPRESS;Initial Catalog=testdb;Integrated Security=True";
        // GET: Student
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "select * from Student";
                SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
                adapter.Fill(dt);
                
            }
            return View(dt);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    string query = "insert into Student values('" + student.Name + "','" + student.Dob + "')";
                    SqlCommand cmd=new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student std = new Student();
            DataTable student = new DataTable();
            using(SqlConnection conn=new SqlConnection(con))
            {
                conn.Open();
                string query = "Select * from Student where id=" + id;
                SqlDataAdapter adt = new SqlDataAdapter(query,conn);
                adt.Fill(student);
            }
            if(student.Rows.Count == 1)
            {
                id =Convert.ToInt32(student.Rows[0][0].ToString());
                std.Name = student.Rows[0][1].ToString();
                std.Dob = student.Rows[0][2].ToString();
                return View(std);
            }
            return RedirectToAction("Index");
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student collection)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    string query = "Update Student Set Name='" + collection.Name + "',DOB='" + collection.Dob + "' where id='"+id+"'";
                    SqlCommand cmd=new SqlCommand(query,conn);
                    cmd.ExecuteNonQuery();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using(SqlConnection conn=new SqlConnection(con))
            {
                conn.Open();
                string query = "Delete from Student where id =@id";
                SqlCommand cmd=new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // POST: Student/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
