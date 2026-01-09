using UnityEngine;

public class SpikeHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator playerAnimator = collision.GetComponent<Animator>();
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();

            if (playerAnimator != null)
            {
                playerAnimator.SetBool("Die", true);

                if (playerRigidbody != null)
                {
                    playerRigidbody.linearVelocity = Vector2.zero;
                    playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                }

                if (playerMovement != null)
                {
                    playerMovement.enabled = false;
                }

                float animLength = playerAnimator.GetCurrentAnimatorStateInfo(0).length;

                GameManager gm = Object.FindFirstObjectByType<GameManager>();
                if (gm != null)
                {
                    gm.TriggerGameOver(animLength);
                }


                Destroy(collision.gameObject, animLength);
            }
        }
    }
}
