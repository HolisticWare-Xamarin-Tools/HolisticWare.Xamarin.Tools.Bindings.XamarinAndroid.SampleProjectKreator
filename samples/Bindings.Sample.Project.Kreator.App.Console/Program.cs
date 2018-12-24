using System;

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core;

namespace Bindings.Sample.Project.Kreator.App.Console
{
    class Program
    {
        static string path =
            // "/Projects/hw-tools/Kreator/source/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.Core.csproj"
            // "/Projects/hw-tools/Kreator/samples/Bindings.Sample.Project.Kreator.App.Console/Bindings.Sample.Project.Kreator.App.Console.csproj"
            "/Projects/hw-tools/Kreator/samples/App.XamarinAndroid/App.XamarinAndroid.csproj"
            ;

        static void Main(string[] args)
        {
            ProjectKreator pk = new ProjectKreator();
            pk.Load(path);

            return;
        }
    }
}
