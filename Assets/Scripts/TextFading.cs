using UnityEngine;
using TMPro;

public class TextFading : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float fadeSpeed = 5f;

    private bool isFading = false;
    private float currentAlpha = 1f;
    private float targetAlpha = 0f;

    private void Start()
    {
        StartFading();
    }

    private void Update()
    {
        if (isFading)
        {
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, currentAlpha);

            if (Mathf.Abs(currentAlpha - targetAlpha) < 0.01f)
            {
                if (targetAlpha == 0f)
                    targetAlpha = 1f;
                else
                    targetAlpha = 0f;
            }
        }
    }

    public void StartFading()
    {
        isFading = true;
    }

}
