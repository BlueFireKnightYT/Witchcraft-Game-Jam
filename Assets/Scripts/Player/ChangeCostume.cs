using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeCostume : MonoBehaviour
{
    public GameObject costumeMenu;
    private bool canOpenMenu = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CostumeBox"))
        {
            canOpenMenu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CostumeBox"))
        {
            canOpenMenu = false;
        }
    }

    public void InteractCostumeBox(InputAction.CallbackContext context)
    {
        if (context.performed && canOpenMenu)
        {
            costumeMenu.SetActive(true);
        }
    }
}
