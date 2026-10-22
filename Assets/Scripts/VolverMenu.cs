using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    // Función para ir directo al menú principal
    public void IrAlMenu()
    {
        SceneManager.LoadScene("menuPrincipal");
    }
}