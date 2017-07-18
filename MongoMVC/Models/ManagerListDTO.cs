using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations;

namespace MongoMVC.Models
{
    public class ManagerListDTO
    {
        public ObjectId _id { get; set; }
        [Required(ErrorMessage = "Please enter name.")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "Please enter designation.")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please enter location.")]
        public string Location { get; set; }
    }
}