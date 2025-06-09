using NUnit.Framework.Interfaces;
using UnityEngine;

public class TargetArrow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] private Transform Target2;
    [SerializeField] private Transform Target3;
    [SerializeField] private Transform Target4;

    void Start()
    {
        KeyTrigger.keyCollected = false;
        ConsoleTrigger.isNotDumb = false;
        ButtonTrigger.isOpen = false;
    }



    void Update()
    {
        TargetChange();
        Tracker();
        
    }

    void Tracker()
    {
        Vector3 relativePos = target.position - transform.position;
        float angle = (Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg) + 180f;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void TargetChange()
    {
        if (KeyTrigger.keyCollected)
        {
            target = Target2;
        }
        if (ConsoleTrigger.isNotDumb)
        {
            target = Target3;
        }
        if (ButtonTrigger.isOpen)
        {
            target = Target4;
        }
    }
}
