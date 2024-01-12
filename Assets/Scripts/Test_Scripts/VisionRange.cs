using UnityEngine;

public class VisionRange : MonoBehaviour
{
    public Transform player;
    public float visionRange = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
