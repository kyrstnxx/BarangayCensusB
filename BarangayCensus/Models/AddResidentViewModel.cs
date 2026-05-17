namespace BarangayCensus.Models
{
    public class AddResidentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Occupation { get; set; }
        public bool IsVoter { get; set; }
        public bool IsPWD { get; set; }
        public bool IsSeniorCitizen { get; set; }
    }
}
