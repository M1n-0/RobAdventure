using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text gameNameText;
    public string gameName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameNameText != null)
        {
            gameNameText.text = gameName;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameNameText != null)
        {
            gameNameText.text = "";
        }
    }
}
