using System;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using Monthly_Claim_System.Models;

namespace Monthly_Claim_System
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Claim> Claims { get; set; } = new ObservableCollection<Claim>();
        private string selectedFilePath = "";

        public MainWindow()
        {
            InitializeComponent();
            lstClaims.ItemsSource = Claims;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported files (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                txtFileName.Text = System.IO.Path.GetFileName(selectedFilePath);
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHours.Text) || string.IsNullOrWhiteSpace(txtRate.Text))
            {
                MessageBox.Show("Please enter Hours Worked and Hourly Rate.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(txtHours.Text, out double hours) || !double.TryParse(txtRate.Text, out double rate))
            {
                MessageBox.Show("Please enter valid numbers for Hours and Rate.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a supporting document.", "File Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Claim newClaim = new Claim
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Hours = hours,
                Rate = rate,
                Total = hours * rate,
                Notes = txtNotes.Text,
                FileName = System.IO.Path.GetFileName(selectedFilePath),
                Status = "Submitted"
            };

            Claims.Add(newClaim);
            GlobalData.PendingClaims.Add(newClaim);

            MessageBox.Show($"Claim submitted successfully!\nTotal: R {newClaim.Total:F2}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Reset form
            txtHours.Clear();
            txtRate.Clear();
            txtNotes.Clear();
            txtFileName.Text = "No file chosen";
            selectedFilePath = "";
        }

        private void OpenApprovalView_Click(object sender, RoutedEventArgs e)
        {
            // Create ApprovalWindow instance directly
            var approvalWindow = new ApprovalWindow();

            approvalWindow.Show();
        }
    }
}