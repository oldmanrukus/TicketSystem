namespace TicketingSystem
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }  // "Admin", "SupportAgent", or "Client"
        public int? ClientID { get; set; } // Only for client users
    }
}
