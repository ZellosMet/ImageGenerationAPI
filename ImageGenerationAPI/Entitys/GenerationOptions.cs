namespace ImageGenerationAPI.Entitys
{
    public class GenerationOptions
    {
        public ulong seed { get; set; }
        public string mime_type { get; set; }

        public GenerationOptions() { }
    }
}
