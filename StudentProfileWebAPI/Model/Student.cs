using System.ComponentModel.DataAnnotations;

namespace StudentProfileWebAPI.Model
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string Subject { get; set; }
        public float Grade{ get; set; }
    }
}
