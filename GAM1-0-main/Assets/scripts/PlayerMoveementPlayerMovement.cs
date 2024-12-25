using UnityEngine;

public class PlayerMovemeent : MonoBehaviour
{
    public Animator animator; // «”Õ» «·‹ Animator Â‰« ›Ì Unity
    public float speed = 5f;
    public Rigidbody rb;

    void Update()
    {
        // √Œ– «·„œŒ·«  ··Õ—ﬂ…
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Õ”«» «·Õ—ﬂ…
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);

        // ≈–« ﬂ«‰ Â‰«ﬂ Õ—ﬂ…
        if (move.magnitude > 0)
        {
            // ﬁ„ » ‘€Ì· «·√‰„Ì‘‰ «·„‘Ì
            animator.SetBool("isWalking", true);
        }
        else
        {
            // ≈–« ﬂ«‰ «··«⁄» ·« Ì Õ—ﬂ° ﬁ„ »≈Ìﬁ«› «·√‰„Ì‘‰ («· Êﬁ›)
            animator.SetBool("isWalking", false);
        }
    }
}