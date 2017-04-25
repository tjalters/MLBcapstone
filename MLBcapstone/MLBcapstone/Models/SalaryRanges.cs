using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLBcapstone.Models
{
    public class SalaryRange
    {
        public SalaryRange TeamSalary { get; set; }
        //[ForeignKey("SalaryRange")]
        [Display(Name = "Salary Range")]
        [Required]
        public int SalaryRangeId { get; set; }

        public IEnumerable<SalaryRange> SalaryRanges { get; set; }
    }
}