using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource footstepSource;
    public float movementSpeed;
    public float sprintSpeed;
    public bool canMove = true;
    private float dist;

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = input * sprintSpeed;
                if (!footstepSource.isPlaying && Mathf.Abs(rb.velocity.x) > 0)
                {
                    footstepSource.Play();
                }
                else if (!footstepSource.isPlaying && Mathf.Abs(rb.velocity.y) > 0)
                {
                    footstepSource.Play();
                }
            }
            else
            {
                rb.velocity = input * movementSpeed;
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