namespace StaticEntity.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public static Customer AddCustomer(string name,string surName)
        {
            return new Customer() { Name = name,Surname = surName };
        }
    }
}