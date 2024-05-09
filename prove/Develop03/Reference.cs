using System;

public class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int verseEnd;

    public Reference(string reference)
    {
        // Parse the reference string
        string[] parts = reference.Split(':');
        book = parts[0];
        string[] chapterVerse = parts[1].Split('-');
        chapter = int.Parse(chapterVerse[0]);
        verseStart = int.Parse(chapterVerse[1]);
        if (chapterVerse.Length > 1)
        {
            verseEnd = int.Parse(chapterVerse[1]);
        }
        else
        {
            verseEnd = verseStart;
        }
    }

    public string GetFormattedReference()
    {
        if (verseStart == verseEnd)
        {
            return $"{book} {chapter}:{verseStart}";
        }
        else
        {
            return $"{book} {chapter}:{verseStart}-{verseEnd}";
        }
    }
}
