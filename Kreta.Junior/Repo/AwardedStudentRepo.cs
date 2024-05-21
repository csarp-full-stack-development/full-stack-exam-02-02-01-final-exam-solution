using Kreta.Junior.Model;

namespace Kreta.Junior.Repo
{
    public class AwardedStudentRepo
    {
        private List<AwardedStudent> _awardedStudents = new List<AwardedStudent>();

        public void Add(AwardedStudent student)
        {
            _awardedStudents.Add(student);
        }

        public double GetAwardAvarage()
        {
            return Math.Round(_awardedStudents.Where(student => student.MonthlyPayment).Average(student => student.Award)
                , 2);
        }

        public int GetNumberOfGender(bool isWoman)
        {
            return _awardedStudents.Count(student => student.IsWooman == isWoman);
        }

        public int GetOneTimePaymentInYear()
        {
            return _awardedStudents
                .Where(student => !student.MonthlyPayment)
                .Sum(studnet => studnet.Award);
        }

        public int GetAnnualScholarshipAmount()
        {
            int monthlyAmounts = _awardedStudents
                .Where(student => student.MonthlyPayment)
                .Sum(student => student.Award) * 10;
            int oneTimePayment = _awardedStudents
                .Where(student => !student.MonthlyPayment)
                .Sum(student => student.Award);
            return monthlyAmounts + oneTimePayment;

        }

        public List<ScholarshipPerScoolClass> GetScholarshipPaidPerScoolClass()
        {
            List<ScholarshipPerScoolClass> scholarshipPerScoolClasses = new List<ScholarshipPerScoolClass>();
            List<string> schoolClasses = _awardedStudents.Select(student => student.SchoolClass).Distinct().ToList();
            foreach (string schoolClass in schoolClasses)
            {
                ScholarshipPerScoolClass ssc = new ScholarshipPerScoolClass();
                ssc.SchoolClass = schoolClass;
                ssc.Scholarship =
                    (_awardedStudents
                    .Where(student => student.SchoolClass == schoolClass && student.MonthlyPayment)
                    .Sum(student => student.Award) * 10)
                    +
                    (_awardedStudents
                    .Where(student => student.SchoolClass == schoolClass && !student.MonthlyPayment)
                    .Sum(student => student.Award));
                scholarshipPerScoolClasses.Add(ssc);
            }
            return scholarshipPerScoolClasses;
        }
        public int MaxMinAmount(string schoolClass, bool isMax)
        {
            List<string> schoolClasses = _awardedStudents.Select(student => student.SchoolClass).ToList();
            if (!schoolClasses.Contains(schoolClass))
                return -1;
            if (isMax)
                return _awardedStudents
                    .Where(student => student.SchoolClass == schoolClass)
                    .Select(student => student.Award)
                    .Max();
            else
                return _awardedStudents
                    .Where(student => student.SchoolClass == schoolClass)
                    .Select(student => student.Award)
                    .Min();
        }

        public List<StudentScholarship> GetAdultStudentScholarship()
        {
            List<StudentScholarship> studentScholarships = new List<StudentScholarship>();
            foreach (var student in _awardedStudents)
            {
                if (student.IsAdult)
                    studentScholarships.Add(new StudentScholarship
                    {
                        Name = student.Name,
                        Award = student.Award,
                    });
            }
            return studentScholarships;
        }

        public string GetYoungestAwardedStudentName()
        {
            if (!_awardedStudents.Any())
                return string.Empty;
            int min = _awardedStudents.Select(_awardedStudents => _awardedStudents.Age).Min();
            return _awardedStudents.Where(student => student.Age == min).First().Name;

        }
    }
}
