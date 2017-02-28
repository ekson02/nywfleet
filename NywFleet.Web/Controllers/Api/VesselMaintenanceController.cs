using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using NywFleet.Core.Models;
using NywFleet.Data.DataContext;

namespace NywFleet.Web.Controllers.Api {
    public class VesselMaintenanceController : BaseApiController {
        private NyFleetContext db = new NyFleetContext();

        // GET: api/VesselMaintenances
        public IQueryable<VesselMaintenance> GetVesselMaintenance() {
            return db.VesselMaintenance;
        }

        // GET: api/VesselMaintenances/5
        [ResponseType(typeof(VesselMaintenance))]
        public IHttpActionResult GetVesselMaintenance(int id) {
            VesselMaintenance vesselMaintenance = db.VesselMaintenance.Find(id);
            if (vesselMaintenance == null) {
                return NotFound();
            }

            return Ok(vesselMaintenance);
        }

        // PUT: api/VesselMaintenances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVesselMaintenance(int id, VesselMaintenance vesselMaintenance) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != vesselMaintenance.VesselMaintenanceId) {
                return BadRequest();
            }

            db.Entry(vesselMaintenance).State = EntityState.Modified;

            try {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                if (!VesselMaintenanceExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VesselMaintenances
        [ResponseType(typeof(VesselMaintenance))]
        public IHttpActionResult Post(VesselMaintenance vesselMaintenance) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            vesselMaintenance.UsersId = CurrentUserId;
            vesselMaintenance.MaintenanceDate=DateTime.Now;
            Uow.VesselMaintenance.Add(vesselMaintenance);
            Uow.Commit();
            
            return CreatedAtRoute("DefaultApi", new { id = vesselMaintenance.VesselMaintenanceId }, vesselMaintenance);
        }



        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VesselMaintenanceExists(int id) {
            return db.VesselMaintenance.Count(e => e.VesselMaintenanceId == id) > 0;
        }
    }
}