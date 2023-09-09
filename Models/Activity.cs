//namespace DigitalMemory.Models
//{
//    public class Activity : EntityBase
//    {
//        public enum State
//        {
//            NotStarted = 0,
//            Started = 1,
//            Completed = 2
//        }

//        public Activity(string name)
//        {
//            Name = name;
//        }

//        public required string Name { get; set; }
//        public string? Description { get; set; }
//        public DateTime? Start { get; set; }
//        public DateTime? End { get; set; }
//        public Entry? Entry { get; set; }
//        public Diary? Diary { get; set; }
//        public State Status { get; set; } = State.NotStarted;
//    }
//}