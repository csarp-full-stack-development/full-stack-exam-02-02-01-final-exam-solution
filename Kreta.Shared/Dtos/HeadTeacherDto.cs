namespace Kreta.Shared.Dtos
{
    public class HeadTeacherDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public int Allowance { get; set; }
        public bool IsAssistant { get; set; } = false;
    }
}
