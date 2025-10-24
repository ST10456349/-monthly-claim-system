using System.ComponentModel;

namespace Monthly_Claim_System.Models
{
    public class Claim : INotifyPropertyChanged
    {
        private string _status = "Submitted"; // FIX: Initialize with default value

        public string Date { get; set; } = "";
        public double Hours { get; set; }
        public double Rate { get; set; }
        public double Total { get; set; }
        public string Notes { get; set; } = "";
        public string FileName { get; set; } = "";
        public string LecturerId { get; set; } = "LEC001";

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}