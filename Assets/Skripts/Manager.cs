// Importiere die notwendigen Namespaces f�r Unity-Funktionalit�ten
using UnityEngine;
using UnityEngine.UI;

// Deklariere die Klasse "HangmanGame", die von MonoBehaviour erbt
public class HangmanGame : MonoBehaviour
{
    // Deklariere �ffentliche Variablen f�r die UI-Elemente
    public Text wordDisplay;
    public Text triesDisplay;
    public string wordToGuess; // Setze dies im Inspector
    private char[] wordToGuessArray;
    private bool[] guessedLetters;
    private int maxTries = 6;
    private int remainingTries;
    private HangmanImages hangmanImagesScript;
    public Text OutputWords;

    // Die Startmethode wird beim Start des Spiels aufgerufen
    void Start()
    {
        hangmanImagesScript = GameObject.FindObjectOfType<HangmanImages>();
        StartGame();
    }

    // Die Methode zum Initialisieren des Spiels
    void StartGame()
    {
        // Konvertiere das zu erratende Wort in ein Char-Array und setze andere Variablen zur�ck
        wordToGuessArray = wordToGuess.ToUpper().ToCharArray();
        guessedLetters = new bool[wordToGuessArray.Length];
        remainingTries = maxTries;

        // Initialisiere das guessedLetters-Array mit falschen Werten
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            guessedLetters[i] = false;
        }

        // Aktualisiere die UI
        UpdateUI();
    }

    // Die Methode zum Aktualisieren der Benutzeroberfl�che
    void UpdateUI()
    {
        // Aktualisiere die Anzeige des zu erratenden Wortes
        string displayText = "";
        for (int i = 0; i < wordToGuessArray.Length; i++)
        {
            if (guessedLetters[i])
                displayText += wordToGuessArray[i] + " ";
            else
                displayText += "_ ";
        }
        wordDisplay.text = displayText.Trim();

        // Aktualisiere die Anzeige der verbleibenden Versuche
        triesDisplay.text = "Tries: " + remainingTries;
    }

    // Die Methode zum �berpr�fen eines eingegebenen Buchstabens
    void CheckLetter(char letter)
    {
        bool letterFound = false;

        // �berpr�fe, ob der eingegebene Buchstabe im Wort enthalten ist
        for (int i = 0; i < wordToGuessArray.Length; i++)
        {
            if (wordToGuessArray[i] == letter)
            {
                guessedLetters[i] = true;
                letterFound = true;
            }
        }

        // Falls der Buchstabe nicht im Wort ist, verringere die verbleibenden Versuche
        if (!letterFound)
        {
            remainingTries--;
            hangmanImagesScript.ActivateNextImage();

        }

        // Aktualisiere die UI
        UpdateUI();

        // �berpr�fe, ob der Spieler gewonnen oder verloren hat
        if (remainingTries == 0)
        {
            OutputWords.text = "Game Over. You lose. The word was: " + wordToGuess;
            StartGame();
        }
        else if (System.Array.IndexOf(guessedLetters, false) == -1)
        {
            OutputWords.text = "Congratulations! You win. The word was: " + wordToGuess;
            StartGame();
        }
    }

    // Diese Funktion wird aufgerufen, wenn ein Buchstaben-Button geklickt wird
    public void LetterClicked(string letter)
    {
        char guessedLetter = letter.ToUpper()[0];
        CheckLetter(guessedLetter);
    }

    // Die Update-Methode wird in jedem Frame aufgerufen
    void Update()
    {
        // �berpr�fe, ob eine Taste gedr�ckt wurde
        if (Input.anyKeyDown)
        {
            // �berpr�fe, ob die gedr�ckte Taste ein Buchstabe ist
            if (Input.inputString.Length > 0 && char.IsLetter(Input.inputString[0]))
            {
                char pressedKey = char.ToUpper(Input.inputString[0]);
                CheckLetter(pressedKey);
            }
        }
    }
}
