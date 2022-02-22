using SQLite;

namespace DesktopContactApp.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed, MaxLength(100)]
        public string Name { get; set; }
        public string LastName { get; set; }

        [Ignore]
        public string FullName
        {
            get
            {
                return Name + ' ' + LastName;
            }
        }
        [MaxLength(150)]
        public string? Email { get; set; }
        [MaxLength(15)]
        public string? Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }

    }
}
