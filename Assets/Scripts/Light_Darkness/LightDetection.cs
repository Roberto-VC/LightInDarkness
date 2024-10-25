using System.Collections;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("La cámara que escanea la luz.")]
    public Camera camLightScan;
    [Tooltip("Mostrar el valor de la luz en el log.")]
    public bool logLightValue = false;
    [Tooltip("Tiempo entre actualizaciones del valor de luz (por defecto = 0.1f).")]
    public float updateTime = 0.1f;
    [Tooltip("Umbral para determinar si la luz debe ser registrada.")]
    public float lightThreshold = 0.5f;

    public static float lightValue;
    private const int textureSize = 1;

    private Texture2D texLight;
    private RenderTexture texTemp;
    private Rect rectLight;
    private Color lightPixel;

    private void Start()
    {
        StartLightDetection();
    }

    private void StartLightDetection()
    {
        texLight = new Texture2D(textureSize, textureSize, TextureFormat.RGB24, false);
        texTemp = new RenderTexture(textureSize, textureSize, 24);
        rectLight = new Rect(0f, 0f, textureSize, textureSize);

        StartCoroutine(LightDetectionUpdate(updateTime));
    }
    
    private IEnumerator LightDetectionUpdate(float updateTime)
    {
        while (true)
        {
            camLightScan.targetTexture = texTemp;
            camLightScan.Render();

            RenderTexture.active = texTemp;
            texLight.ReadPixels(rectLight, 0, 0);

            RenderTexture.active = null;
            camLightScan.targetTexture = null;

            lightPixel = texLight.GetPixel(textureSize / 2, textureSize / 2);

            // Calcular el valor de la luz basado en la intensidad del color
            lightValue = (lightPixel.r + lightPixel.g + lightPixel.b) / 3f;

            // Detectar color específico según el threshold
            if (lightValue > lightThreshold)
            {
                Debug.Log("El valor de luz supera el umbral: " + lightValue);
            }

            // Mostrar el valor de la luz si está habilitado
            if (logLightValue)
            {
                Debug.Log("Valor de luz: " + lightValue);
            }

            yield return new WaitForSeconds(updateTime);
        }
    }
}
