using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainScene : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
