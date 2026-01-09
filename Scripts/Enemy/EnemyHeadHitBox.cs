using UnityEngine;

public class EnemyHeadHitbox : MonoBehaviour
{
    public Animator enemyAnimator;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = enemyAnimator.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (audioSource != null && audioSource.clip != null)
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);


            enemyAnimator.SetTrigger("Die");


            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f);


            Destroy(enemyAnimator.gameObject, 0.5f);
        }
    }
}