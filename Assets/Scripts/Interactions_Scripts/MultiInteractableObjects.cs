    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiInteractables : Collidables
{
    private bool x_interacted = false;
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();

        }

    }



    private void OnInteract()
    {
        if (!x_interacted)
        {
            x_interacted = true;
            Debug.Log("(multi) Interakterade med  " + name);
        }
        x_interacted = false;

        
    }

}
