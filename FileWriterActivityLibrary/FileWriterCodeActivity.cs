using System.Activities;
using System.Threading;

namespace FileWriterActivityLibrary
{
    public class FileWriterCodeActivity : CodeActivity
    {


        [RequiredArgument]
        public InArgument<string> fileName { get; set; }

        [RequiredArgument]
        public InArgument<string> fileData { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string lines = fileData.Get(context);
            // Write the string to a file.
            System.IO.StreamWriter file =
                new System.IO.StreamWriter(fileName.Get(context));
            file.WriteLine(lines);
            //simulate writing process.
            Thread.Sleep(5000);
            file.Close();
        }

    }
}
