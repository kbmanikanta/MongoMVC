using MongoMVC.DAL;
using MongoMVC.Models;
using System.Web.Mvc;

namespace MongoMVC.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Get()
        {
            ManagerDAL objDal = new ManagerDAL();
            return View(objDal.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ManagerListDTO obj)
        {
            ManagerDAL objDal = new ManagerDAL();
            objDal.Insert(obj);
            return RedirectToAction("Get");
        }

        public ActionResult Edit(string id)
        {
            ManagerDAL objDal = new ManagerDAL();
            return View(objDal.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(ManagerListDTO obj)
        {
            ManagerDAL objDal = new ManagerDAL();
            objDal.UpdateById(obj);
            return RedirectToAction("Detail",new { id = obj._id.ToString() });
        }

        public ActionResult Detail(string id)
        {
            ManagerDAL objDal = new ManagerDAL();
            return View(objDal.GetById(id));
        }

        public ActionResult Delete(string id)
        {
            ManagerDAL objDal = new ManagerDAL();
            objDal.DeleteById(id);
            return RedirectToAction("Get");
        }
    }
}