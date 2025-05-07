using UnityEngine;

public class tuto : MonoBehaviour
{
public Canvas Gauche;
private bool IsGauche = true;
public Canvas Droite;
private bool IsDroite = true;
public Canvas Jump;
private bool IsJump = true;
public Canvas JumpMove;
private bool IsJumpMove = true;
public Canvas Interact;
private bool IsInteract = true;
public Canvas Pause;
private bool IsPause = true;
public Canvas Menu;
public Canvas Resume;
private bool IsResume = true;


void Update()
{
    if (Input.GetKeyDown(KeyCode.RightArrow) && IsDroite == true && IsResume == false)
    {
        Gauche.enabled = true;
        Droite.enabled = false;
        IsDroite = false;
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow) && IsGauche == true && IsDroite == false)
    {
        
        Gauche.enabled = false;
        Jump.enabled = true;
        IsGauche = false;
    }
    if (Input.GetKeyDown(KeyCode.Space) && IsJump == true && IsGauche == false)
    {
        Jump.enabled = false;
        JumpMove.enabled = true;
        IsJump = false;
    }
if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && IsJumpMove == true && IsJump == false)
    {
        JumpMove.enabled = false;
        Interact.enabled = true;
        IsJumpMove = false;
    }
    if (Input.GetKeyDown(KeyCode.E) && IsInteract == true && IsJumpMove == false)
    {
        Interact.enabled = false;
        IsInteract = false;
    }
    if (Input.GetKeyDown(KeyCode.Escape) && IsPause == true )
    {
        Pause.enabled = false;
        Menu.enabled = true;
        Resume.enabled = true;
        IsPause = false;
    }
    if (Input.GetKeyDown(KeyCode.Space) && IsResume == true && IsPause == false)
    {
        Menu.enabled = false;
        Resume.enabled = false;
        IsResume = false;
        Droite.enabled = true;
    }
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Menu.enabled = true;
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Menu.enabled = false;
    }
}
}
