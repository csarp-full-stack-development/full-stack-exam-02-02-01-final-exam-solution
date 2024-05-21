using Kreta.Console.Model;
using Kreta.Console.Repo;

namespace Kreta.Console.ViewModel
{
    public class AwardedStudentViewModel
    {
        AwardedStudent tunde = new AwardedStudent("Üveges Tünde", 17, 1525, true, "9.a", true);
        AwardedStudent denes = new AwardedStudent("Dolgos Dénes", 18, 5000, false, "9.a", false);

        AwardedStudentRepo awardedStudentRepo = new AwardedStudentRepo();

        public AwardedStudentViewModel()
        {
            awardedStudentRepo.Add(tunde);
            awardedStudentRepo.Add(denes);
            awardedStudentRepo.Add(new AwardedStudent("Szorgalmas Szonja", 16, 6527, true, "9.b", true));
            awardedStudentRepo.Add(new AwardedStudent("Mindenttudo Misi", 16, 6514, true, "9.b", false));
        }

        public string TundeStudent => tunde.ToString();
        public string DenesStudent => denes.ToString();

        public string Older
        {
            get
            {
                if (tunde.Age > denes.Age)
                    return $"{tunde.Name} idősebb, mint {denes.Name}!";
                else if (tunde.Age < denes.Age)
                    return $"{denes.Name} idősebb, mint {tunde.Name}!";
                else
                    return "A két diák ugyan annyi éves!";
            }
        }

        public string AwardAvarage
        {
            get
            {
                double avarage = awardedStudentRepo.GetAwardAvarage();
                return $"\nA havi ösztöndíjak átlaga {avarage} Ft!";
            }
        }

        public string NumberOfGender
        {
            get
            {
                string result ="\nÖsztöndíjasok megoszlása nemenként:";
                int numberOfWoman = awardedStudentRepo.GetNumberOfGender(true);
                int numberOfMan = awardedStudentRepo.GetNumberOfGender(false);
                result +=$"\nA fiú diákok száma {numberOfMan} fő.";
                result +=$"\nA lány diákok száma {numberOfWoman} fő.";
                return result;
            }
        }

        public string OneTimePaymentInYear
        {
            get
            {
                int oneTimePaymentInYear = awardedStudentRepo.GetOneTimePaymentInYear();
                return $"\nEgy évben {oneTimePaymentInYear} egyszeri kifizetés történt!";
            }
        }

        public string AnnualScholarshipAmount
        {
            get
            {
                int annualScholarshipAmount = awardedStudentRepo.GetAnnualScholarshipAmount();
                return $"\nEgy ébven kifizetésre kerülő ösztöndíj összege {annualScholarshipAmount} Ft.";
            }
        }

        public string ScholarshipPaidPerScoolClass
        {
            get
            {
                string result = string.Empty;
                List<ScholarshipPerScoolClass> scholarshipPerScoolClasses = awardedStudentRepo.GetScholarshipPaidPerScoolClass();
                if (!scholarshipPerScoolClasses.Any())
                    result+="\nNincs egy osztály sem az adatbázisban!";
                else
                {
                    result += "\nOsztályonként évente a következő ösztöndíj kifizetések történnek:";
                    foreach (ScholarshipPerScoolClass ssc in scholarshipPerScoolClasses)
                    {
                        result += $"\n{ssc.SchoolClass} osztályban {ssc.Scholarship} Ft kifizetés történik.";
                    }
                }
                return result;
            }
        }

        public string AdultStudentScholarship
        {
            get
            {
                string result = string.Empty;
                List<StudentScholarship> studentScholarships = awardedStudentRepo.GetAdultStudentScholarship();
                if (!studentScholarships.Any())
                    result +="\nEgy diáknak sem kell adóigazolást kiállítani!";
                else
                {
                    result += "\nA következő diákoknak kell adóigazolást kiállítani:";
                    foreach (StudentScholarship studentScholarship in studentScholarships)
                        result += $"\n{studentScholarship.Name} ({studentScholarship.Award})";
                }
                return result;
            }
        }
    }
}
