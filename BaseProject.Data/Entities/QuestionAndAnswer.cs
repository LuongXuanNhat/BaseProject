namespace BaseProject.Data.Entities
{
    public class QuestionAndAnswer
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public int LocationId { get; set; }
        public string? UserName { get; set; }
        public string? MessageText { get; set; }
        public string? Date { get; set; }

        public Location location { get; set; }
    }
}
