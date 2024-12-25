using UnityEngine;

public class PlayerMovemeent : MonoBehaviour
{
    public Animator animator; // ���� ��� Animator ��� �� Unity
    public float speed = 5f;
    public Rigidbody rb;

    void Update()
    {
        // ��� �������� ������
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // ���� ������
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);

        // ��� ��� ���� ����
        if (move.magnitude > 0)
        {
            // �� ������ �������� �����
            animator.SetBool("isWalking", true);
        }
        else
        {
            // ��� ��� ������ �� ����ߡ �� ������ �������� (������)
            animator.SetBool("isWalking", false);
        }
    }
}