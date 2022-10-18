namespace Lab2Solution;
/// <summary>
/// Name: Wil LaLonde
/// Date: 10/18/2022
/// Description: Lab4
/// Bugs: KNOWN ISSUES:
/// (1): After adding the test project, I am no longer able to 
///      boot up my application. I'm not really sure why that
///      is happening but at least the tests run. I tried
///      doing a bunch of different things to try and get this
///      to work again but simply ran out of time.
/// Reflection: I personally did not like this lab. I don't mind
///             writing tests, I actually enjoy them quite a bit.
///             My biggest issue was getting the tests to work in
///             the first place. I spend like 5 hours just searching
///             the internet trying to find the solution. Thankfully,
///             I found some random YouTube video that had all the 
///             code I needed to add in my project file. I also
///             have no idea why adding the testing framework broke
///             my whole application. But hey, at least the tests work.
/// </summary>
public static class MauiProgram {
    public static IBusinessLogic ibl = new BusinessLogic();

    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
