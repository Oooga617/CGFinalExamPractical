using UnityEngine;

public class Collision : MonoBehaviour
   
{
    public bool isPowerUp = false;
    public bool isEnemy = false;
    public bool isPoints = false;
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Enemy") && isEnemy == true && other.GetComponent<Movement>().isPoweredUp ==true)
        {
            other.gameObject.SetActive(false);
            Debug.Log("Player hit the enemy!");
        }
        else if (other.CompareTag("pacman") && isPowerUp==true)
        {
            Debug.Log("Player has picked up PowerUp!");
            other.GetComponent<Movement>().isPoweredUp = true;
        }

        else if (other.CompareTag("pacman") && isPowerUp==false)
        {
            Debug.Log("Player has earned Points!");
        }
        else
        {
            Debug.Log($"Player triggered with: {other.name}");
        }*/

        if(other.CompareTag("pacman"))
        {
            if(isPowerUp==true)
            {
                Debug.Log("Player has picked up PowerUp!");
                other.GetComponent<Movement>().isPoweredUp = true;
                this.gameObject.SetActive(false);
            }
            else if (isPowerUp == false)
            {
                Debug.Log("Player has earned Points!");
                this.gameObject.SetActive(false);
            }

            else if (isEnemy == true && other.GetComponent<Movement>().isPoweredUp==true)
            {
                Debug.Log("Player devoured ghost!");
                this.gameObject.SetActive(false);
            }
        }
    }
}