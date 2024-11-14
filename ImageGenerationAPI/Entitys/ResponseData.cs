namespace ImageGenerationAPI.Entitys
{
    public class ResponseData
    {
        internal ResponseToGeneration ResponseGeneration { get; set; }
        internal ResponseImage ResponseImage { get; set; }
        internal string IAMToken { get; set; }
    }
}
