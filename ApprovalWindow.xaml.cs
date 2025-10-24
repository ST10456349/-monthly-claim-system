using System.Windows;
using System.Windows.Controls;
using Monthly_Claim_System.Models;

namespace Monthly_Claim_System
{
    public partial class ApprovalWindow : Window
    {
        public ApprovalWindow()
        {
            InitializeComponent();
            PendingClaimsGrid.ItemsSource = GlobalData.PendingClaims;
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (PendingClaimsGrid.SelectedItem is Claim selectedClaim)
            {
                selectedClaim.Status = "Approved by Coordinator";
                MessageBox.Show("Claim has been approved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please select a claim first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (PendingClaimsGrid.SelectedItem is Claim selectedClaim)
            {
                selectedClaim.Status = "Rejected";
                MessageBox.Show("Claim has been rejected.", "Decision Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Please select a claim first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshData()
        {
            PendingClaimsGrid.Items.Refresh();
        }
    }
}