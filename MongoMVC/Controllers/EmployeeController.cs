using MongoMVC.DAL;
using MongoMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace MongoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Get()
        {
            EmployeeDAL objDal = new EmployeeDAL();
            return View(objDal.Get());
        }
        public ActionResult Create()
        {
            EmployeeListDTO employee = new EmployeeListDTO();

            ManagerDAL objManagerDAL = new ManagerDAL();
            employee.Managers = objManagerDAL.Get().Select(x => new Manager
            {
                ManagerId = x._id.ToString(),
                ManagerName = x.ManagerName
            }).ToList();

            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(EmployeeListDTO obj)
        {
            ManagerDAL objManagerDAL = new ManagerDAL();
            obj.Manager = objManagerDAL.Get().
                                Where(x => x._id.ToString() == obj.ManagerId).
                                Select(x => new Manager
                                {
                                    ManagerId = x._id.ToString(),
                                    ManagerName = x.ManagerName
                                }).First();

            EmployeeDAL objDal = new EmployeeDAL();
            objDal.Insert(obj);
            return RedirectToAction("Get");
        }

        public ActionResult Edit(string id)
        {
            EmployeeDAL objDal = new EmployeeDAL();
            EmployeeListDTO employee = objDal.GetById(id);

            ManagerDAL objManagerDAL = new ManagerDAL();
            employee.Managers = objManagerDAL.Get().Select(x => new Manager
            {
                ManagerId = x._id.ToString(),
                ManagerName = x.ManagerName
            }).ToList();

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeListDTO obj)
        {
            EmployeeDAL objDal = new EmployeeDAL();

            ManagerDAL objManagerDAL = new ManagerDAL();
            obj.Manager = objManagerDAL.Get().
                                Where(x => x._id.ToString() == obj.ManagerId).
                                Select(x => new Manager
                                {
                                    ManagerId = x._id.ToString(),
                                    ManagerName = x.ManagerName
                                }).First();

            objDal.UpdateById(obj);
            return RedirectToAction("Detail", new { id = obj._id.ToString() });
        }

        public ActionResult Detail(string id)
        {
            EmployeeDAL objDal = new EmployeeDAL();
            return View(objDal.GetById(id));
        }

        public ActionResult Delete(string id)
        {
            EmployeeDAL objDal = new EmployeeDAL();
            objDal.DeleteById(id);
            return RedirectToAction("Get");
        }
    }
}