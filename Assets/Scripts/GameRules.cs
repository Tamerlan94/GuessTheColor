using UnityEngine;

public class GameRules : MonoBehaviour
{
    public BallControl ball;

    [SerializeField] private Color _currentNeedColor;
    
    private void Start()
    {
        //подписывание на делегат изменения цвета шара
        ball.ChangeColorEvent += OnChangeColor;
    }

    private void OnChangeColor(Color ballColor)
    {       
        _currentNeedColor = ballColor;
        

        Debug.Log("Нужный цвет: " + _currentNeedColor);
    }
}
