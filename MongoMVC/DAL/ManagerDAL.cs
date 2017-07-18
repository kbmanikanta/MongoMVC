using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoMVC.Models;
using System.Collections.Generic;

namespace MongoMVC.DAL
{
    public class ManagerDAL
    {
        MongoServerSettings Settings_;
        MongoServer server;
        MongoDatabase Database_;

        public ManagerDAL()
        {
            Settings_ = new MongoServerSettings();
            Settings_.Server = new MongoServerAddress("localhost", 27017);
            server = new MongoServer(Settings_);
            Database_ = server.GetDatabase("admin");
        }

        public void Insert(ManagerListDTO _Obj)
        {
            try
            {
                server.Connect();
                MongoCollection<ManagerListDTO> Collection_ = Database_.GetCollection<ManagerListDTO>("managers");
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

        public List<ManagerListDTO> Get()
        {
            List<ManagerListDTO> managers = new List<ManagerListDTO>();

            try
            {
                server.Connect();
                MongoCollection<ManagerListDTO> Collection_ = Database_.GetCollection<ManagerListDTO>("managers");

                foreach (ManagerListDTO obj in Collection_.FindAll())
                {
                    managers.Add(obj);
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

            return managers;
        }

        public ManagerListDTO GetById(string id)
        {
            ManagerListDTO manager = new ManagerListDTO();

            try
            {
                server.Connect();
                MongoCollection<ManagerListDTO> Collection_ = Database_.GetCollection<ManagerListDTO>("managers");

                var query_id = Query.EQ("_id", ObjectId.Parse(id));
                manager = Collection_.FindOne(query_id);
            }
            catch
            {
                throw;
            }
            finally
            {
                server.Disconnect();
            }

            return manager;
        }

        public void UpdateById(ManagerListDTO obj)
        {
            try
            {
                server.Connect();
                MongoCollection<ManagerListDTO> Collection_ = Database_.GetCollection<ManagerListDTO>("managers");
                
                var query_id = Query.EQ("_id", ObjectId.Parse(obj._id.ToString()));
                Collection_.Save<ManagerListDTO>(obj);
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
                MongoCollection<ManagerListDTO> Collection_ = Database_.GetCollection<ManagerListDTO>("managers");

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