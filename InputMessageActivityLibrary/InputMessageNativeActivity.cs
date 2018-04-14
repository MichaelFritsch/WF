using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputMessageActivityLibrary
{
    public class InputMessageNativeActivity<T> : NativeActivity
    {
        public InArgument<string> bookmarkName { get; set; }
        public OutArgument<T> result { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(bookmarkName.Get(context),
                new BookmarkCallback(OnResumeBookmark));
        }

        public void OnResumeBookmark(NativeActivityContext context,
            Bookmark bookmark,
            object obj)
        {
            result.Set(context, (T) obj);
        }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }
    }
}
