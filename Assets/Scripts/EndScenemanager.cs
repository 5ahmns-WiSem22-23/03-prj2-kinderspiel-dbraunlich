
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScenemanager : MonoBehaviour
{

    private void Start()
    {
        
    }

    public void PressRestart()
    {
        SceneManager.LoadScene("StartScene");
    }


}
