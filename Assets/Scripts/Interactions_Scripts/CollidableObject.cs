using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidables : MonoBehaviour
{
    
    private Collider2D z_collider;
    [SerializeField]
    private ContactFilter2D z_filter;
    private List<Collider2D> z_collidedObject = new List<Collider2D>(1);
    protected virtual void Start()
    {
        z_collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        z_collider.OverlapCollider(z_filter, z_collidedObject);
        foreach (var o in z_collidedObject)
        {
            OnCollided(o.gameObject);
        }
    }
    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Kolliderade med " + collidedObject.name);
    }

}
