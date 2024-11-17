using System.Text;
using ProjectEuler.Solutions.Answers;
using ProjectEuler.Solutions.Resources;

namespace ProjectEuler.Solutions.Solvers;

internal sealed class Solver_0059 : ISolver
{
    public Task<Answer> SolveAsync(CancellationToken cancellationToken = default)
    {
        var encryptedMessage = ReadEncryptedMessage();

        var key = FindKey(encryptedMessage);
        var decryptedMessage = Decrypt(encryptedMessage, key);
        var sum = decryptedMessage.Sum(c => c);

        return Task.FromResult<Answer>(sum);
    }

    private static int[] ReadEncryptedMessage()
    {
        return Resource_0059.Cipher.Split(',').Select(int.Parse).ToArray();
    }

    private static int[] FindKey(Span<int> encryptedMessage)
    {
        var key = new int[3];
        var maxSpaces = 0;

        for (var key0 = 'a'; key0 <= 'z'; key0++)
        {
            for (var key1 = 'a'; key1 <= 'z'; key1++)
            {
                for (var key2 = 'a'; key2 <= 'z'; key2++)
                {
                    var decryptedMessage = Decrypt(encryptedMessage, [key0, key1, key2]);
                    var spaces = decryptedMessage.Count(c => c == ' ');

                    if (spaces <= maxSpaces)
                    {
                        continue;
                    }

                    maxSpaces = spaces;
                    key[0] = key0;
                    key[1] = key1;
                    key[2] = key2;
                }
            }
        }

        return key;
    }

    private static string Decrypt(Span<int> encryptedMessage, int[] key)
    {
        var decryptedMessage = new StringBuilder(encryptedMessage.Length);

        for (var i = 0; i < encryptedMessage.Length; i++)
        {
            decryptedMessage.Append((char)(encryptedMessage[i] ^ key[i % 3]));
        }

        return decryptedMessage.ToString();
    }
}
