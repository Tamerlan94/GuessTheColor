using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    public Button buttonTutorial;
    public Button buttonTutorialReturn;

    public CanvasGroup tutor_canvas;

    private int firstPlay = 0;
    private void Start()
    {
        buttonTutorial.onClick.AddListener(ShowTutorial);
        buttonTutorialReturn.onClick.AddListener(CloseTutorial);

        firstPlay = PlayerPrefs.GetInt("FirstPlay", 0);
        if(firstPlay == 0)
        {            
            PlayerPrefs.SetInt("FirstPlay", 1);
            Invoke("ShowTutorial", 1f);
        }
    }
    private void ShowTutorial()
    {
        tutor_canvas.DOFade(1f, .3f).SetUpdate(UpdateType.Normal, true);
        tutor_canvas.blocksRaycasts = true;
        Time.timeScale = 0f;
    }
    private void CloseTutorial()
    {
        tutor_canvas.DOFade(0f, .3f).SetUpdate(UpdateType.Normal, true);
        tutor_canvas.blocksRaycasts = false;
        Time.timeScale = 1f;
    }
}
