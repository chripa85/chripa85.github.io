using Chripa85.Models;
using Microsoft.AspNetCore.Components;

namespace Chripa85.Shared;

public partial class ShortcutCategoryView : ComponentBase
{
    private string? _category;

    [Parameter]
    public IEnumerable<Shortcut> Shortcuts { get;set; }

    protected override void OnParametersSet()
    {
        if (Shortcuts == null || !Shortcuts.Any())
        {
            return;
        }

        _category = Shortcuts.First().Category;
    }
}