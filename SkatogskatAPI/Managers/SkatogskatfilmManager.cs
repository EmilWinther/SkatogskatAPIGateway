using SkatogskatAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;


namespace SkatogskatAPI.Managers
{
    public class SkatogskatfilmManager
    { 
        private static readonly List<Film> Data = new List<Film>
        {
        };
        private static int _nextId = 1;


        public List<Film> GetAllFilms()
        {
            List<Film> rtn = new List<Film>(Data);
            rtn = rtn.OrderBy(x => x.Title).ToList();
            return rtn;
        }

        public Film Add(Film newFilm)
        {
            newFilm.Id = _nextId++;
            Data.Add(newFilm);
            MongoClient dbClient = new MongoClient("mongodb+srv://emiladmin:<admin123>@cluster0.vhmarzb.mongodb.net/?authSource=admin");
            var database = dbClient.GetDatabase("document");
            var collection = database.GetCollection<BsonDocument>("documents");
            var document = new BsonDocument { { "student_id", 10000 }, {
                "scores",
                new BsonArray {
                new BsonDocument { { "type", "exam" }, { "score", 88.12334193287023 } },
                new BsonDocument { { "type", "quiz" }, { "score", 74.92381029342834 } },
                new BsonDocument { { "type", "homework" }, { "score", 89.97929384290324 } },
                new BsonDocument { { "type", "homework" }, { "score", 82.12931030513218 } }
                }
                }, { "class_id", 480 }
        };
            collection.InsertOne(document);
            return newFilm;
        }

        public string Update(int id, string updates)
        {
            //string str1 = Data.Find(string1 => string1.Id == id);
            //if (str1 == null) return null;
            //str1.Name = updates.Name;
            //str1.Price = updates.Price;
            //return str1;
            return null;
        }
        public Film Delete(int id, GatewayConfig config)
        {
            Film film = Data.Find(film1 => film1.Id == id);
            if (film == null) return null;
            Data.Remove(film);
            return film;
        }
    }
}
