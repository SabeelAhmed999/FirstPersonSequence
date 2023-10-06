using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIElementAnimation : MonoBehaviour
{
    public Vector3 startScale = new Vector3(0.1f, 0.1f, 1f);  // Initial scale
    public Vector3 targetScale = new Vector3(1f, 1f, 1f);      // Target scale
    public float scaleSpeed = 1.0f;                             // Scaling speed
    public float delayBeforeScaleDown = 1.0f;                   // Delay before scaling down on deactivation

    private Coroutine scalingCoroutine;
    private RectTransform rectTransform;
    private bool isAnimating = false;

    private void Awake()
    {
        // Get the RectTransform component of the UI element
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        if (!isAnimating)
        {
            // Start scaling up as soon as the UI element becomes active
            scalingCoroutine = StartCoroutine(ScaleUp());
            isAnimating = true;
        }
    }

    public void OffObject()
    {
        if (isAnimating)
        {
            // If the UI element is deactivated, stop the scaling coroutine
            if (scalingCoroutine != null)
            {
                StopCoroutine(scalingCoroutine);
            }

            // Delay before scaling down (you can adjust the delay as needed)
            StartCoroutine(DelayedScaleDown());
            isAnimating = false;
        }
    }

    private IEnumerator ScaleUp()
    {
        Vector3 currentScale = startScale;

        while (currentScale.x < targetScale.x)
        {
            currentScale += Vector3.one * scaleSpeed * Time.deltaTime;
            rectTransform.localScale = currentScale;
            yield return null;
        }

        // Ensure we set the exact target scale
        rectTransform.localScale = targetScale;
    }

    private IEnumerator DelayedScaleDown()
    {
        yield return new WaitForSeconds(delayBeforeScaleDown);

        Vector3 currentScale = rectTransform.localScale;

        while (currentScale.x > startScale.x)
        {
            currentScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            rectTransform.localScale = currentScale;
            yield return null;
        }
        // Ensure we set the exact start scale
        rectTransform.localScale = startScale;

        // After completing the scale-down animation, deactivate the object
        gameObject.SetActive(false);
    }

}
