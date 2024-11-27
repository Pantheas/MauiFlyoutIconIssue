using System.Windows.Input;

namespace MauiTest1;

public partial class MainPage : ContentPage
{
    int count = 0;

    public ICommand BackCommand { get; }
    
    public MainPage()
    {
        BackCommand = new Command(
            DoStuff);
        
        BindingContext = this;
        InitializeComponent();
    }

    private void DoStuff()
    {
        count += 10;
    }
    
    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnNavigateClicked(
        object? sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(SecondPage));
    }
}