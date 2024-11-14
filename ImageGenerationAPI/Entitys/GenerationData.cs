namespace ImageGenerationAPI.Entitys
{
    public class GenerationData
    {
        public string modelUri { get; set; }
        public GenerationOptions generationOptions { get; set; }
        public List<MessageData> messages { get; set; }

        public GenerationData() { }
    }
}
