using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource footstepSource;
    public float movementSpeed;
    public float sprintSpeed;
    private float dist;
    public bool playSound = true;

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = input * sprintSpeed;
                if (playSound)
                {
                    if (!footstepSource.isPlaying && Mathf.Abs(rb.velocity.x) > 0)
                    {
                        footstepSource.Play();
                    }
                    else if (!footstepSource.isPlaying && Mathf.Abs(rb.velocity.y) > 0)
                    {
                        footstepSource.Play();
                    }
                }
            }
            else
            {
                rb.velocity = input * movementSpeed;
                if (playSound)
                {
                    if (!footstepSource.isPlaying && Mathf.Abs(rb.velocity.x) > 0)
                    {
                        footstepSource.Play();
                    }
                    else if (!footstepSource.isPlaying && Mathf.Abs(rb.velocity.y) > 0)
                    {
                        footstepSource.Play();
                    }
                }
            }
    }
}