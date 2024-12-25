using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    [SerializeField] private Color color;

    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform; // �������� �������� �������
    [SerializeField] private float cameraDistance = 5f;  // ������� ��� ������ ���������
    [SerializeField] private float cameraHeight = 2f;    // ������ �������� �� ������
    [SerializeField] private float cameraSmoothSpeed = 0.125f; // ���� ����� ���� ��������

    private Rigidbody rb;
    private Renderer renderer;

    private float inputHorizontal;
    private float inputVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
        renderer.material.color = color;

        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned. Please assign it in the inspector.");
        }
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical);

        // ��� ���� ���� ���ɡ �� ������ ������
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            RotatePlayer();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputHorizontal * speed * Time.fixedDeltaTime, rb.velocity.y, inputVertical * speed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (cameraTransform != null)
        {
            MoveCamera();
        }
    }

    private void RotatePlayer()
    {
        // ���� ����� ������ ����� ��� ��������
        Vector3 direction = new Vector3(inputHorizontal, 0f, inputVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // ���� ����� �������
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // ����� ������
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * speed);
        }
    }

    private void MoveCamera()
    {
        // ����� ���� �������� ��� ������
        Vector3 desiredPosition = transform.position - transform.forward * cameraDistance + Vector3.up * cameraHeight;

        // ���� �������� ������
        Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, cameraSmoothSpeed);
        cameraTransform.position = smoothedPosition;

        // ����� �������� ����� ��� ������
        cameraTransform.LookAt(transform);
    }
}
