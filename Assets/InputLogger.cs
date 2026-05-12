using UnityEngine;

/// <summary>
/// Logge dans la console toutes les entrees utilisateur (clavier, souris, manette).
/// Compatible Unity 6 - Old Input Manager.
/// A attacher sur n'importe quel GameObject de la scene.
/// </summary>
public class InputLogger : MonoBehaviour
{
    [Header("Filtres clavier / souris / manette (boutons)")]
    [SerializeField] private bool _logKeyDown = true;
    [SerializeField] private bool _logKeyUp = false;
    [SerializeField] private bool _logKeyHeld = false;

    [Header("Autres entrees")]
    [SerializeField] private bool _logInputString = true;
    [SerializeField] private bool _logAxes = true;
    [SerializeField] private bool _logMousePosition = false;
    [SerializeField] private bool _logMouseScroll = true;

    [Header("Axes a surveiller (doivent exister dans l'Input Manager)")]
    [SerializeField]
    private string[] _axesToWatch =
    {
        // --- Axes par defaut Unity (fonctionnent sans setup) ---
        "Horizontal",           // A/D + fleches + stick gauche X
        "Vertical",              // W/S + fleches + stick gauche Y
        "Mouse X",
        "Mouse Y",
        "Fire1",                 // Ctrl gauche + bouton manette 0
        "Fire2",                 // Alt gauche + bouton manette 1
        "Fire3",                 // Cmd/Shift + bouton manette 2
        "Jump",                  // Espace + bouton manette 3
        "Submit",                // Enter + bouton manette 0
        "Cancel",                // Echap + bouton manette 1

        // --- Axes manette a ajouter dans l'Input Manager ---
        // (silencieusement ignores tant qu'ils n'existent pas grace au try/catch)
        "LeftStickX",            // X axis
        "LeftStickY",            // Y axis (souvent a inverser)
        "RightStickX",           // 4th axis (Win Xbox) / 3rd (Mac/Linux)
        "RightStickY",           // 5th axis (Win Xbox) / 4th (Mac/Linux)
        "LeftTrigger",           // 9th axis (Win) / 5th (Mac/Linux)
        "RightTrigger",          // 10th axis (Win) / 6th (Mac/Linux)
        "DPadX",                 // 6th axis (Win) / 7th (Mac/Linux)
        "DPadY"                  // 7th axis (Win) / 8th (Mac/Linux)
    };

    [Header("Reglages")]
    [Range(0f, 1f)]
    [SerializeField] private float _axisDeadzone = 0.15f;

    private KeyCode[] _keyCodes;

    private void Awake()
    {
        // Cache de l'enum pour eviter d'allouer un array a chaque frame
        _keyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
    }

    private void Start()
    {
        LogConnectedJoysticks();
    }

    private void Update()
    {
        CheckKeys();
        CheckInputString();
        CheckAxes();
        CheckMouseScroll();
        CheckMousePosition();
    }

    private void LogConnectedJoysticks()
    {
        string[] joysticks = Input.GetJoystickNames();

        if (joysticks.Length == 0)
        {
            Debug.Log("[InputLogger] Aucune manette detectee.");
            return;
        }

        for (int i = 0; i < joysticks.Length; i++)
        {
            string label = string.IsNullOrEmpty(joysticks[i]) ? "<slot vide>" : joysticks[i];
            Debug.Log($"[InputLogger] Joystick {i + 1}: {label}");
        }
    }

    private void CheckKeys()
    {
        foreach (KeyCode key in _keyCodes)
        {
            if (_logKeyDown && Input.GetKeyDown(key))
                Debug.Log($"[Down] {key}");

            if (_logKeyUp && Input.GetKeyUp(key))
                Debug.Log($"[Up]   {key}");

            if (_logKeyHeld && Input.GetKey(key))
                Debug.Log($"[Held] {key}");
        }
    }

    private void CheckInputString()
    {
        if (!_logInputString) return;
        if (string.IsNullOrEmpty(Input.inputString)) return;

        // Filtre les caracteres de controle non imprimables pour la lisibilite
        string printable = Input.inputString.Replace("\b", "[Backspace]").Replace("\n", "[Enter]").Replace("\r", "[Enter]");
        Debug.Log($"[Text] '{printable}'");
    }

    private void CheckAxes()
    {
        if (!_logAxes) return;

        foreach (string axisName in _axesToWatch)
        {
            float value;
            try
            {
                value = Input.GetAxisRaw(axisName);
            }
            catch (System.ArgumentException)
            {
                // Axe absent de l'Input Manager : on ignore silencieusement
                continue;
            }

            if (Mathf.Abs(value) > _axisDeadzone)
                Debug.Log($"[Axis] {axisName} = {value:F2}");
        }
    }

    private void CheckMouseScroll()
    {
        if (!_logMouseScroll) return;

        Vector2 scroll = Input.mouseScrollDelta;
        if (Mathf.Abs(scroll.y) > 0.01f)
            Debug.Log($"[Scroll] {scroll.y:F2}");
    }

    private void CheckMousePosition()
    {
        if (!_logMousePosition) return;

        Vector3 pos = Input.mousePosition;
        Debug.Log($"[Mouse] x={pos.x:F0} y={pos.y:F0}");
    }
}