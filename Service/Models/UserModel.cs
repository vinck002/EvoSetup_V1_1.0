namespace Data.Models
{
    public class UserModel
    {
      
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Types { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public int countryid { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public int UserProfileId { get; set; }
        public string UserProfile { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int SalesFloorId { get; set; }
        public string SalesFloor { get; set; }

    }
}
