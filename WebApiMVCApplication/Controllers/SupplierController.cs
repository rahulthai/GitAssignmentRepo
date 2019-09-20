using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiMVCApplication.Repository;

namespace WebApiMVCApplication.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier  
        public ActionResult GetAllSuppliers()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/supplier/getallSuppliers");
                response.EnsureSuccessStatusCode();
                List<Models.Supplier> Suppliers = response.Content.ReadAsAsync<List<Models.Supplier>>().Result;
                ViewBag.Title = "All Suppliers";
                return View(Suppliers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[HttpGet]  
        public ActionResult EditSupplier(string id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/supplier/GetSupplier?id=" + id);
            response.EnsureSuccessStatusCode();
            Models.Supplier Suppliers = response.Content.ReadAsAsync<Models.Supplier>().Result;
            ViewBag.Title = "All Suppliers";
            return View(Suppliers);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Supplier Supplier)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/supplier/UpdateSupplier", Supplier);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllSuppliers");
        }
        public ActionResult Details(string id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/supplier/GetSupplier?id=" + id);
            response.EnsureSuccessStatusCode();
            Models.Supplier Suppliers = response.Content.ReadAsAsync<Models.Supplier>().Result;
            ViewBag.Title = "All Suppliers";
            return View(Suppliers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("GetAllSuppliers");
        }

        [HttpPost]
        public ActionResult Create(Models.Supplier Supplier)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/supplier/InsertSupplier", Supplier);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllSuppliers");
        }
        public ActionResult Delete(string id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/supplier/DeleteSupplier?id=" + id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllSuppliers");
        }
    }
}