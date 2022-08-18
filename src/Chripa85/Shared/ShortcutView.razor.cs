using Chripa85.Models;
using Microsoft.AspNetCore.Components;

namespace Chripa85.Shared;

public partial class ShortcutView : ComponentBase
{
    [Parameter]
    public ShortcutMap ShortcutMap { get;set; }

    protected override void OnParametersSet()
    {
        
    }
}