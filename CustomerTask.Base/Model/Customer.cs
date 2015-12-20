namespace CustomerTask.Base.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}

//- Name
//- Surname
//- Telephone Number
//- Address