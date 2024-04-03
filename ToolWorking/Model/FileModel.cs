namespace ToolWorking.Model
{
    public class FileModel
    {
        public int no { get; set; }

        public string folderName { get; set; }

        public string type { get; set; }

        public string fileName { get; set; }

        public string pathFile { get; set; }

        public string date { get; set; }

        public FileModel(int _no, string _folderName, string _type, string _fileName, string _pathFile, string _date)
        {
            no = _no;
            folderName = _folderName;
            type = _type;
            fileName = _fileName;
            pathFile = _pathFile;
            date = _date;
        }
    }
}
