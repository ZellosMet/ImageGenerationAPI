namespace ImageGenerationAPI.Entitys
{
    public class ResponseImage
    {
        public string id { get; set; }
        public string description { get; set; }
        public string? createdAt { get; set; }
        public string createdBy { get; set; }
        public string? modifiedAt { get; set; }
        public bool done { get; set; }
        public ImageData response { get; set; }
        public string? metadata { get; set; }

        public ResponseImage() { }
    }
}
