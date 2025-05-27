using UnityEngine;
using UnityEngine.EventSystems;

public class buttonSelect : MonoBehaviour
{
    public GameObject firstSelected;

    void OnEnable()
    {
        if (firstSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelected);
        }
        else
        {
            Debug.LogWarning("firstSelected n'est pas assigné dans " + gameObject.name);
        }
    }
}
