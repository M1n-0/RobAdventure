using UnityEngine;

public class MachineButtonSelector : MonoBehaviour
{
    public Camera machineCamera; // POV camera
    public Camera mainCamera; // Main camera
    public Material defaultMaterial; // Material bouton par défaut
    public Material highlightMaterial; // Material bouton selectionné

    private GameObject currentSelected;
    
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public GameObject[] answerUIs;
    public GameObject[] responseUIs;


    private GameObject[] buttons;
    private int selectedButtonIndex = 0; // Index du bouton sélectionné

    private walk playerMovementScript;

    void Start()
    {
        buttons = new GameObject[] { Button1, Button2, Button3 };

        // Cache les réponses et les UI de réponse au lancement
        foreach (var answer in answerUIs)
        answer.SetActive(false);

        foreach (var response in responseUIs)
        response.SetActive(false);

        playerMovementScript = FindObjectOfType<walk>();

        if (mainCamera != null) mainCamera.gameObject.SetActive(true);
        if (machineCamera != null) machineCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!interractionlucas.isInInteraction)
        {
            foreach (var answer in answerUIs)
                answer.SetActive(false);

            foreach (var response in responseUIs)
                response.SetActive(false);

            return;
        }

        // Switch a la machineCamera lorsque l'interaction commence
        if (!machineCamera.gameObject.activeInHierarchy)
        {
            if (mainCamera != null) mainCamera.gameObject.SetActive(false);
            if (machineCamera != null) machineCamera.gameObject.SetActive(true);
        }

        // Est sensé désactiver le mouvement du joueur
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Length) % buttons.Length;
            HighlightButton(selectedButtonIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length;
            HighlightButton(selectedButtonIndex);
        }

        // Confirme avec Entrer
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Button selected: " + buttons[selectedButtonIndex].name);
            SelectButton(buttons[selectedButtonIndex]);
        }
    }

    void HighlightButton(int index) // Ne montre que le bouton sélectionné
    {
        foreach (var button in buttons)
            button.GetComponent<Renderer>().material = defaultMaterial;

        for (int i = 0; i < answerUIs.Length; i++)
            answerUIs[i].SetActive(i == index);

        buttons[index].GetComponent<Renderer>().material = highlightMaterial;
    }

    void SelectButton(GameObject button)
    {
        if (currentSelected != null)
            currentSelected.GetComponent<Renderer>().material = defaultMaterial;

        currentSelected = button;
        currentSelected.GetComponent<Renderer>().material = highlightMaterial;

        foreach (var answer in answerUIs)
            answer.SetActive(false);

        // Montre la réponse associée au bouton sélectionné
        for (int i = 0; i < responseUIs.Length; i++)
            responseUIs[i].SetActive(i == selectedButtonIndex);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        machineCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        interractionlucas.isInInteraction = false;
    }
}