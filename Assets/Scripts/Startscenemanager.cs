using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscenemanager : MonoBehaviour
{
    public void PressStart()
    {
        SceneManager.LoadScene("gamescene");
    }
}
