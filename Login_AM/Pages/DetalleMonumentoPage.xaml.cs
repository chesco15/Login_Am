

namespace Login_AM.Pages;

public partial class DetalleMonumentoPage : ContentPage
{
	public DetalleMonumentoPage(string source, string nombre)
	{
		InitializeComponent();
        Image img = (Image)FindByName("img");
        Label label = (Label)FindByName("titulo");
        label.Text = nombre;
        img.Source = source;
    }
}