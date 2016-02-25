using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BomDiaBrasilTreinamento.Web.Controllers
{
    public class EmpregadoController : Controller
    {
        // GET: Empregado
        public ActionResult Index()
        {
            SqlCommand sql = new SqlCommand();
            return View();
        }

        // GET: Empregado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empregado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empregado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empregado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empregado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empregado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empregado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
