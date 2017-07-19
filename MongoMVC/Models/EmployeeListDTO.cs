using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MongoMVC.Models
{
    public class EmployeeListDTO
    {
        public EmployeeListDTO()
        {
            Managers = new List<Manager>();
        }

        public ObjectId _id { get; set; }
        [Required(ErrorMessage ="Enter Employee Name")]
        [Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage ="Enter Employee Code")]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Enter Manager Id")]
        [Display(Name = "Manager Id")]
        [BsonIgnore]
        public string ManagerId { get; set; }
        [BsonIgnore]
        public List<Manager> Managers { get; set; }
        public Manager Manager { get; set; }
    }

    public class Manager
    {
        [Required(ErrorMessage ="Select Manager")]
        [Display(Name = "Manager")]
        public string ManagerId { get; set; }
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }
    }
}