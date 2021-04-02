namespace HogwartsEnrollmentSystem.Models
{
    public class ApplicationForEntry
    {
        public long Id { get; set; }

        public long ApplicantId { get; set; }

	    public string ApplicantName { get; set; }

        public string ApplicantSurname { get; set; }

	    public int ApplicantAge { get; set; }

	    public string ApplicantHouse { get; set; }
	
    }
}