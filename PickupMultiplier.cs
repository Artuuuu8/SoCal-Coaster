using UnityEngine;

public class ScoreMultiplierPickup : MonoBehaviour
{
    public float multiplierAmount = 2f;  // The multiplier to apply
    public float boostDuration = 5f;     // How long the boost lasts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate score boost in ScoreManager
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.ActivateScoreMultiplier(multiplierAmount, boostDuration);
            
            // Play pickup sound
            FindObjectOfType<AudioManager>().PlayPickupSound();

            // Destroy the multiplier object after collection
            Destroy(gameObject);
        }
    }
}

