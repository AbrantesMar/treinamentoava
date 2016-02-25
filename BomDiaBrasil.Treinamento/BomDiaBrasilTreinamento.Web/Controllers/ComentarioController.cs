using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BomDiaBrasilTreinamento.Web.Models;
using Dominio;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Runtime.Serialization.Json;

namespace BomDiaBrasilTreinamento.Web.Controllers
{
    public class ComentarioController : Controller
    {
        private BomDiaBrasilContext db = new BomDiaBrasilContext();

        // GET: Comentario
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            #region Consulta JSON
            HttpClient httpClientTeste = new HttpClient();
            httpClientTeste.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
            //UriApi
            var uriId = "http://localhost:33157/api/ComentariosApi";

            string ResponseStringTeste = await httpClientTeste.GetStringAsync(new Uri(uriId));
            var jsonTeste = JsonConvert.DeserializeObject<List<Comentario>>(ResponseStringTeste);

            #endregion
            #region Consultar com ADO
            //string connectionString =
            //"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=BomDiaBrasilTreinamento; Integrated Security=true";

            //// Provide the query string with a parameter placeholder.
            //string queryString = "SELECT Id,Nome,Email,Descricao FROM Comentarios";

            //// Specify the parameter value.
            ////int paramValue = 5;

            //// Create and open the connection in a using block. This
            //// ensures that all resources will be closed and disposed
            //// when the code exits.
            //using (SqlConnection connection =
            //    new SqlConnection(connectionString))
            //{
            //    // Create the Command and Parameter objects.
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    //command.Parameters.AddWithValue("@id", paramValue);

            //    // Open the connection in a try/catch block. 
            //    // Create and execute the DataReader, writing the result
            //    // set to the console window.
            //    try
            //    {
            //        connection.Open();
            //        SqlDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            Console.WriteLine("Id: \t{0} Nome: \t{1} Email: \t{2}", reader[0], reader[1], reader[2]);
            //        }
            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    Console.ReadLine();
            //}
            #endregion

            #region Retorno com json
            return View(jsonTeste);
            #endregion
            #region Retorno com entity
            //return View(db.Comentarios.ToList());
            #endregion
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Descricao")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                #region Criação com WebApi
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var json_object = JsonConvert.SerializeObject(comentario);
                    var response = await client.PostAsync("http://localhost:33157/api/ComentariosApi/", new StringContent(json_object.ToString(), Encoding.Unicode, "application/json"));
                    var dataReceived = response.StatusCode;
                    var dRec = new DataContractJsonSerializer(typeof(Comentario));
                }
                #endregion

                #region Criação com entity
                //db.Comentarios.Add(comentario);
                //db.SaveChanges();
                #endregion

                return RedirectToAction("Index");
            }

            return View(comentario);
        }

        // GET: Comentario/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            #region Consulta com WepApi Json
            HttpClient httpClientTeste = new HttpClient();
            httpClientTeste.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
            //UriApi
            var uriId = "http://localhost:33157/api/ComentariosApi/" + id;

            string ResponseStringTeste = await httpClientTeste.GetStringAsync(new Uri(uriId));
            var jsonTeste = JsonConvert.DeserializeObject<Comentario>(ResponseStringTeste);
            Comentario comentario = jsonTeste;
            #endregion
            //Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Descricao")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
