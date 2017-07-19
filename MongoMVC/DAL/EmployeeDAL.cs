using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoMVC.DAL
{
    public class EmployeeDAL
    {
        static MongoServerSettings Settings_;
        static MongoServer server;
        static MongoDatabase Database_;

        public EmployeeDAL()
        {
            Settings_ = new MongoServerSettings();
            Settings_.Server = new MongoServerAddress("localhost", 27017);
            server = new MongoServer(Settings_);
            Database_ = server.GetDatabase("admin");
        }

        public void Insert(EmployeeListDTO _Obj)
        {
            try
            {
                server.Connect();
                MongoCollection<EmployeeListDTO> Collection_ = Database_.GetCollection<EmployeeListDTO>("employee");
                Collection_.Insert(_Obj);
            }
            catch
            {
                throw;
            }
            finally
            {
                server.Disconnect();
            }
        }

        public List<EmployeeListDTO> Get()
        {
            List<EmployeeListDTO> employees = new List<EmployeeListDTO>();

            try
            {
                server.Connect();
                MongoCollection<EmployeeListDTO> Collection_ = Database_.GetCollection<EmployeeListDTO>("employee");

                foreach (EmployeeListDTO obj in Collection_.FindAll())
                {
                    employees.Add(obj);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                server.Disconnect();
            }

            return employees;
        }

        public EmployeeListDTO GetById(string id)
        {
            EmployeeListDTO employee = new EmployeeListDTO();

            try
            {
                server.Connect();
                MongoCollection<EmployeeListDTO> Collection_ = Database_.GetCollection<EmployeeListDTO>("employee");

                var query_id = Query.EQ("_id", ObjectId.Parse(id));
                employee = Collection_.FindOne(query_id);
            }
            catch
            {
                throw;
            }
            finally
            {
                server.Disconnect();
            }

            return employee;
        }

        public void UpdateById(EmployeeListDTO obj)
        {
            try
            {
                server.Connect();
                MongoCollection<EmployeeListDTO> Collection_ = Database_.GetCollection<EmployeeListDTO>("employee");

                var query_id = Query.EQ("_id", ObjectId.Parse(obj._id.ToString()));
                Collection_.Save<EmployeeListDTO>(obj);
            }
            catch
            {
                throw;
            }
            finally
            {
                server.Disconnect();
            }
        }

        public void DeleteById(string id)
        {
            try
            {
                server.Connect();
                MongoCollection<EmployeeListDTO> Collection_ = Database_.GetCollection<EmployeeListDTO>("employee");

                var query_id = Query.EQ("_id", ObjectId.Parse(id.ToString()));
                Collection_.Remove(query_id);
            }
            catch
            {
                throw;
            }
            finally
            {
                server.Disconnect();
            }
        }
    }
}