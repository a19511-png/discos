namespace discos.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Login(int id, string username, string passwd)
        {
            Id = id;
            Username = username;
            Password = passwd;
        }
    }
}
