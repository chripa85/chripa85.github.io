using Chripa85.Models;

namespace Chripa85.Parsers
{
    public class TxtParser : IShortcutParser
    {
        public ShortcutMap Parse(string content)
        {
            var shortcuts = new List<Shortcut>();

            string category = "";
            string? line = "";
            var reader = new StringReader(content);
            try
            {
                while (true)
                {
                    line = reader.ReadLine();
                    if (line is null)
                    {
                        break;
                    }

                    if (line == "")
                    {
                        category = "";
                        continue;
                    }

                    if (line[0] != '\t')
                    {
                        category = line.Trim();
                        continue;
                    }

                    var parts = line.Trim('\t').Split(' ');
                    var shortcut = new Shortcut(category, parts[0], parts[1]);

                    shortcuts.Add(shortcut);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("line", line);
                throw;
            }

            return new ShortcutMap(shortcuts);
        }
    }
}