using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{

    public class Stage
    {
        public int StageID { get; set; }
        public int InstructorID { get; set; }
        public int StudentID { get; set; }
        
        [StringLength(50, MinimumLength = 3)]
        public string TitreDeStage { get; set; }
        public String GetTitre() { return TitreDeStage; }

        public Instructor Instructor { get; set; }
        public Student Student { get; set; }
    }
}