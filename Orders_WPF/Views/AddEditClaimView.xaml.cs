using MahApps.Metro.Controls;
using Claims_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Claims_WPF.Models;

namespace Claims_WPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditClaimView.xaml
    /// </summary>
    public partial class AddEditClaimView : MetroWindow
    {
        public AddEditClaimView(Claim claim = null)
        {
            InitializeComponent();
            DataContext = new AddEditClaimViewModel(claim);
        }
    }
}
