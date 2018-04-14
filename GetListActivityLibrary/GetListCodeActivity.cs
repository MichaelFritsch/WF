using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetListActivityLibrary
{
    public sealed class GetListCodeActivity : CodeActivity<int>
    {
        public InArgument<int> X { get; set; }
        public InArgument<int> Y { get; set; }

        protected override int Execute(CodeActivityContext context)
        {
            int x = X.Get(context);
            int y = Y.Get(context);

            return x + y;
        }
    }
}
