using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void JugarPartida()
    {
        SceneManager.LoadScene("PrisonCell");
    }

    // Método para ir al menú de cosméticos (reemplaza "CosmeticsScene" por el nombre de tu escena)
    public void IrACosmeticos()
    {
        SceneManager.LoadScene("CosmeticsScene");
    }
}