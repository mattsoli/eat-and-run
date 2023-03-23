using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public UIController ui;

    private void Awake()
    {
        Time.timeScale = 0f;
        this.player.isAlive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.player.isAlive) // player is dead
        {
            this.GameOver();
        }
    }

    public void StartGame()
    {
        this.ui.ActiveStartPanel(false);
        this.ui.ActiveUIPanel(true);
        this.ui.ActiveGameOverPanel(false);
        Time.timeScale = 1f;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        this.player.enabled = false; // for stop the input controller on the player
        this.ui.finalScoreText.text = "Distance Traveled: " + this.player.distanceTraveled + " m";
        this.ui.ActiveGameOverPanel(true);
    }

    public void RestartGame()
    {
        this.player.Reset();
        this.player.enabled = true;
        TilesGenerator.Instance.Reset();
        this.player.GetComponent<EnergyController>().Restart();
        this.StartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
