using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


var driverPat = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Chromedriver");
Console.WriteLine("Введіть пошту");
var email = Console.ReadLine();
Console.WriteLine("Введіть пароль");
var password = Console.ReadLine();


using (IWebDriver driver = new ChromeDriver(driverPat))
{
    
    driver.Navigate().GoToUrl("https://www.linkedin.com/login");
    
    var emailField = driver.FindElement(By.Id("username"));
    var passwordField = driver.FindElement(By.Id("password"));
    
    emailField.SendKeys(email);
    passwordField.SendKeys(password);
    
    driver.FindElement(By.CssSelector("button[type='submit']")).Click();
    
    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
    
    var profilePhotoUrl = driver.FindElement(By.CssSelector(".feed-identity-module__member-photo")).GetAttribute("src");
    Console.WriteLine(profilePhotoUrl);
    
    using (var client = new System.Net.WebClient())
    {
        client.DownloadFile(new Uri(profilePhotoUrl), "profile_photo.jpg");
    }
}