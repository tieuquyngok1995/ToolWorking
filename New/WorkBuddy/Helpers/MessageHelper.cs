namespace WorkBuddy.Helpers;

public static class MessageHelper
{
    /// <summary>
    /// Displays an informational message box or logs an info message.
    /// </summary>
    /// <param name="message">The content of the informational message to display.</param>
    /// <param name="title">The title of the notification header. Defaults to "Notification".</param>
    public static void Info(string message, string title = "Notification") => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

    /// <summary>
    /// Displays an informational message box or logs an warning message.
    /// </summary>
    /// <param name="message">The content of the warning message to display.</param>
    /// <param name="title">The title of the warning header. Defaults to "Warning".</param>
    public static void Warning(string message, string title = "Warning") => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    /// <summary>
    /// Displays an informational message box or logs an error message.
    /// </summary>
    /// <param name="message">The content of the error message to display.</param>
    /// <param name="title">The title of the error header. Defaults to "Error".</param>
    public static void Error(string message, string title = "Error") => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

    /// <summary>
    /// Displays an informational message box or logs an confirm message.
    /// </summary>
    /// <param name="message">The content of the confirm message to display.</param>
    /// <param name="title">The title of the confirm header. Defaults to "Confirm".</param>
    public static bool Confirm(string message, string title = "Confirm") => MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
}