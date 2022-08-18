using Chripa85.Models;
using Chripa85.Parsers;
using Microsoft.AspNetCore.Components;

namespace Chripa85.Pages;

public partial class Index : ComponentBase
{
    private bool _isLoading;
    private ShortcutMap? _shortcutMap;

    [Inject]
    public HttpClient Client { get; set; }

    [Inject]
    public IShortcutParser Parser { get; set; }

    public async Task Load()
    {
        _isLoading = true;

        byte[] data = await Client.GetByteArrayAsync("data/shortcuts.txt");
        var reader = new StreamReader(new MemoryStream(data));
        var text = await reader.ReadToEndAsync();

        var map = Parser.Parse(text);

        _shortcutMap = map;

        _isLoading = false;
    }
}