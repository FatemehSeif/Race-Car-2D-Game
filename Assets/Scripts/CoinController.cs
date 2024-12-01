using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int coinValue; // مقدار امتیاز سکه

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.AddScore(coinValue); 
            Destroy(gameObject);
        }
    }
}
