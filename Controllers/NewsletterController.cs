using IOptionsPattern.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IOptionsPattern.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly IOptions<NewsletterSettings> _newsletterSettings;
    private readonly IOptionsSnapshot<NewsletterSettings> _newsletterSnapshop;
    private readonly IOptionsMonitor<NewsletterSettings> _newsletterMonitor;

    public NewsletterController(IOptions<NewsletterSettings> newsletterSettings, IOptionsSnapshot<NewsletterSettings> newsletterSnapshop, IOptionsMonitor<NewsletterSettings> newsletterMonitor)
    {
        _newsletterSettings = newsletterSettings;
        _newsletterSnapshop = newsletterSnapshop;
        _newsletterMonitor = newsletterMonitor;

        _newsletterMonitor.OnChange(settings =>
        {
            Console.WriteLine($"Settings changed: {settings.Url}");
        });
    }

    [HttpGet(Name = "GetNewsletter")]
    public string Get()
    {
        string ioptions = _newsletterSettings.Value.Url;
        string ioptionsSnapshot = _newsletterSnapshop.Value.Url;
        string ioptionsMonitor = _newsletterMonitor.CurrentValue.Url;

        return $"Options: {_newsletterSnapshop.Value.Url}. OptionsSnapshop: {_newsletterSnapshop.Value.Url}. OptionsMonitor: {_newsletterMonitor.CurrentValue.Url}.";
    }
}