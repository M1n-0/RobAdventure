using UnityEngine;

public class ExitTextMkr : MonoBehaviour
{
    [SerializeField] private GameObject ExitTextCanva;
    private bool hasShown = false;

    void Update()
    {
        if (ButtonTrigger.isOpen && !hasShown)
        {
            Instantiate(ExitTextCanva);
            hasShown = true;
        }
    }
}
