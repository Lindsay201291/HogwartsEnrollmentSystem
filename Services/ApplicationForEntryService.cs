using System.Collections.Generic;
using HogwartsEnrollmentSystem.Models;
using System;
using System.Linq;

namespace HogwartsEnrollmentSystem.Services
{
    public class ApplicationForEntryService
    {
        List<ApplicationForEntry> _applicationForEntryList;
        int idSequence = 1;
        const int maxLengthForApplicantName = 20;
        const int maxLengthForApplicantSurname = 20;
        const int maxNumOfDigitsForAge = 2;
        const int maxNumOfDigitsForId = 10;
        public readonly string[] houses = { "GRYFFINDOR", "HUFFLEPUFF", "RAVENCLAW", "SLYTHERIN"};

        public ApplicationForEntryService()
        {
            _applicationForEntryList = new List<ApplicationForEntry>();
        }

        public long GetAutoincrementId() {
            return idSequence++;
        }

        public List<ApplicationForEntry> GetApplicationsForEntry()
        {
            return _applicationForEntryList;
        }

        public void AddApplicationForEntry(ApplicationForEntry applicationForEntry)
        {
            _applicationForEntryList.Add(applicationForEntry);
        }

        public void UpdateApplicationForEntry(ApplicationForEntry oldElement, 
                                                ApplicationForEntry updatedApplicationForEntry)
        {
            oldElement.ApplicantId = updatedApplicationForEntry.ApplicantId;
            oldElement.ApplicantName = updatedApplicationForEntry.ApplicantName;
            oldElement.ApplicantSurname = updatedApplicationForEntry.ApplicantSurname;
            oldElement.ApplicantAge = updatedApplicationForEntry.ApplicantAge;
            oldElement.ApplicantHouse = updatedApplicationForEntry.ApplicantHouse;
        }

        public void DeleteApplicationForEntry(ApplicationForEntry elementToRemove)
        {
            _applicationForEntryList.Remove(elementToRemove);
        }

        public bool ValidateRequestData(ApplicationForEntry applicationForEntry) {

            //bool isApplicantIdRepeating = true;
            bool isTheApplicantValidName = false;
            bool isTheApplicantValidSurname = false;
            bool isTheApplicantValidAge = false;
            bool isTheApplicantValidId = false;
            bool houseWasFound = false;

            int numOfDigitsForAge;
            int numOfDigitsForId;
            int posOfHouseInArray;

            //var obj = _applicationForEntryList.FirstOrDefault(x => x.ApplicantId == applicationForEntry.ApplicantId);
            numOfDigitsForAge = applicationForEntry.ApplicantAge.ToString().Length;
            numOfDigitsForId = applicationForEntry.ApplicantId.ToString().Length;
            posOfHouseInArray = Array.IndexOf(houses, applicationForEntry.ApplicantHouse.ToUpper());

            /*if (obj == null) {
                isApplicantIdRepeating = false;
            } else if (obj.Id == applicationForEntry.Id) {
                isApplicantIdRepeating = false;
            }*/

            if (applicationForEntry.ApplicantName.Length <= maxLengthForApplicantName) {
                isTheApplicantValidName = true;
            }

            if (applicationForEntry.ApplicantSurname.Length <= maxLengthForApplicantSurname) {
                isTheApplicantValidSurname = true;
            }

            if (numOfDigitsForAge <= maxNumOfDigitsForAge) {
                isTheApplicantValidAge = true;
            }

            if (numOfDigitsForId <= maxNumOfDigitsForId) {
                isTheApplicantValidId = true;
            }

            if (posOfHouseInArray > -1) {
                houseWasFound = true;
            }

            if ((isTheApplicantValidName) && (isTheApplicantValidSurname) 
                && (isTheApplicantValidAge) && (isTheApplicantValidId) && (houseWasFound)) {
                return true;
            } else {
                return false;
            }
        }
    }
}