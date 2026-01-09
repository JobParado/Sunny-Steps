using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;
    public float destroyDelay = 0.3f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play sound
            if (audioSource != null)
            {
                audioSource.Play();
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, destroyDelay);
        }
    }
}