using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels; // مصفوفة لتخزين جميع البانيلز
    public GameObject panelToHide; // بانيل الذي سيتم إخفاؤه عند إظهار بانيل جديد

    // دالة لعرض بانيل معين
    public void ShowPanel(int index)
    {
        // إذا كان هناك بانيل يتم إخفاؤه، إخفاؤه الآن
        if (panelToHide != null)
        {
            panelToHide.SetActive(false);
        }

        // إخفاء جميع البانيلز أولًا
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // إظهار البانيل المحدد
        if (index >= 0 && index < panels.Length)
        {
            panels[index].SetActive(true);
            panelToHide = panels[index]; // تعيين البانيل الذي تم إظهاره ليكون البانيل الذي سيتم إخفاؤه لاحقًا
        }
    }
}
