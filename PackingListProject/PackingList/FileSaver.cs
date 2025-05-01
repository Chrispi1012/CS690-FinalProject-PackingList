using System;
using System.IO;

namespace PackingList
{
    public class FileSaver
    {
        private string fileName;

        // Public property to expose the fileName.
        public string FilePath
        {
            get { return fileName; }
        }

        public FileSaver(string fileName)
        {
            this.fileName = fileName;
            // Create the file upon instantiation.
            using (var stream = File.Create(this.fileName)) { }
        }

        public void AppendLine(string line)
        {
            File.AppendAllText(this.fileName, line + Environment.NewLine);
        }
    }
}
