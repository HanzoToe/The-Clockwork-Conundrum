using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class interactables : Collidables
{
    private bool z_interacted = false;
   protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract();
            
        }
        
    }

    
    
    private void OnInteract()
    {
        if (!z_interacted)
        {
            z_interacted = true;
            Debug.Log("Interakterade med " + name);
        }
        
    }
}




