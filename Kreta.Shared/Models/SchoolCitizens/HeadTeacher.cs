
using System.Xml.Linq;

namespace Kreta.Shared.Models.SchoolCitizens
{
    public class HeadTeacher : IDbEntity<HeadTeacher>
    {
        public HeadTeacher()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            BirthDay = DateTime.MinValue;
            Allowance = 0;
            IsAssistant = false;
        }
        public HeadTeacher(Guid id, string name, DateTime birthDay, int allowance, bool isAssistant)
        {
            Id = id;
            Name = name;
            BirthDay = birthDay;
            Allowance = allowance;
            IsAssistant = isAssistant;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int Allowance { get; set; }
        public bool IsAssistant { get; set; }

        public bool HasId => Id != Guid.Empty;
    }
}