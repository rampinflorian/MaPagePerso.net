using System;

namespace MaPagePerso.net.Services
{
    public class GetYearsService
    {
        public int GetYearsOld()
        {
            return GetDiffBetweenNow(new DateTime(1990, 6, 19));
        }

        public int GetExperienceYears()
        {
            return GetDiffBetweenNow(new DateTime(2012, 9, 25));
        }

        private static int GetDiffBetweenNow(DateTime anniversaryDate)
        {
            DateTime now = DateTime.Today;
            var age = now.Year - anniversaryDate.Year;
            if (anniversaryDate > now.AddYears(-age)) 
                age--;
            return age;
        }
    }
}