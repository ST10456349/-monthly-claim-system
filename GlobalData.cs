using Monthly_Claim_System.Models;
using System.Collections.ObjectModel;

namespace Monthly_Claim_System
{
    public static class GlobalData
    {
        public static ObservableCollection<Claim> PendingClaims { get; set; } = new ObservableCollection<Claim>();

        static GlobalData()
        {
            // Sample data for testing
            PendingClaims.Add(new Claim
            {
                Date = "2024-10-15",
                Hours = 8,
                Rate = 250,
                Total = 2000,
                Notes = "Lecture on C# Programming",
                FileName = "lecture_notes.pdf",
                LecturerId = "LEC001",
                Status = "Submitted"
            });
        }
    }
}