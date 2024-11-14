namespace ImageGenerationAPI.Entitys
{
    public class RequestData
    {
        internal string OAuthToken { get; set; } = "_AABYwwPke0FIoo602AElZFJ18-mRfg";
        internal string UrlRequest { get; } = "https://llm.api.cloud.yandex.net/foundationModels/v1/imageGenerationAsync";
        internal string UrlResponse { get; } = "https://llm.api.cloud.yandex.net:443/operations/";
        internal string UrlRequestToken { get; } = "https://iam.api.cloud.yandex.net/iam/v1/tokens";

        internal void GetToken(string guid)
        {           
            OAuthToken = guid.Replace("-", "") + OAuthToken;
        }
    }
}
