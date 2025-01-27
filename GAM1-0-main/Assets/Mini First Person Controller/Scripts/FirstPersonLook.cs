﻿using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;
    private bool isCursorVisible = false; // حالة ظهور الماوس

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // إخفاء المؤشر افتراضيًا عند بدء اللعبة
        SetCursorState(false);
    }

    void Update()
    {
        // Toggle cursor visibility with Escape key.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorVisible = !isCursorVisible; // عكس حالة الماوس
            SetCursorState(isCursorVisible);
        }

        // استمر بتحريك الكاميرا بغض النظر عن حالة المؤشر
        HandleCameraRotation();
    }

    void HandleCameraRotation()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }

    void SetCursorState(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked; // قفل أو إلغاء قفل المؤشر
        Cursor.visible = visible; // جعل المؤشر مرئيًا أو مخفيًا
    }
}
