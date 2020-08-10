using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSort : MonoBehaviour
{
    //начальные значения цветов
    public Image[] images;
    private List<Color> _colorList;
    private void Start()
    {
        images = GetComponentsInChildren<Image>();
        FindObjectOfType<BallControl>().ChangeColorEvent += SetColor;

        _colorList = new List<Color>();
        for(int i = 0; i < ColorOfMaterial.instance.colors.Length; i++)
        {
            _colorList.Add(ColorOfMaterial.instance.colors[i]);
        }
    }
    public void SetColor(Color color)
    {       
        for(int i = 0; i < images.Length; i++)
        {
            int random = Random.Range(0, _colorList.Count);
            images[i].color = _colorList[random];
            _colorList.RemoveAt(random);
        }

        _colorList.Clear();
        for (int i = 0; i < ColorOfMaterial.instance.colors.Length; i++)
        {
            _colorList.Add(ColorOfMaterial.instance.colors[i]);
        }
    }    
}
