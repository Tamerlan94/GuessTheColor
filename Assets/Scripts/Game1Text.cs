using UnityEngine;
using TMPro;

public class Game1Text : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI gamePause;
    public TextMeshProUGUI gameHiscore;

    public TextMeshProUGUI tutorial1;
    public TextMeshProUGUI tutorial2;
    public TextMeshProUGUI tutorial3;
    private void Start()
    {
        gameOver.text = FindObjectOfType<Lang>().GameOver;
        gamePause.text = FindObjectOfType<Lang>().Pause;
        gameHiscore.text = FindObjectOfType<Lang>().Hiscore;

        tutorial1.text = FindObjectOfType<Lang>().Tutorial1;
        tutorial2.text = FindObjectOfType<Lang>().Tutorial2;
        tutorial3.text = FindObjectOfType<Lang>().Tutorial3;

        FindObjectOfType<Lang>().ChangeLang += OnChanged;
    }
    private void OnChanged()
    {
        gameOver.text = FindObjectOfType<Lang>().GameOver;
        gamePause.text = FindObjectOfType<Lang>().Pause;
        gameHiscore.text = FindObjectOfType<Lang>().Hiscore;

        tutorial1.text = FindObjectOfType<Lang>().Tutorial1;
        tutorial2.text = FindObjectOfType<Lang>().Tutorial2;
        tutorial3.text = FindObjectOfType<Lang>().Tutorial3;
    }
}
