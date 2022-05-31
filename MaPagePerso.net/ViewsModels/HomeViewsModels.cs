using System.Collections.Generic;
using MaPagePerso.net.Form;
using MaPagePerso.net.Models;

namespace MaPagePerso.net.ViewsModels
{
    public class HomeViewsModels
    {
        public Mailer mailer { get; set; }
        public List<Project> Projects { get; set; }
        public int YearsOld { get; set; }
        public int YearsExperience { get; set; }
    }
}