using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Porting.Transpilers
{
    public abstract partial class Transpiler
    {
        public Transpiler()
            : base()
        {
        }

        public virtual string LoadFile(string filename)
        {
            string content = null;

            return content;
        }

        public abstract IEnumerable<string> Transpile(string[] lines);

    }    
}
