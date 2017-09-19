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
    public class HydrantInfoController : ApiController
    {
        private HydrantConnectionEntities db = new HydrantConnectionEntities();

        // GET api/HydrantInfo
        public IEnumerable<HydrantInfo> GetHydrantInfoes()
        {
            return db.HydrantInfoes.AsEnumerable();
        }

        // GET api/HydrantInfo/5
        public HydrantInfo GetHydrantInfo(int id)
        {
            HydrantInfo hydrantinfo = db.HydrantInfoes.Find(id);
            if (hydrantinfo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return hydrantinfo;
        }

        // PUT api/HydrantInfo/5
        public HttpResponseMessage PutHydrantInfo(int id, HydrantInfo hydrantinfo)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != hydrantinfo.hydrant_Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(hydrantinfo).State = EntityState.Modified;

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

        // POST api/HydrantInfo
        public HttpResponseMessage PostHydrantInfo(HydrantInfo hydrantinfo)
        {
            if (ModelState.IsValid)
            {
                db.HydrantInfoes.Add(hydrantinfo);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, hydrantinfo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hydrantinfo.hydrant_Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/HydrantInfo/5
        public HttpResponseMessage DeleteHydrantInfo(int id)
        {
            HydrantInfo hydrantinfo = db.HydrantInfoes.Find(id);
            if (hydrantinfo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.HydrantInfoes.Remove(hydrantinfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, hydrantinfo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}