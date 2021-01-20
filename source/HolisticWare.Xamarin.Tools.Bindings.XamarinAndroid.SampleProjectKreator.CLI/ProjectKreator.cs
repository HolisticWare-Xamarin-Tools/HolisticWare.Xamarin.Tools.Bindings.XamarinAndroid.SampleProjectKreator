namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.SampleProjectKreator.CLI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Build.BuildEngine;
    using Microsoft.Build.Evaluation;
    using Microsoft.Build.Execution;

    public partial class ProjectKreator : SampleProjectKreator.ProjectKreator
    {
        public ProjectKreator()
        {
            OptionSet = this.Options();

            return;
        }

        public Mono.Options.OptionSet OptionSet
        {
            get;
            set;
        }
    }
}
