namespace Kreta.Console.Model
{
    public class AwardedStudent
    {
        public AwardedStudent(string name, int age, int award, bool isOneAward)
        {
            Name = name;
            Age = age;
            Award = award;
            MonthlyPayment = isOneAward;
            SchoolClass = string.Empty;
        }

        public AwardedStudent(string name, int age, int award, bool montlyPayment, string schoolClass, bool isWooman)
        {
            Name = name;
            Age = age;
            Award = award;
            MonthlyPayment = montlyPayment;
            SchoolClass = schoolClass;
            IsWooman = isWooman;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Award { get; set; }
        public bool MonthlyPayment { get; set; }
        public bool IsWooman {  get; set; }
        public bool IsAdult => Age >= 18;
        public string SchoolClass { get; set; }

        public static bool IsYounger(AwardedStudent student1, AwardedStudent student2)
        {
            if (student1.Age < student2.Age)
                return true;
            return false;
        }

        public override string ToString()
        {
            string isOneString = "Az ösztöndíj egyszeri juttatás!";
            if (MonthlyPayment) 
            {
                isOneString = "Az ösztöndíj havi juttatás!";
            }
            return $"{Name} {Age} éves és {Award} Ft ösztöndíjat nyert! {isOneString}";
        }

    }
}
