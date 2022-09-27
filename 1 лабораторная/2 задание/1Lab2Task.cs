Console.Write("Input word: ");
string? word = Console.ReadLine();

int check = 0;
for (int i = 0; i < word.Length / 2; i++) {
    if(word[i] == word[word.Length - i - 1]) {
        check++;
    } else {
        check = 0;
    }
}

if (check > 0) {
    Console.WriteLine($"{word} - is palindrome");
} else {
    Console.WriteLine($"{word} - isn't palindrome");
}
