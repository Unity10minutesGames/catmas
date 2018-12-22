using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    enum Scenes { Welcome, MainGame, GameOver};

    public void LoadWelcomeScene()
    {
        SceneManager.LoadScene((int)Scenes.Welcome);
    }

    public void LoadMainGameScene()
    {
        SceneManager.LoadScene((int)Scenes.MainGame);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene((int)Scenes.GameOver);
    }
}
