using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SpaSample.Models;

namespace SpaSample.Controllers
{
    public class HydrantLocationController : ApiController
    {
        private HydrantConnectionEntities db = new HydrantConnectionEntities();

        // GET api/HydrantLocation
        public IEnumerable<HydrantLocation> GetHydrantLocations()
        {
            var hydrantlocations = db.HydrantLocations.Include(h => h.City).Include(h => h.District);
            return hydrantlocations.AsEnumerable();
        }

        // GET api/HydrantLocation/5
        public HydrantLocation GetHydrantLocation(int id)
        {
            HydrantLocation hydrantlocation = db.HydrantLocations.Find(id);
            if (hydrantlocation == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return hydrantlocation;
        }

        // PUT api/HydrantLocation/5
        public HttpResponseMessage PutHydrantLocation(int id, HydrantLocation hydrantlocation)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != hydrantlocation.hydrant_Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(hydrantlocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/HydrantLocation
        public HttpResponseMessage PostHydrantLocation(HydrantLocation hydrantlocation)
        {
            if (ModelState.IsValid)
            {
                db.HydrantLocations.Add(hydrantlocation);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, hydrantlocation);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hydrantlocation.hydrant_Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/HydrantLocation/5
        public HttpResponseMessage DeleteHydrantLocation(int id)
        {
            HydrantLocation hydrantlocation = db.HydrantLocations.Find(id);
            if (hydrantlocation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.HydrantLocations.Remove(hydrantlocation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, hydrantlocation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}