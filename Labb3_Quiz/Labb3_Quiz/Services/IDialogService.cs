using Labb3_Quiz.ViewModels;

namespace Labb3_Quiz.Services;

public interface IDialogService
{
    void ShowInfo(string message, string title = "Information");
    void ShowError(string message, string title = "Error");
    bool ShowConfirm(string message, string title = "Confirm");
    T? ShowDialog<T>() where T : System.Windows.Window;
    void ShowImportQuestionsDialog(
        Func<QuestionPackViewModel?> getSelected,
        Func<Task> saveAll);
}

