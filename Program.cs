using System.Security.Cryptography;
using MoreLinq;
using Spectre.Console;

var count = Convert.ToInt32(args[0]);

var words = await File.ReadAllLinesAsync("wordlist.txt");

var selectedWords = Enumerable.Range(0,count).Select( i => words[RandomNumberGenerator.GetInt32(words.Length)]).ToList();

var batches = selectedWords.Batch(3);

var tab = new Table();
tab.Border(TableBorder.None);
tab.Width(30);
tab.AddColumns("first","second","third");
tab.HideHeaders();

foreach(var batch in batches) 
{
    tab.AddRow(batch.ToArray());
}
AnsiConsole.Write(tab);