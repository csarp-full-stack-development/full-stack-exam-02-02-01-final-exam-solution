using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Shared.Assamblers
{
    public class HeadTeacherAssambler : Assambler<HeadTeacher, HeadTeacherDto>
    {
        public override HeadTeacherDto ToDto(HeadTeacher model)
        {
            return model.ToDto();
        }

        public override HeadTeacher ToModel(HeadTeacherDto dto)
        {
            return dto.ToModel();
        }
    }
}
