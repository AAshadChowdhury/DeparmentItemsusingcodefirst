using CoreShortProject.Context;
using CoreShortProject.Models.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace CoreShortProject.Controllers
{
    public class Dept_Items : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult main()
        {
            List<ItemCount> a = (from d in db.dept2 select new ItemCount { deptid=d.deptid,deptname=d.deptname,count=d.items2.Count }).ToList();
           return View(a);
        }
        private MyDBContext db;
        private IHostingEnvironment _HostEnvironment;
        public Dept_Items(MyDBContext _db, IHostingEnvironment HostEnvironment)
        {
            db = _db;
            _HostEnvironment = HostEnvironment;
        }


        public JsonResult GetDept(string id)
        {
            var a = (from d in db.dept2 where d.deptid == id select new { d.deptid, d.deptname, d.location });
            return Json(a);
        }

        public JsonResult UpdateDept(string id,dept2 b)
        {
            dept2 a = (from d in db.dept2 where d.deptid == id select d).SingleOrDefault();
            a.deptname = b.deptname;
            a.location = b.location;
            db.SaveChanges();
            return Json(a);
        }


        public JsonResult GetItems(string id)
        {
            var a = (from d in db.items2 where d.deptid == id select new { d.itemcode, d.itemname, d.cost, d.rate, d.date,d.available, d.picture });
            return Json(a);
        }
        public ActionResult clientJsonFind()
        {
            return View();
        }
        public JsonResult GetItemsByItemCode(string id)
        {
            var a = (from d in db.items2 where d.itemcode == id select d);
            return Json(a);
        }

        public JsonResult GetDeptItems(string id)
        {
            var a = (from d in db.dept2 where d.deptid == id select new { d.deptid, d.deptname, d.location, d.items2.Count });
            return Json(a);
        }
        public JsonResult Jsondept()
        {
            var a = (from d in db.dept2 select d);
            return Json(a);
        }

        public JsonResult JsonIndex()
        {
            var a = (from d in db.items2 select d);
            return Json(a);
        }
        public ActionResult client()
        {
            return View();
        }

        public JsonResult InsertDept(dept2 stu_Guard)
        {
            dept2 a = new dept2();
            a.deptid = stu_Guard.deptid;
            a.deptname = stu_Guard.deptname;
            a.location = stu_Guard.location;
            db.dept2.Add(a);
            db.SaveChanges();
            return Json(a);
        }
        public ActionResult index2()
        {
            return View();
        }

        public JsonResult InsertItems(items2 stu_Guard)
        {
            items2 a1 = new items2();
            a1.itemcode = stu_Guard.itemcode;
            a1.itemname = stu_Guard.itemname;
            a1.deptid = stu_Guard.deptid;
            a1.date = DateTime.Parse(stu_Guard.date.ToShortDateString());
            a1.picture = stu_Guard.picture;
            a1.cost = (decimal)stu_Guard.cost;
            a1.rate = (decimal)stu_Guard.rate;
            a1.available = (bool?)stu_Guard.available;

            db.items2.Add(a1);
            db.SaveChanges();
            return Json(a1);
        }
        public JsonResult DeleteAll(string id)
        {

            List<items2> st5 = db.items2.Where(xx => xx.deptid == id).ToList();
            db.items2.RemoveRange(st5);

            dept2 st6 = db.dept2.Find(id);
            if (st6 != null)
            {
                db.dept2.Remove(st6);
            }
            db.SaveChanges();
            return Json("OK");
        }
        [HttpPost]
        public JsonResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Form.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    var files = Request.Form.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                       
                        IFormFile file = files[i];
                        string fname;

                        fname = file.FileName;

                        // Get the complete folder path and store the file inside it.  
                        //fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        string webRootPath = _HostEnvironment.WebRootPath;
                        string fname1 = "";
                        fname1 = Path.Combine(webRootPath, "Uploads/" + fname);
                        file.CopyTo(new FileStream(fname1, FileMode.Create));
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

    }

    }

