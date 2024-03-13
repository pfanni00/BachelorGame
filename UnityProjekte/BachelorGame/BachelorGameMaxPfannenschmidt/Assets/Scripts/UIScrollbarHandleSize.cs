using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarHandleSize : MonoBehaviour
{
	public ScrollRect scrollRect;
    public Slider slider;

    void Start()
    {
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