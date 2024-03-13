using UnityEngine;
using UnityEngine.UI;

public class UIScrollbarHandleSize : MonoBehaviour
{
public Scrollbar scrollbar;
public float size = 0.2f;

public void OnValueChangeSize()
{
    scrollbar.size = size;
}

private void LateUpdate()
{
    enabled = false;
    OnValueChangeSize();
}
}