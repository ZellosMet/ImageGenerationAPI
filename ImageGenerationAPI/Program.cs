using ImageGenerationAPI.Class;
using System.Net.Http.Headers;
using ImageGenerationAPI.Entitys;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<RequestData>();
builder.Services.AddSingleton<ResponseData>();
var app = builder.Build();

//Проверка сервера
app.MapGet("/api", (RequestData request_data) => 
{
    request_data.GetToken(app.Configuration["ProjectGuid"]);
    return "Server is running";
});

//Запрос на получения ключа авторизайии
app.MapPost("/api/authorization", async (ResponseData respons_data, RequestData request_data) =>
{
    using (HttpClient http_client = new HttpClient())
    {
        var token = new {yandexPassportOauthToken = request_data.OAuthToken};
        var request = await http_client.PostAsJsonAsync(request_data.UrlRequestToken, token);
        IAMTokenData iam = await request.Content.ReadFromJsonAsync<IAMTokenData>();
        respons_data.IAMToken = iam.iamToken;
        return "Авторизайия выполнена";        
    }
});

//Запрос на генерацию изображения
app.MapPost("/api/generation", async (GenerationData generation_data, ResponseData respons_data, RequestData request_data) =>
{
    using (HttpClient http_client = new HttpClient())
    {
        http_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", respons_data.IAMToken);
        var request = await http_client.PostAsJsonAsync(request_data.UrlRequest, generation_data);
        respons_data.ResponseGeneration = await request.Content.ReadFromJsonAsync<ResponseToGeneration>();
        Thread.Sleep(10000);
        return $"ID запроса {respons_data.ResponseGeneration.id}";
    }
});

//Запрос на получение изображения
app.MapGet("/api/generation", async (ResponseData respons_data, RequestData request_data) =>
{
    using (HttpClient http_client = new HttpClient())
    {
        http_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", respons_data.IAMToken);
        var person = await http_client.GetAsync($"{request_data.UrlResponse}{respons_data.ResponseGeneration.id}");
        respons_data.ResponseImage = await person.Content.ReadFromJsonAsync<ResponseImage>();
    }
    SavedImage saved_image = new SavedImage(respons_data.ResponseImage.response.image);
    saved_image.Save();
    return "Изображение сгенерировано";
});

app.Run();
