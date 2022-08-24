using System;
using Chripa85.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Chripa85.Shared;

public partial class ShortcutView : ComponentBase
{
    private string? _selectedCategory;
    
    private IEnumerable<Shortcut> _selectedShortcuts = Enumerable.Empty<Shortcut>();

    private IEnumerable<string> _categoryNames = Enumerable.Empty<string>();


    [Parameter]
    public ShortcutMap ShortcutMap { get; set; }

    protected override void OnParametersSet()
    {
        _categoryNames = ShortcutMap.GetCategoryNames();
    }

    private void UpdateSelection(string? val)
    {
        _selectedCategory = val;

        if (val is null)
        {
            _selectedShortcuts = Enumerable.Empty<Shortcut>();
        }else
        {
            _selectedShortcuts = ShortcutMap.GetCategory(val);
        }
        
        StateHasChanged();
    }
}


