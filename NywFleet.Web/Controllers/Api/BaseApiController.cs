using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NywFleet.Data;

namespace NywFleet.Web.Controllers.Api {
    public class BaseApiController : ApiController {
        readonly FleetUow _uow;
        public BaseApiController() {
            _uow = new FleetUow();
        }
        
        public FleetUow Uow => _uow;

        public string CurrentUserId => User.Identity.GetUserId();

        protected ClaimsPrincipal CurrentPrincipal {
            get {
                var user = Request.GetRequestContext().Principal as ClaimsPrincipal;
                return user;
                //return ClaimsPrincipal.Current;
            }
        }

        public bool CheckAccess(string resource, string action) {
            return CurrentPrincipal.Claims.Any() && CurrentPrincipal.HasClaim(resource, action);
        }

        private int GetIntClaimValue(string claimName) {
            var value = GetClaimValue(claimName);
            if (!string.IsNullOrEmpty(value)) {
                int intValue = 0;
                if (Int32.TryParse(value, out intValue)) {
                    return intValue;
                }
            }
            return 0;
        }


        private string GetClaimValue(string claimName) {
            string response = string.Empty;
            var claim = CurrentPrincipal.FindFirst(claimName);
            if (claim != null) {
                response = claim.Value;
            }
            return response;
        }

        protected override void Dispose(bool disposing) {
            if (_uow != null)
                _uow.Dispose();
            base.Dispose(disposing);
        }
    }
}