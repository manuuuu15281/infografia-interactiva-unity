using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Cerrando aplicación...");

        Application.Quit();
    }
}