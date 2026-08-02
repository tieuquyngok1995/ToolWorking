using WorkBuddy.Forms;

namespace WorkBuddy;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        Application.ThreadException += OnThreadException;
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

        Application.Run(new MainForm());
    }

    private static void OnThreadException(object? sender, ThreadExceptionEventArgs e) => HandleException(e.Exception);

    private static void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e) => HandleException(e.ExceptionObject as Exception);

    private static void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        e.SetObserved();
        HandleException(e.Exception);
    }

    private static void HandleException(Exception? ex) => MessageBox.Show(ex?.Message ?? "An unknown error has occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}