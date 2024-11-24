using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar escenas

public class UI : MonoBehaviour
{
    // Métodos para cargar las escenas
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1"); // Reemplaza "Level1" con el nombre exacto de tu escena
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2"); // Reemplaza "Level2" con el nombre exacto de tu escena
    }
}
