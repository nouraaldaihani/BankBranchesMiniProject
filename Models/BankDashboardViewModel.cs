﻿namespace WebApplication4.Models
{
    public class BankDashboardViewModel
    {
        public int TotalBranches { get; set; }
        public int TotalEmployees { get; set; }
        public BankBranch BranchWithMostEmployees { get; set; }
        public List<BankBranch> BranchList { get; set; }
    }
}
