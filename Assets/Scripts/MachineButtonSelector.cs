using UnityEngine;

public class MachineButtonSelector : MonoBehaviour
{
    public Camera machineCamera; // POV camera
    public Material defaultMaterial;
    public Material highlightMaterial;

    private GameObject currentSelected;
    
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    private GameObject[] buttons; // Array to hold the buttons
    private int selectedButtonIndex = 0; // Index to track which button is selected

    private walk playerMovementScript; // Reference to the player movement script

    void Start()
    {
        // Initialize the buttons array
        buttons = new GameObject[] { Button1, Button2, Button3 };

        // Initially highlight the first button
        HighlightButton(selectedButtonIndex);

        // Get the player movement script (assuming it's attached to the same object as the player)
        playerMovementScript = FindObjectOfType<Walk>();
    }

    void Update()
    {
        if (!interractionlucas.isInInteraction) return; // Only allow when in POV mode

        // Disable player movement when this script is active
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false; // Disable movement
        }

        // Navigate with Q (A on AZERTY) and D
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q)) // Left (Q on QWERTY, A on AZERTY)
        {
            selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Length) % buttons.Length; // Wrap around
            HighlightButton(selectedButtonIndex);
        }
        else if (Input.GetKeyDown(KeyCode.D)) // Right
        {
            selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length; // Wrap around
            HighlightButton(selectedButtonIndex);
        }

        // Confirm selection with Enter
        if (Input.GetKeyDown(KeyCode.Return)) // Enter
        {
            Debug.Log("Button selected: " + buttons[selectedButtonIndex].name);
            SelectButton(buttons[selectedButtonIndex]);
        }

        // Optionally, you can also check for player movement if needed, e.g., when the interaction ends
        // Re-enable player movement after selecting a button (or conditionally based on the game state)
    }

    void HighlightButton(int index)
    {
        // Reset all buttons to default material
        foreach (var button in buttons)
        {
            button.GetComponent<Renderer>().material = defaultMaterial;
        }

        // Highlight the selected button
        buttons[index].GetComponent<Renderer>().material = highlightMaterial;
    }

    void SelectButton(GameObject button)
    {
        if (currentSelected != null)
        {
            // Reset previous material
            currentSelected.GetComponent<Renderer>().material = defaultMaterial;
        }

        currentSelected = button;
        currentSelected.GetComponent<Renderer>().material = highlightMaterial;

        // Additional actions when a button is selected can go here

        // Re-enable player movement when done
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true; // Enable movement after selection
        }
    }
}
