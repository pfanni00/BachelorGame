using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarHandleSize : MonoBehaviour
{
    // dieses Script bindet die Scrollbar der ReadView texte mit TextMeshPro

    // ScrollRect des aktuellen ReadViews
	public ScrollRect scrollRect;
    // Slider des aktuellen ReadViews
    public Slider slider;

    void Start()
    {
        // slider wird an die Text länge angepasst. 
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        if (scrollRect.horizontal)
        {
            scrollRect.horizontalNormalizedPosition = value;
        }
        else if (scrollRect.vertical)
        {
            scrollRect.verticalNormalizedPosition = value;
        }
    }
}