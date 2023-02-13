namespace FileHandlingServer.Helpers
{
    public class SaveImageFileConfiguration
    {
        private const string DEFAULT_FORMAT = "image/png";
        private string _format = DEFAULT_FORMAT;
        private readonly Dictionary<string, string> _formatExtensions = new()
        {
            { DEFAULT_FORMAT, ".png" },
            { "image/jpeg", ".jpeg" },
            { "audio/mpeg", ".mp3" },
            { "video/mp4", ".mp4" },
            { "application/pdf", ".pdf" }
        };

        public string Format 
        { 
            get { return _format; }
            set
            {
                if (!_formatExtensions.ContainsKey(value))
                {
                    value = DEFAULT_FORMAT;
                }

                _format = value;
            }
        }

        public int MaxWidth { get; set; } = 400;
        public int MaxHeight { get; set; } = 400;
        public string Extension => _formatExtensions[_format];
    }
}
