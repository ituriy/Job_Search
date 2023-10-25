namespace Job_Search
{
    public class Jobs
    {
        public int ID {  get; set; }
        public int PersonID { get; set; }
        public string OrganisationType { get; set; }
        public int OrganisationID { get; set; }
        public int PositionID { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }
}
