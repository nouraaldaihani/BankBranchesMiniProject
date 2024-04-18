using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class NewBranchForm
    {
            [Required]
            public int Id { get; set; }

            [Required]
            public string LocationURL { get; set; }
            [Required]
            public string LocationName { get; set; }
            [Required]
            public string BranchManager { get; set; }
            [Required]
            public string EmployeeCount { get; set; }
          
        }
    
}
