using HogwartsEnrollmentSystem.Models;
using HogwartsEnrollmentSystem.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsEnrollmentSystem.Controllers
{
    [ApiController]
    [Route("api/application-for-entry")]
    public class ApplicationForEntryController : ControllerBase
    {
        ApplicationForEntryService _applicationForEntryService;
        
        public ApplicationForEntryController(ApplicationForEntryService applicationForEntryService)
        {
            this._applicationForEntryService = applicationForEntryService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this._applicationForEntryService.GetApplicationsForEntry());
        }

        [HttpPost]
        public ActionResult Post(ApplicationForEntry applicationForEntry)
        {
            bool isApplicantIdRepeating = true;

            var obj = this._applicationForEntryService.GetApplicationsForEntry().FirstOrDefault(x => x.ApplicantId == applicationForEntry.ApplicantId);

            if (obj == null) {
                isApplicantIdRepeating = false;
            }

            if ((!isApplicantIdRepeating) && (this._applicationForEntryService.ValidateRequestData(applicationForEntry))) {
                
                applicationForEntry.Id = this._applicationForEntryService.GetAutoincrementId();
                this._applicationForEntryService.AddApplicationForEntry(applicationForEntry);
                return Ok();
            } else {
                return UnprocessableEntity("Invalid request data");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ApplicationForEntry applicationForEntry)
        {
            bool isApplicantIdRepeating = true;
            var obj = this._applicationForEntryService.GetApplicationsForEntry().FirstOrDefault(x => x.Id == id);

            if (obj == null) {
                return NotFound();
            } else if (this._applicationForEntryService.ValidateRequestData(applicationForEntry)) {

                var element = this._applicationForEntryService.GetApplicationsForEntry().FirstOrDefault(x => x.ApplicantId == applicationForEntry.ApplicantId);

                if (element == null) {
                    isApplicantIdRepeating = false;
                } else if (element.Id == id) {
                    isApplicantIdRepeating = false;
                }

                if (!isApplicantIdRepeating) {
                    this._applicationForEntryService.UpdateApplicationForEntry(obj, applicationForEntry);
                    return Ok();
                } else { 
                    return UnprocessableEntity("Invalid request data");
                }
                
            } else {
                return UnprocessableEntity("Invalid request data");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {

            var obj = this._applicationForEntryService.GetApplicationsForEntry().FirstOrDefault(x => x.Id == id);

            if(obj == null){
                return NotFound();
            } else {
                this._applicationForEntryService.DeleteApplicationForEntry(obj);
                return Ok();
            }
        }
    }
}