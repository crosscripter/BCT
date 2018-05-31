using System;
using System.IO;
using System.Linq;
using System.Threading;
using static System.Console;
using System.Collections.Generic;

class BC 
{
    static Dictionary<string,int> ChapterMap = new Dictionary<string,int>()
    {
        ["Genesis"] = 50,
        ["Exodus"] = 40,
        ["Leviticus"] = 27,
        ["Numbers"] = 36,
        ["Deuteronomy"] = 34,
        ["Joshua"] = 24,
        ["Judges"] = 21,
        ["Ruth"] = 4,
        ["1 Samuel"] = 31,
        ["2 Samuel"] = 24,
        ["1 Kings"] = 22,
        ["2 Kings"] = 25,
        ["1 Chronicles"] = 29,
        ["2 Chronicles"] = 36,
        ["Ezra"] = 10,
        ["Nehemiah"] = 13,
        ["Esther"] = 10,
        ["Job"] = 42,
        ["Psalms"] = 150,
        ["Proverbs"] = 31,
        ["Ecclesiastes"] = 12,
        ["Song of Solomon"] = 8,
        ["Isaiah"] = 66,
        ["Jeremiah"] = 52,
        ["Lamentations"] = 5,
        ["Ezekiel"] = 48,
        ["Daniel"] = 12,
        ["Hosea"] = 14,
        ["Joel"] = 3,
        ["Amos"] = 9,
        ["Obadiah"] = 1,
        ["Jonah"] = 4,
        ["Micah"] = 7,
        ["Nahum"] = 3,
        ["Habakkuk"] = 3,
        ["Zephaniah"] = 3,
        ["Haggai"] = 2,
        ["Zechariah"] = 14,
        ["Malachi"] = 4,
        ["Matthew"] = 28,
        ["Mark"] = 16,
        ["Luke"] = 24,
        ["John"] = 21,
        ["Acts"] = 28,
        ["Romans"] = 16,
        ["1 Corinthians"] = 16,
        ["2 Corinthians"] = 13,
        ["Galatians"] = 6,
        ["Ephesians"] = 6,
        ["Philippians"] = 4,
        ["Colossians"] = 4,
        ["1 Thessalonians"] = 5,
        ["2 Thessalonians"] = 3,
        ["1 Timothy"] = 6,
        ["2 Timothy"] = 4,
        ["Titus"] = 3,
        ["Philemon"] = 1,
        ["Hebrews"] = 13,
        ["James"] = 5,
        ["1 Peter"] = 5,
        ["2 Peter"] = 3,
        ["1 John"] = 5,
        ["2 John"] = 1, 
        ["3 John"] = 1,
        ["Jude"] = 1,
        ["Revelation"] = 22
    };

    static void Main()
    {
        int correct = 0;
        int incorrect = 0;
        var missed = new List<string>();

        while (ChapterMap.Keys.Count > 0) 
        {
            var count = ChapterMap.Keys.Count;
            var index = new Random().Next(0, count);
            var keys = ChapterMap.Keys.ToArray();
            var book = keys[index];
            var chapters = ChapterMap[book];
Prompt:
            // Clear();
            Write($"({count}/66) How many chapters does the book of {book} have? ");
            var answer = Console.ReadLine().Trim();
            int guess = 0;

            if (int.TryParse(answer, out guess))
            {
                if (guess == chapters)
                {
                    WriteLine($"Correct! It has {chapters} total chapters!");
                    correct++;
                }
                else
                {
                    WriteLine($"Sorry, the book of {book} has {chapters} total chapters.");
                    incorrect++;
                    missed.Add($"{book} ({chapters})");
                }

                ChapterMap.Remove(book);
            }            
            else
            {
                WriteLine($"Sorry, {answer} is not a number! Try again.");
                goto Prompt;
            }

            // Thread.Sleep(1500);
        }

        WriteLine($"Totals: Correct: {correct}, Incorrect: {incorrect}");
        if (incorrect > 0) WriteLine($"Missed books: {string.Join(", ", missed)}");
    }
}