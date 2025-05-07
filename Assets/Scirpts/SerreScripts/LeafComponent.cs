using UnityEngine;

public class LeafComponent : MonoBehaviour
{

    [Header("References")]
    
    [SerializeField] GameObject InfoCanva;
    [SerializeField] GameObject LeafGameObject;
    PlayerMovementSerre move;
    bool inLeafZone;


    void Start()
    {
        move = GetComponent<PlayerMovementSerre>();
    }

    void Update()
    {
        if(inLeafZone && Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("Leaf Collected");
            LeafGameObject.SetActive(false);
            move.hasLeaf = true;
        }
}
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LeafZone"))
        {
            inLeafZone = true;
            Debug.Log("Entered LeafZone");
            InfoCanva.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        InfoCanva.SetActive(false);
    }
}
