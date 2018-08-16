using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.VersionEditor
{
    public class VersionPrint : MonoBehaviour
    {

        void Awake()
        {
            
        }

        void OnGUI()
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();
            Rect rect = new Rect(0, 700, w, h * 2 / 100);
            style.alignment = TextAnchor.LowerLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            string versionText = ("Game Version " + VersionInformation.ToString() + " Pre-Alpha");
            GUI.Label(rect, versionText, style);
        }
    }
}
