using UnityEngine;
using UnityEngine.UI;

public class HangmanImages : MonoBehaviour
{
    
    public Image[] hangmanImages; // Array von Bildern f�r Hangman
    private int currentImageIndex = 0; // Index des aktuellen Bildes
    
    void Start()
    {
        // Deaktiviere alle Bilder au�er dem ersten
        for (int i = 1; i < hangmanImages.Length; i++)
        {
            hangmanImages[i].gameObject.SetActive(false);
        }
    }

    // Methode zum Aktivieren des n�chsten Hangman-Bildes
    public void ActivateNextImage()
    {
        // �berpr�fe, ob es noch weitere Bilder gibt
        if (currentImageIndex < hangmanImages.Length - 1)
        {
            currentImageIndex++;
            hangmanImages[currentImageIndex].gameObject.SetActive(true);
        }
    }
}
