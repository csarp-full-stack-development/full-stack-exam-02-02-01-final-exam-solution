using Kreta.Shared.Dtos;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Shared.Extensions
{
    public static class HeadTeacherExtension
    {
        public static HeadTeacherDto ToDto(this HeadTeacher model)
        {
            return new HeadTeacherDto
            {
                Id = model.Id,
                Name = model.Name,
                BirthDay = model.BirthDay,
                IsAssistant = model.IsAssistant,
                Allowance= model.Allowance,
            };
        }

        public static HeadTeacher ToModel(this HeadTeacherDto dto)
        {
            return new HeadTeacher
            {
                Id = dto.Id,
                Name = dto.Name,
                BirthDay = dto.BirthDay,
                IsAssistant = dto.IsAssistant,
                Allowance= dto.Allowance,
            };
        }

    }
}
