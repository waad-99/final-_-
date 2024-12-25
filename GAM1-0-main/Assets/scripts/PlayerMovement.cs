using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // ÓÑÚÉ ÇáÍÑßÉ
    public float rotationSpeed = 2f; // ÓÑÚÉ ÇáÏæÑÇä

    private CharacterController characterController;

    void Start()
    {
        // ÇáÍÕæá Úáì ãßæä CharacterController
        characterController = GetComponent<CharacterController>();

        // ÇáÊÃßÏ ãä æÌæÏ CharacterController
        if (characterController == null)
        {
            Debug.LogError("CharacterController is missing on this GameObject!");
            enabled = false; // ÊÚØíá ÇáÓßÑíÈÊ ÅĞÇ áã íÊã ÇáÚËæÑ Úáíå
            return;
        }
    }

    void Update()
    {
        // ÇáÍÕæá Úáì ãÏÎáÇÊ ÇáÍÑßÉ
        float horizontalInput = Input.GetAxis("Horizontal"); // ãİÇÊíÍ A æ D Ãæ ÇáÃÓåã íãíä æíÓÇÑ
        float verticalInput = Input.GetAxis("Vertical");   // ãİÇÊíÍ W æ S Ãæ ÇáÃÓåã ÃÚáì æÃÓİá

        // ÍÓÇÈ ÇÊÌÇå ÇáÍÑßÉ
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize(); // ÌÚá Øæá ÇáãÊÌå 1 áÖãÇä ÓÑÚÉ ËÇÈÊÉ

        // ÊÍæíá ÇÊÌÇå ÇáÍÑßÉ Åáì ÇÊÌÇå ÇáÚÇáã ÈäÇÁğ Úáì ÏæÑÇä ÇáßÇãíÑÇ
        movementDirection = transform.TransformDirection(movementDirection);

        // ÊØÈíŞ ÇáÍÑßÉ ÈÇÓÊÎÏÇã CharacterController
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        // ÇáÍÕæá Úáì ãÏÎáÇÊ ÇáÏæÑÇä (ÇáãÇæÓ)
        float mouseX = Input.GetAxis("Mouse X");

        // ÊØÈíŞ ÇáÏæÑÇä
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
    }
}