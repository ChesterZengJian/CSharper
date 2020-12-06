using System;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDbDemo.Services;

namespace MongoDbDemo
{
    internal class Program
    {
        private static async Task Main()
        {
            var bookService = new BookService();

            //await bookService.InsertBook();

            //var books = await bookService.GetBooksAsync();
            //Console.WriteLine("Book info:");
            //books.ForEach(book =>
            //{
            //    Console.WriteLine($"Id: {book.Id}");
            //    Console.WriteLine($"Author Id: {book.AuthorId}");
            //});

            Console.WriteLine();
            var books = await bookService.GetBooksAsync("5fccfeb1f67169fd7da87159");
            Console.WriteLine("Author info:");
            books.ForEach(book =>
            {
                Console.WriteLine($"Id: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Books' count: {book.InnerAuthors.Count()}");
                if (book.InnerAuthors.Any())
                {
                    Console.WriteLine($"Author's First name: {book.InnerAuthors.First().FirstName}");
                }
            });

            //const string connStr = @"mongodb://192.168.3.127:27017";
            //var dbClient = new MongoClient(connStr);
            //var db = dbClient.GetDatabase("sample_training");
            //var collection = db.GetCollection<BsonDocument>("grades");

            #region Get Databases

            //var dbList = await dbClient.ListDatabases().ToListAsync();

            //Console.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    Console.WriteLine(db);
            //}

            #endregion

            #region Insert Document

            //var doc = new BsonDocument
            //{
            //    {"student_id",10000 },
            //    {"scores",new BsonArray
            //        {
            //            new BsonDocument
            //            {
            //                {"type","exam"},
            //                {"score",88.12334193287023 }
            //            },
            //            new BsonDocument
            //            {
            //                {"type","quiz"},
            //                {"score",74.92381029342834 }
            //            },
            //            new BsonDocument
            //            {
            //                {"type","homework"},
            //                {"score",89.97929384290324  }
            //            },
            //            new BsonDocument
            //            {
            //                { "type", "homework" },
            //                { "score", 82.12931030513218 }
            //            }
            //        }
            //    },
            //    {"class_id",480 }
            //};

            //await collection.InsertOneAsync(doc);

            //Console.WriteLine("Insert completed. Now read the documents:\n");

            //foreach (var d in await collection.Find(d => true).ToListAsync())
            //{
            //    Console.WriteLine(d + "\n");
            //}

            #endregion

            #region Read Document

            //var firstDoc = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
            //Console.WriteLine(firstDoc.ToString());

            // ----------------------------
            // Reading with a Filter
            // ----------------------------

            //var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
            //var studentDocument = await collection.Find(filter).FirstOrDefaultAsync();
            //Console.WriteLine(studentDocument.ToString());

            // ----------------------------
            // Reading All Documents
            // ----------------------------

            //var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("scores", new BsonDocument
            //{
            //    { "type", "exam" },
            //    { "score", new BsonDocument { { "$gte", 80 } } }
            //});

            //var highExamScores = await collection.Find(highExamScoreFilter).ToListAsync();
            //foreach (var highExamScore in highExamScores)
            //{
            //    Console.WriteLine(highExamScore);
            //}

            //var cursor = collection.Find(highExamScoreFilter).ToCursor();
            //foreach (var document in cursor.ToEnumerable())
            //{
            //    Console.WriteLine(document);
            //}

            //await collection.Find(highExamScoreFilter).ForEachAsync(Console.WriteLine);

            // ----------------------------
            // Sort
            // ----------------------------

            //var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>("scores", new BsonDocument
            //{
            //    { "type", "exam" },
            //    { "score", new BsonDocument { { "$gte", 80 } } }
            //});
            //var sort = Builders<BsonDocument>.Sort.Descending("student_id");
            //var highExamScores = await collection.Find(highExamScoreFilter).Sort(sort).ToListAsync();
            //foreach (var highExamScore in highExamScores)
            //{
            //    Console.WriteLine(highExamScore);
            //}

            #endregion

            #region Update Document

            //Console.WriteLine("Origin Document:\n");
            //var originDocuments = await collection.FindAsync(d => true);
            //foreach (var originDocument in originDocuments.ToList())
            //{
            //    Console.WriteLine(originDocument);
            //}

            // ----------------------------
            // Update One
            // ----------------------------

            //var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000);
            //var update = Builders<BsonDocument>.Update.Set("class_id", 485);
            //await collection.UpdateOneAsync(filter, update);

            // ----------------------------
            // Update Array
            // ----------------------------

            //var filter = Builders<BsonDocument>.Filter.Eq("student_id", 10000) &
            //             Builders<BsonDocument>.Filter.Eq("scores.type", "exam");
            //var update = Builders<BsonDocument>.Update.Set("scores.$.score", 84.92381029342834);
            //await collection.UpdateOneAsync(filter, update);
            //await collection.UpdateManyAsync(filter, update);

            //Console.WriteLine("\n After update: \n");
            //var destDocuments = await collection.FindAsync(d => true);
            //foreach (var destDocument in destDocuments.ToEnumerable())
            //{
            //    Console.WriteLine(destDocument);
            //}

            #endregion

        }
    }
}
