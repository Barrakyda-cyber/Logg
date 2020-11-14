using System.IO;


namespace LoggingLibrary
{
    public delegate void Message(string m);
    public class Save
    {

        public Message message;

        public Save() { }

        public Save(string path)
        {
            Path = path;
        }
        public string Path { get; private set; }

        public async void Added(string message)
        {
            if (Path != null)
            {
                using (FileStream file = new FileStream($@"{Path}\log.txt", FileMode.Append))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes($"{message}\n");
                    await file.WriteAsync(array, 0, array.Length);
                }
                this.message?.Invoke("Произошла запись в файл");
            }
            else
            {
                using (FileStream file = new FileStream("log.txt", FileMode.Append))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes($"{message}\n");
                    await file.WriteAsync(array, 0, array.Length);
                }
                this.message?.Invoke("Произошла запись в файл, место файла стандартное");
            }

        }
    }
}
