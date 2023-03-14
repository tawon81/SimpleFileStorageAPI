namespace SimpleFileStorageAPI.Models
{
    public class BinaryFile
    {
        public int ID { get; set; }

        public string FileName { get; set; } = string.Empty;

        public byte[] FileData { get; set; } = new byte[0];

        public string FileType { get; set; } = string.Empty;

        public decimal Version { get; set; } = decimal.MinValue;

    }
}
