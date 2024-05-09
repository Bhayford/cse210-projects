using System;

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public string GetDisplayText()
    {
        if (hidden)
            return "______"; // Placeholder for hidden word
        else
            return text;
    }
}
