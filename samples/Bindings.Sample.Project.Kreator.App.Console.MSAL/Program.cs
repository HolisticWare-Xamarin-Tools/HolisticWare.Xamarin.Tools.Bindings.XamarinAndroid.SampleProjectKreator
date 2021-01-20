using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.CLI;

namespace Bindings.Sample.Project.Kreator.App.Console.MSAL
{
    class Program
    {
        static ProjectKreator project_kreator = null;

        static void Main(string[] args)
        {
            project_kreator = new ProjectKreator()
            {
                InputFolderPath = $"../../input-gradle-java/MSAL/ms-identity-android-java-master/",
                OutputFolderPath = $"../../output-xamarin-android/MSAL/",
                ProjectName = "MSAL.Sample"
            };

            project_kreator.CreateProject();

            return;
        }
    }
}
