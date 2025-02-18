using System;
using System.IO;

class Solution
{
    /// <summary>
    /// Computes the maximum number of 3-letter palindromes ("x y x") 
    /// that can be formed from the input string S.
    /// </summary>
    /// <param name="S">Input string</param>
    /// <returns>Maximum number of 3-letter palindromes</returns>
    public int ComputePalindromes(string S)
    {
        // Frequency array for 'a' to 'z'
        int[] freq = new int[26];

        // Convert the string to lowercase if needed:
        // (Uncomment if the problem only involves lowercase letters.)
        // S = S.ToLower();

        // Count occurrences of each letter
        foreach (char c in S)
        {
            // Only count letters 'a' to 'z' to avoid index errors.
            // If the problem allows any ASCII letter, adjust accordingly.
            if (c >= 'a' && c <= 'z')
            {
                freq[c - 'a']++;
            }
            else if (c >= 'A' && c <= 'Z')
            {
                freq[c - 'A']++;
            }
        }

        int pairs = 0, singles = 0, totalLetters = 0;

        // Compute pairs and single occurrences
        foreach (int count in freq)
        {
            pairs += count / 2;     // Each pair can help form "x_x"
            if (count > 0) singles++; // Any nonzero frequency can be a middle character
            totalLetters += count;
        }

        // The maximum valid three-letter palindromes must respect total letters
        // (you need 3 letters for each palindrome)
        return Math.Min(pairs, Math.Min(singles, totalLetters / 3));
    }

    /// <summary>
    /// Entry point. Expects a file path as the first command-line argument.
    /// </summary>
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: Provide a file path as the first argument.");
            return;
        }

        string filePath = args[0];

        // Ensure the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        // Read the entire file content as a single string
        string inputString = File.ReadAllText(filePath);

        // Compute the result
        Solution sol = new Solution();
        int result = sol.ComputePalindromes(inputString);

        // Print the result
        Console.WriteLine(result);
    }
}
