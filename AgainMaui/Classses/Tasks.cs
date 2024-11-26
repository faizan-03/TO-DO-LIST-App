using SQLite;

namespace AgainMaui.Classses
{
    [Table("Tasks")]
    public class Tasks
    {
        [Column("Title")]
        [PrimaryKey]
        public string Title { get; set; }
        [Column("DueDate")]
        public string DueDate { get; set; }
        [Column("DueTime")]
        public string DueTime { get; set; }
        [Column("CreationDate")]
        public string CreationDate { get; set; }
        [Column("CreationTime")]
        public string CreationTime { get; set; }
        [Column("IsPrioritized")]
        public bool IsPrioritized { get; set; } 
    }
}
