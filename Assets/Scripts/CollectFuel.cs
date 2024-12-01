using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    [SerializeField] private float fuelValue = 10f; 
    [SerializeField] private AudioClip fuelPickupSound; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fuel collected by player.");

            if (FuelController.instance != null)
            {
                FuelController.instance.AddFuel(fuelValue);
            }
            else
            {
                Debug.LogError("FuelController instance is null!");
            }

            if (fuelPickupSound != null)
            {
                AudioSource.PlayClipAtPoint(fuelPickupSound, transform.position);
            }

            Destroy(gameObject); 
        }
    }
}
