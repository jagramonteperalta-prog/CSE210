using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText();

        foreach (Word word in _words)
        {
            displayText += " " + word.GetDisplayText();
        }

        return displayText;
    }

    public void HideRandomWords(int numberOfWords)
    {
        Random random = new Random();

        int visibleWords = 0;

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords++;
            }
        }

        for (int i = 0; i < Math.Min(numberOfWords, visibleWords); i++)
        {
            int index = random.Next(0, _words.Count);

            while (_words[index].IsHidden())
            {
                index = random.Next(0, _words.Count);
            }

            _words[index].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}

