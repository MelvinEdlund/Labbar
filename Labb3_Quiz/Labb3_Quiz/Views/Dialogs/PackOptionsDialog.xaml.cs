using System.Windows;
using Labb3_Quiz.Models;
using Labb3_Quiz.ViewModels;

namespace Labb3_Quiz.Views.Dialogs;

/// <summary>
/// Dialog for editing pack options (name, difficulty, time per question).
/// </summary>
public partial class PackOptionsDialog : Window
{
    public PackOptionsDialog(QuestionPackViewModel packViewModel)
    {
        InitializeComponent();
        DataContext = packViewModel;
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}

