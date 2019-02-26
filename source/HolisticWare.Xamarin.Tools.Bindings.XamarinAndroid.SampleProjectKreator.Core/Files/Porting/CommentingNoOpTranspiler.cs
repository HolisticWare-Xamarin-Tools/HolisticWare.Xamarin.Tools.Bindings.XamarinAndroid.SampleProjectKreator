using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Porting.Transpilers
{
    public  partial class CommentingNoOpTranspiler : Transpiler
    {
        public CommentingNoOpTranspiler()
            : base()
        {
        }

        public override IEnumerable<string> Transpile(string[] lines)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                yield return string.Format("// mc++ {0}", lines[i]);
            }
        }
    }
}
