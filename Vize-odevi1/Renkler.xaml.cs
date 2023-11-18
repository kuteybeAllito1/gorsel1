namespace Vize_odevi1;

public partial class Renkler : ContentPage
{
    private Color _currentColor;
    public Renkler()
	{
		InitializeComponent();
	}
    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        int red = (int)SliderRed.Value;
        int green = (int)SliderGreen.Value;
        int blue = (int)SliderBlue.Value;

        _currentColor = Color.FromRgb(red, green, blue);
        ColorBox.BackgroundColor = _currentColor;
        LabelColorCode.Text = $"Renk Kodu: #{red:X2}{green:X2}{blue:X2}";
    }

    private void OnRandomColorButtonClicked(object sender, EventArgs e)
    {
        var random = new Random();
        int red = random.Next(0, 256);
        int green = random.Next(0, 256);
        int blue = random.Next(0, 256);

        SliderRed.Value = red;
        SliderGreen.Value = green;
        SliderBlue.Value = blue;
    }

    private async void OnCopyButtonClicked(object sender, EventArgs e)
    {
        int red = (int)SliderRed.Value;
        int green = (int)SliderGreen.Value;
        int blue = (int)SliderBlue.Value;

        string colorCode = $"#{red:X2}{green:X2}{blue:X2}";
        await Clipboard.SetTextAsync(colorCode);

        await DisplayAlert("Kopyaland?", "Renk kodu panoya kopyaland?.", "OK");
    }
}