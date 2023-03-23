using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject UIPanel;
    public GameObject gameOverPanel;
    // public GameObject creditsPanel;
    public TextMeshProUGUI finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.Reset(false);
    }

    public void ActiveUIPanel(bool isActive)
    {
        this.UIPanel.SetActive(isActive);
    }

    public void ActiveStartPanel(bool isActive)
    {
        this.startPanel.SetActive(isActive);
    }

    public void ActiveGameOverPanel(bool isActive)
    {
        this.gameOverPanel.SetActive(isActive);
    }

    public void Reset(bool isRestart)
    {
        if (isRestart)
        {
            ActiveStartPanel(false);
            ActiveUIPanel(true);
            ActiveGameOverPanel(false);
        }
        else
        {
            ActiveStartPanel(true);
            ActiveUIPanel(false);
            ActiveGameOverPanel(false);
        }
    }
}
