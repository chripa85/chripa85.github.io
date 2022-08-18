using System.Collections;

namespace Chripa85.Models;

public record Shortcut(string Category, string Action, string Keys);

public class ShortcutMap : IEnumerable<Shortcut>
{
    List<Shortcut> _shortcuts;
    Dictionary<string, List<Shortcut>> _categoryMap;

    public ShortcutMap(IEnumerable<Shortcut> shortcuts)
    {
        _shortcuts = new List<Shortcut>(shortcuts.Count());
        _categoryMap = new Dictionary<string, List<Shortcut>>();

        foreach (var s in shortcuts)
        {
            _shortcuts.Add(s);

            if (!_categoryMap.ContainsKey(s.Category))
            {
                _categoryMap.Add(s.Category, new List<Shortcut>());
            }
            _categoryMap[s.Category].Add(s);
        }
    }

    public IEnumerable<Shortcut> GetCategory(string category)
    {
        return _categoryMap[category];
    }

    public IEnumerable<string> GetCategoryNames()
    {
        return _categoryMap.Keys;
    }

    public IEnumerator<Shortcut> GetEnumerator()
    {
        return _shortcuts.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}