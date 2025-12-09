using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player hit the enemy!");
        }
        else
        {
            Debug.Log($"Player triggered with: {other.name}");
        }
    }
}