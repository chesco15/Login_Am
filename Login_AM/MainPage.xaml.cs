using Login_AM.Data;
using Login_AM.Models;
using Login_AM.Pages;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Login_AM;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    
    public MainPage()
	{
		InitializeComponent();
    }
    private async void Loguearse(object sender, EventArgs e)
    {
        Editor txt_email = (Editor)FindByName("txt_email");
        Editor txt_pass = (Editor)FindByName("txt_pass");
        await Login_User(txt_email.Text, txt_pass.Text);
    }
    public async Task Login_User(string username, string password)
    {
        try
        {
            ServicioCertificacion handler = new ServicioCertificacion();
            HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
            string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7083" : "https://localhost:7083";
            string todoUrl = $"{BaseAddress}/api/";
            client.BaseAddress = new Uri(todoUrl);
            var userParams = new User(username, password);
            var result = await GetUserParametersAsync(userParams, todoUrl);
            var resultparse = JsonSerializer.Deserialize<UserResponse>(result);
            if (resultparse.token!=null)
            {
                await Navigation.PushAsync(new InicioPage());
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    private async Task<String> GetUserParametersAsync(User userParams, string uri)
    {
        ServicioCertificacion handler = new ServicioCertificacion();
        HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
        var response = await client.PostAsJsonAsync(uri + "Auth/login", userParams);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception($"Error al realizar la solicitud: {response.StatusCode}");
        }
    }

    private async void Registro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroPage());
    }
}
