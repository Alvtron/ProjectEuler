using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectEuler.Library;

namespace ProjectEuler.Services;

public class AnswerSource
{
    private readonly Dictionary<int, Answer> Source;

    public AnswerSource()
    {
        var sourceFile = Path.Combine(Environment.CurrentDirectory, @"Resources\answers.txt");

        this.Source = File.ReadAllLines(sourceFile).Select(a => a.Split(';'))
            .ToDictionary(a => int.Parse(a[0]), a => new Answer(a[1]));
    }

    public bool HasAnswer(int number)
    {
        return this.Source.ContainsKey(number);
    }

    public Answer GetAnswer(int number)
    {
        return this.Source[number];
    }
}