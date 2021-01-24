using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaPagePerso.net.Form
{
    [NotMapped]
    public class Mailer
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress, Required]
        public string Mail { get; set; }
        [Required]
        public string Content { get; set; }
    }
}