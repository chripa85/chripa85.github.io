using Chripa85.Models;

namespace Chripa85.Parsers
{
    public interface IShortcutParser
    {
        ShortcutMap Parse(string content);
    }
}