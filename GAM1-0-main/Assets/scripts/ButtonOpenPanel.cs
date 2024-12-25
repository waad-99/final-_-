using UnityEngine;

public class ButtonOpenObject : MonoBehaviour
{
    // مرجع إلى الأوبجيكت الذي تريد فتحه
    public GameObject obj;

    // هذه الدالة تُستدعى عند تشغيل اللعبة
    void Start()
    {
        // تأكد من أن الأوبجيكت مغلق في البداية
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }

    // وظيفة تُستدعى عند الضغط على الزر
    public void OpenObject()
    {
        if (obj != null)
        {
            obj.SetActive(true); // تفعيل الأوبجيكت
        }
    }
}
