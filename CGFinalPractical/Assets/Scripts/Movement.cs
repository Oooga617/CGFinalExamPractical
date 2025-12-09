using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public bool isPoweredUp = false;
    void Update()
    {
        // Get input values
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Movement direction
        Vector3 direction = new Vector3(horizontal, vertical, 0f);

        // Apply movement
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
