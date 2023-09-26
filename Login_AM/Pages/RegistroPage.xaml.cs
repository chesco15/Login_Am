using Login_AM.Models;
using Login_AM.Data;
using Login_AM.Pages;
using System.Net.Http.Json;
using System.Text.Json;

namespace Login_AM.Pages;

public partial class RegistroPage : ContentPage
{
	public RegistroPage()
	{
		InitializeComponent();
	}

    private async void Registrarse(object sender, EventArgs e)
    {
        Editor txt_nombre = (Editor)FindByName("txt_nombre");
        Editor txt_ape1 = (Editor)FindByName("txt_ape1");
        Editor txt_ape2 = (Editor)FindByName("txt_ape2");
        Editor txt_tel = (Editor)FindByName("txt_tel");
        Editor txt_email = (Editor)FindByName("txt_email");
        Editor txt_pass = (Editor)FindByName("txt_pass");
        await Login_User(txt_email.Text, txt_pass.Text, txt_nombre.Text, txt_ape1.Text, txt_ape2.Text, txt_tel.Text);
    }
    public async Task Login_User(string username, string password, string nombre, string ape1, string ape2, string tel)
    {
        try
        {
            ServicioCertificacion handler = new ServicioCertificacion();
            HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
            string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7083" : "https://localhost:7083";
            string todoUrl = $"{BaseAddress}/api/";
            client.BaseAddress = new Uri(todoUrl);
            var userParams = new UserRegister(0,nombre,ape1,ape2,tel, username, password);
            var result = await RegisterParametersAsync(userParams, todoUrl);
            await Navigation.PushAsync(new InicioPage());

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errores: {ex.Message}");
        }
    }
    private async Task<String> RegisterParametersAsync(UserRegister userParams, string uri)
    {
        ServicioCertificacion handler = new ServicioCertificacion();
        HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
        var response = await client.PostAsJsonAsync(uri + "Auth/register", userParams);

            return await response.Content.ReadAsStringAsync();
    }
}