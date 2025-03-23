namespace TicketingSystem
{
    public class Client
    {
        public int ClientID { get; set; }  // This may be set by the database after insertion.
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }
}