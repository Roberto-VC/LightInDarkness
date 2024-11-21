using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image progressBarForeground;
    public void SetProgress(float progress)
    {
        progressBarForeground.fillAmount = progress;
    }
}
