using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public GameObject PausePainel, PauseButton;

    /* public void Pause()
    {
        if(gamePaused == false) {
            PausePainel.SetActive(true);
            PauseButton.SetActive(false);

            Time.timeScale = 0;

            gamePaused = true;
        }
    }

    public void Resume()
    {
        if(gamePaused == true) {
            PausePainel.SetActive(false);
            PauseButton.SetActive(true);

            Time.timeScale = 1;

            gamePaused = false;
        }
    } */

    public static bool gamePaused = false;

    public void PauseGame() {
        if(gamePaused) {
            Time.timeScale = 1;
            gamePaused = false;
        }
        else {
            Time.timeScale = 0;
            gamePaused = true;
        }
    }
}
