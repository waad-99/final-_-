using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // ���� ������
    public float rotationSpeed = 2f; // ���� �������

    private CharacterController characterController;

    void Start()
    {
        // ������ ��� ���� CharacterController
        characterController = GetComponent<CharacterController>();

        // ������ �� ���� CharacterController
        if (characterController == null)
        {
            Debug.LogError("CharacterController is missing on this GameObject!");
            enabled = false; // ����� �������� ��� �� ��� ������ ����
            return;
        }
    }

    void Update()
    {
        // ������ ��� ������ ������
        float horizontalInput = Input.GetAxis("Horizontal"); // ������ A � D �� ������ ���� �����
        float verticalInput = Input.GetAxis("Vertical");   // ������ W � S �� ������ ���� �����

        // ���� ����� ������
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize(); // ��� ��� ������ 1 ����� ���� �����

        // ����� ����� ������ ��� ����� ������ ����� ��� ����� ��������
        movementDirection = transform.TransformDirection(movementDirection);

        // ����� ������ �������� CharacterController
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        // ������ ��� ������ ������� (������)
        float mouseX = Input.GetAxis("Mouse X");

        // ����� �������
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
    }
}