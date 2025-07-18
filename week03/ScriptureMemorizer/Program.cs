using System;
using System.Collections.Generic;
using System.Linq;
//Thomas Barney
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
                break;

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program will now exit.");
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int? VerseEnd { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (VerseEnd.HasValue)
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        else
            return $"{Book} {Chapter}:{VerseStart}";
    }
}

class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public bool IsHidden => _hidden;

    public void Hide()
    {
        _hidden = true;
    }

    public string GetDisplayText()
    {
        if (_hidden && _text.All(char.IsLetter))
            return new string('_', _text.Length);
        else if (_hidden)
        {
            var chars = _text.Select(c => char.IsLetter(c) ? '_' : c).ToArray();
            return new string(chars);
        }
        else
            return _text;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
            .Select(w => new Word(w))
            .ToList();
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords(int count)
    {
        var notHidden = _words.Where(w => !w.IsHidden).ToList();
        if (notHidden.Count == 0) return;

        int toHide = Math.Min(count, notHidden.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _random.Next(notHidden.Count);
            notHidden[idx].Hide();
            notHidden.RemoveAt(idx);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}