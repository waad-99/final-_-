using UnityEngine;

public class ShowMouseCursor : MonoBehaviour
{
    void Start()
    {
        // ����� ������ ������ ��� ����� ��� None (��� ����)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}