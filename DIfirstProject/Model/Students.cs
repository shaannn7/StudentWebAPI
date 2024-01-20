using System.ComponentModel.DataAnnotations;

namespace DIfirstProject.Model
{
    public class Students
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30,MinimumLength =3 , ErrorMessage ="UserName must contain atleast 3-30 characters")]
        public string Name { get; set; }

        [Required]
        [Range(14,30,ErrorMessage ="Class 10 Students age between 14 - 30")]
        public int Age { get; set; }

    }


}
