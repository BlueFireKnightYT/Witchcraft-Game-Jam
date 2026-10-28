using UnityEngine;

public class FallPrevent : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = spawnPos.position;
    }
        
}
