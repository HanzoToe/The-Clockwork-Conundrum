    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingInteractables : Collidables
{
    private bool z_interacted = false;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();

        }

    }



    private void OnInteract()
    {
        if (!z_interacted)
        {
            z_interacted = true;
            Debug.Log("(2) Interakterade med  " + name);
        }
        z_interacted = false;
    }
}
