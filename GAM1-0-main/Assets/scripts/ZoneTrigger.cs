using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZoneTrigger : MonoBehaviour
{
    public Image uiImage; // مرجع للصورة في واجهة المستخدم
    public float displayTime = 3f; // عدد الثواني التي ستظهر فيها الصورة

    private void Start()
    {
        uiImage.gameObject.SetActive(false); // إخفاء الصورة في البداية
    }

    private void OnTriggerEnter(Collider other)
    {
        // التحقق من دخول اللاعب
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowImage()); // بدء إظهار الصورة عند دخول اللاعب
        }
    }

    private IEnumerator ShowImage()
    {
        uiImage.gameObject.SetActive(true); // إظهار الصورة
        yield return new WaitForSeconds(displayTime); // الانتظار لمدة معينة
        uiImage.gameObject.SetActive(false); // إخفاء الصورة بعد الانتظار
    }
}
