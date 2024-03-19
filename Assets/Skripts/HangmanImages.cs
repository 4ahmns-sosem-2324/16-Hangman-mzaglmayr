using UnityEngine;
using UnityEngine.UI;

public class HangmanImages : MonoBehaviour
{
    
    public Image[] hangmanImages; // Array von Bildern für Hangman
    private int currentImageIndex = 0; // Index des aktuellen Bildes
    
    void Start()
    {
        // Deaktiviere alle Bilder außer dem ersten
        for (int i = 1; i < hangmanImages.Length; i++)
        {
            hangmanImages[i].gameObject.SetActive(false);
        }
    }

    // Methode zum Aktivieren des nächsten Hangman-Bildes
    public void ActivateNextImage()
    {
        // Überprüfe, ob es noch weitere Bilder gibt
        if (currentImageIndex < hangmanImages.Length - 1)
        {
            currentImageIndex++;
            hangmanImages[currentImageIndex].gameObject.SetActive(true);
        }
    }
}
