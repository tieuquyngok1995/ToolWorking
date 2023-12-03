namespace ToolWorking.Model
{
    class FileModel
    {
        public int no { get; set; }

        public string folderName { get; set; }

        public string type { get; set; }

        public string fileName { get; set; }
        public string pathFile { get; set; }

        public string date { get; set; }

        public FileModel(int no, string folderName, string type, string fileName, string pathFile, string date)
        {
            this.no = no;
            this.folderName = folderName;
            this.type = type;
            this.fileName = fileName;
            this.pathFile = pathFile;
            this.date = date;
        }
    }
}
