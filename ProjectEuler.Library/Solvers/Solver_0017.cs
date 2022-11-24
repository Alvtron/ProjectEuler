using ProjectEuler.Library.Answers;

namespace ProjectEuler.Library.Solvers;

internal class Solver_0017 : ISolver
{
    private static readonly Dictionary<string, string> NumberDictionary = new Dictionary<string, string>()
    {
        ["0"] = "zero",
        ["1"] = "one",
        ["2"] = "two",
        ["3"] = "three",
        ["4"] = "four",
        ["5"] = "five",
        ["6"] = "six",
        ["7"] = "seven",
        ["8"] = "eight",
        ["9"] = "nine",
        ["10"] = "ten",
        ["11"] = "eleven",
        ["12"] = "twelve",
        ["13"] = "thirteen",
        ["14"] = "fourteen",
        ["15"] = "fifteen",
        ["16"] = "sixteen",
        ["17"] = "seventeen",
        ["18"] = "eighteen",
        ["19"] = "nineteen",
        ["20"] = "twenty",
        ["21"] = "twenty-one",
        ["22"] = "twenty-two",
        ["23"] = "twenty-three",
        ["24"] = "twenty-four",
        ["25"] = "twenty-five",
        ["26"] = "twenty-six",
        ["27"] = "twenty-seven",
        ["28"] = "twenty-eight",
        ["29"] = "twenty-nine",
        ["30"] = "thirty",
        ["31"] = "thirty-one",
        ["32"] = "thirty-two",
        ["33"] = "thirty-three",
        ["34"] = "thirty-four",
        ["35"] = "thirty-five",
        ["36"] = "thirty-six",
        ["37"] = "thirty-seven",
        ["38"] = "thirty-eight",
        ["39"] = "thirty-nine",
        ["40"] = "forty",
        ["41"] = "forty-one",
        ["42"] = "forty-two",
        ["43"] = "forty-three",
        ["44"] = "forty-four",
        ["45"] = "forty-five",
        ["46"] = "forty-six",
        ["47"] = "forty-seven",
        ["48"] = "forty-eight",
        ["49"] = "forty-nine",
        ["50"] = "fifty",
        ["51"] = "fifty-one",
        ["52"] = "fifty-two",
        ["53"] = "fifty-three",
        ["54"] = "fifty-four",
        ["55"] = "fifty-five",
        ["56"] = "fifty-six",
        ["57"] = "fifty-seven",
        ["58"] = "fifty-eight",
        ["59"] = "fifty-nine",
        ["60"] = "sixty",
        ["61"] = "sixty-one",
        ["62"] = "sixty-two",
        ["63"] = "sixty-three",
        ["64"] = "sixty-four",
        ["65"] = "sixty-five",
        ["66"] = "sixty-six",
        ["67"] = "sixty-seven",
        ["68"] = "sixty-eight",
        ["69"] = "sixty-nine",
        ["70"] = "seventy",
        ["71"] = "seventy-one",
        ["72"] = "seventy-two",
        ["73"] = "seventy-three",
        ["74"] = "seventy-four",
        ["75"] = "seventy-five",
        ["76"] = "seventy-six",
        ["77"] = "seventy-seven",
        ["78"] = "seventy-eight",
        ["79"] = "seventy-nine",
        ["80"] = "eighty",
        ["81"] = "eighty-one",
        ["82"] = "eighty-two",
        ["83"] = "eighty-three",
        ["84"] = "eighty-four",
        ["85"] = "eighty-five",
        ["86"] = "eighty-six",
        ["87"] = "eighty-seven",
        ["88"] = "eighty-eight",
        ["89"] = "eighty-nine",
        ["90"] = "ninety",
        ["91"] = "ninety-one",
        ["92"] = "ninety-two",
        ["93"] = "ninety-three",
        ["94"] = "ninety-four",
        ["95"] = "ninety-five",
        ["96"] = "ninety-six",
        ["97"] = "ninety-seven",
        ["98"] = "ninety-eight",
        ["99"] = "ninety-nine"
    };

    public async Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        return CountNumberOfWordsForAllNumbers(1, 1000);
    }

    private static string DigitsToString(string digits)
    {
        digits = digits.TrimStart('0');

        return digits.Length switch
        {
            0 => string.Empty,
            1 => $"{NumberDictionary[digits]}",
            2 => $"{NumberDictionary[digits]}",
            3 => $"{NumberDictionary[digits.Substring(0, 1)]} hundred {DigitsToString(digits[1..])}",
            4 => $"{NumberDictionary[digits.Substring(0, 1)]} thousand {DigitsToString(digits[1..])}",
            5 => $"{DigitsToString(digits.Substring(0, 2))} thousand {DigitsToString(digits[2..])}",
            6 => $"{DigitsToString(digits.Substring(0, 3))} thousand {DigitsToString(digits[3..])}",
            7 => $"{DigitsToString(digits.Substring(0, 1))} million {DigitsToString(digits[1..])}",
            8 => $"{DigitsToString(digits.Substring(0, 2))} million {DigitsToString(digits[2..])}",
            9 => $"{DigitsToString(digits.Substring(0, 3))} million {DigitsToString(digits[3..])}",
            10 => $"{DigitsToString(digits.Substring(0, 1))} billion {DigitsToString(digits[1..])}",
            11 => $"{DigitsToString(digits.Substring(0, 2))} billion {DigitsToString(digits[2..])}",
            12 => $"{DigitsToString(digits.Substring(0, 3))} billion {DigitsToString(digits[3..])}",
            13 => $"{DigitsToString(digits.Substring(0, 1))} trillion {DigitsToString(digits[1..])}",
            14 => $"{DigitsToString(digits.Substring(0, 2))} trillion {DigitsToString(digits[2..])}",
            15 => $"{DigitsToString(digits.Substring(0, 3))} trillion {DigitsToString(digits[3..])}",
            _ => throw new NotImplementedException(),
        };
    }

    private static string ConstructBritishDigitString(string digits)
    {
        var digitString = DigitsToString(digits);
        var digitWords = digitString.Split(' ');
        var lastDigitWord = digitWords[^1];

        if (digitWords.Length > 1 && NumberDictionary.ContainsValue(lastDigitWord))
        {
            return digitString.Insert(digitString.Length - lastDigitWord.Length, "and ");
        }
        else
        {
            return digitString;
        }
    }

    private static int CountNumberOfWordsForAllNumbers(int start, int limit)
    {
        var count = 0;

        for (var number = start; number <= limit; number++)
        {
            var numberString = ConstructBritishDigitString(number.ToString());
            count += numberString.Count(c => char.IsLetter(c));
        }

        return count;
    }
}