using System.Runtime.CompilerServices;
using UnityEngine;

public class doorController : MonoBehaviour
{
    PlayerBattery PBattery;

    [SerializeField] int requiredBattery;

    void Start()
    {
        PBattery = FindFirstObjectByType<PlayerBattery>();
    }

    void Update()
    {
        if (PBattery.totalCount >= requiredBattery)
        {
            gameObject.SetActive(false);
        }
    }
}
