using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class WinScreen : Menu<WinScreen>
{

    public void OnNextLevelPressed()
    {

        OnMainMenuPressed();
    }

    public void OnRestartPressed()
    {
        Time.timeScale = 1;
        InstructionsMenu.Open();
        InstructionsMenu.Instance.InitializeRoutine();
        LevelLoader.ReloadLevel();
    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1;
        LevelLoader.LoadMainMenuLevel();
        MainMenu.Open();
    }


}
