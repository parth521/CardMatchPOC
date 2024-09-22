using System;
using System.Collections;
using UnityEngine;
/// <summary>
/// In this compoent I have written the code for the loading animation and mvovement doing by lerping the position of the rect
/// transform to showcase it can be done by lerping the position to show that is can be done by lerping as well
/// </summary>
public class LoadingAnimaitonComponent : UIAnimations
{
    private RectTransform rectTransform;
    [SerializeField] private float fromShow;
    [SerializeField] private float toShow;
    [SerializeField] private float fromHide;
    [SerializeField] private float toHide;
    private float elapsedTime = 0f;
    public override void Awake()
    {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
    }
    public override void Show(Action callback = null)
    {
        StartCoroutine(LerpAnchors(fromShow, toShow,showdelay, duration, callback));
    }

    public override void Hide(Action callback = null)
    {
        StartCoroutine(LerpAnchors(fromHide, toHide,hidedelay, duration, callback));
    }
    private IEnumerator LerpAnchors(float startValue, float endValue, float delay,float time, Action onComplete = null)
    {
        float elapsedTime = 0f;

        if (delay > 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        // Cache the initial position of the RectTransform
        Vector2 initialPosition = rectTransform.anchoredPosition;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float lerpedX = Mathf.Lerp(startValue, endValue, elapsedTime / time);

            // Apply the interpolated X value to the RectTransform's anchoredPosition
            rectTransform.anchoredPosition = new Vector2(lerpedX, initialPosition.y);

            // Wait until the next frame
            yield return null;
        }

        // Ensure the final position is set exactly to the target X value
        rectTransform.anchoredPosition = new Vector2(endValue, initialPosition.y);

        // Invoke the callback when movement is complete
        onComplete?.Invoke();
    }

}
