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
    public class DistrictController : ApiController
    {
        private HydrantConnectionEntities db = new HydrantConnectionEntities();

        // GET api/District
        public IEnumerable<District> GetDistricts()
        {
            return db.Districts.AsEnumerable();
        }

        // GET api/District/5
        public IEnumerable<HydrantLocation> GetDistrict(int id)
        {
            return db.HydrantLocations.Include(d => d.District).Include(c => c.City).Where(d=>d.District.district_Id.Equals(id)).ToList();//Districts.Find(id);
            //if (district == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}

           // return district;
        }

        // PUT api/District/5
        public HttpResponseMessage PutDistrict(int id, District district)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != district.district_Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(district).State = EntityState.Modified;

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

        // POST api/District
        public HttpResponseMessage PostDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, district);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = district.district_Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/District/5
        public HttpResponseMessage DeleteDistrict(int id)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Districts.Remove(district);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, district);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}