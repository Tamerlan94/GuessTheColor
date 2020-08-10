using TMPro;
using UnityEngine;

public class MenuText : MonoBehaviour
{
    public TextMeshProUGUI gameName;
    private void Start()
    {
        gameName.text = FindObjectOfType<Lang>().Name;
        FindObjectOfType<Lang>().ChangeLang += OnChanged;
    }
    private void OnChanged()
    {
        gameName.text = FindObjectOfType<Lang>().Name;
    }
}
