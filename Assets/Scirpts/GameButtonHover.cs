using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class GameButtonSelected : MonoBehaviour
{
    public TMP_Text gameNameText; // The text element to display the game name
    public string gameName;       // The name of the game for this button

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        // Check if this button is currently selected
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            if (gameNameText != null)
            {
                gameNameText.text = gameName; // Update the text to the game name
            }
        }
    }

    private void OnDisable()
    {
        // Reset text when the button is disabled or deselected
        if (gameNameText != null && EventSystem.current.currentSelectedGameObject == gameObject)
        {
            gameNameText.text = "";
        }
    }
}
