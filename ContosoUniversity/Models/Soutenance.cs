using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{

    public class Soutenance
    {
        public int SoutenanceID { get; set; }
        public int StageID { get; set; }
        public int InstructorID { get; set; }
        

        public Stage stage { get; set; }
        public Instructor Turor  { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string TitreDeSoutenance { get; set; }
        
    }
}