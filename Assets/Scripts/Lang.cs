using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;
using TMPro;

public class Lang : MonoBehaviour
{    
    public string Name;
    public string GameOver;
    public string Pause;
    public string Hiscore;
    public string Tutorial1;
    public string Tutorial2;
    public string Tutorial3;

    private string currentLang;
    private string path;

    public event Action ChangeLang;
    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            Load("Russian");
        }
        else
        {
            Load("English");
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeLanguage()
    {
        if(currentLang == "English")
        {
            Load("Russian");
            currentLang = "Russian";
        }
        else if(currentLang == "Russian")
        {
            Load("English");
            currentLang = "English";
        }
    }

    public void Load(string lang)
    {
        TextAsset xmlTextAsset = Resources.Load<TextAsset>("XML/Lang");
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlTextAsset.text);
        XmlElement xRoot = xDoc.DocumentElement;
        foreach(XmlElement xnode in xRoot)
        {
            XmlNode attr = xnode.Attributes.GetNamedItem("name");
            //string language = xnode.GetAttribute("lang");
            if(attr.Value == lang)
            {
                currentLang = attr.Value;
                foreach(XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "name")
                        Name = childnode.InnerText;
                    if (childnode.Name == "pause")
                        Pause = childnode.InnerText;
                    if (childnode.Name == "gameover")
                        GameOver = childnode.InnerText;
                    if (childnode.Name == "hiscore")
                        Hiscore = childnode.InnerText;
                    if (childnode.Name == "tutorial1")
                        Tutorial1 = childnode.InnerText;
                    if (childnode.Name == "tutorial2")
                        Tutorial2 = childnode.InnerText;
                    if (childnode.Name == "tutorial3")
                        Tutorial3 = childnode.InnerText;
                }
            }
        }
        ChangeLang?.Invoke();
    }
}
