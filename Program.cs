using System.Text.Json;

var random = new Random();


var texto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZáéíóúâêîôûàèìòùãẽĩõũäëïöüÿÀÉÍÓÚÂÊÎÔÛÀÈÌÒÙÃẼĨÕŨÄËÏÖÜŸ";

while (true)
{
    var resultado = "";

    int index1 = random.Next(0, texto.Length);
    char letra1 = texto[index1];
    int index2 = random.Next(0, texto.Length);
    char letra2 = texto[index2];
    var numeroRandomico1 = random.Next(1, 100);
    var numeroRandomico2 = random.Next(1, 100);

    resultado = $"{letra1}{numeroRandomico1}{letra2}";

    var json = new Json()
    {
        Key = resultado,
        grupo = "Sala 6"
    };

    var objeto = JsonSerializer.Serialize(json);

    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, "https://fiap-inaugural.azurewebsites.net/fiap");
    request.Headers.Add("Cookie", "ARRAffinity=c2dc5cdfd83d18a581d6889c06f1e64b4cf50672e89dc41e380fd2aab9a84769; ARRAffinitySameSite=c2dc5cdfd83d18a581d6889c06f1e64b4cf50672e89dc41e380fd2aab9a84769");
    var content = new StringContent(objeto, null, "application/json");
    request.Content = content;
    var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();



    Console.WriteLine($"{resultado} - {await response.Content.ReadAsStringAsync()}");
}


public class Json ()
{
    public string Key { get; set; }
    public string grupo { get; set; }
}