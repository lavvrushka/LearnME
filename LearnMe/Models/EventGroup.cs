using SQLite;


namespace LearnMe.Models
{
    [Table("EventGroups")]
    public class EventGroup
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("EventId"), NotNull]
        public int EventId { get; set; }

        [Column("GroupId"), NotNull]
        public int GroupId { get; set; }



        public EventGroup() { }

        public EventGroup(int eventId, int groupId)
        {
            EventId = eventId;
            GroupId = groupId;
        }
    }
}
