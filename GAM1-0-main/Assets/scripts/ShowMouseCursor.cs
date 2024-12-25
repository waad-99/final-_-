using UnityEngine;

public class ShowMouseCursor : MonoBehaviour
{
    void Start()
    {
        // ÅÙåÇÑ ÇáãÄÔÑ æÊÚííä æÖÚ ÇáŞİá Åáì None (ÛíÑ ãŞİá)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}