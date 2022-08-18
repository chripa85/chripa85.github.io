using Chripa85.Models;
using Microsoft.AspNetCore.Components;

namespace Chripa85.Shared;

public partial class ShortcutView : ComponentBase
{
    private string _selectedText = "";
    bool _isSelected = false;
    private IEnumerable<Shortcut> _selectedShortcuts = Enumerable.Empty<Shortcut>();

    private IEnumerable<string> _categoryNames = Enumerable.Empty<string>();


    [Parameter]
    public ShortcutMap ShortcutMap { get; set; }

    protected override void OnParametersSet()
    {
        _categoryNames = ShortcutMap.GetCategoryNames();
    }

    private void UpdateSelection(string val)
    {
        if (val == string.Empty)
        {
            _selectedShortcuts = Enumerable.Empty<Shortcut>();
            _isSelected = false;
        }else
        {
            _selectedShortcuts = ShortcutMap.GetCategory(val);
            _isSelected = true;
        }
        
        StateHasChanged();
    }
}