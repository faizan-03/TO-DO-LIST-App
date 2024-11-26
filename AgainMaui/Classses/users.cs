using SQLite;
namespace AgainMaui.Classses
{
    [Table("Users")]
    public class Users
    {
        [PrimaryKey]
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Pass")]
        public int Pass { get; set; }
    }
}
