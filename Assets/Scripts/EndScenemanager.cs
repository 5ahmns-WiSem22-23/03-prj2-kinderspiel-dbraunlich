
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScenemanager : MonoBehaviour
{
    public Text status;

    private void Start()
    {
        status.text = game.winner == "boat" ? "Das Boot hat gewonnen" : "Die Fische haben gewonnen";
    }

    public void PressRestart()
    {
        SceneManager.LoadScene("StartScene");
    }


}
