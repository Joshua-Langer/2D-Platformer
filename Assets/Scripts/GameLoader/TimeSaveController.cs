using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeSaveController : MonoBehaviour
{
    private string secretKey = "N2L2Cv0uxHLP5iGzoK6DVQ0aPZa0iZxv"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://10.200.100.200:9000/addtime.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://10.200.100.200:9000/display.php?";
    public Text text;
    public Text bestText;
    void Start()
    {
        StartCoroutine(GetScores());
    }

    // remember to use StartCoroutine when calling this function!
    public IEnumerator PostScores(string name, TimeSpan time)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = Md5Sum(name + time + secretKey);

        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&time=" + time + "&hash=" + hash;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the best time: " + hs_post.error);
        }
    }

    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        text.text = "Best Time: ";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the best time: " + hs_get.error);
        }
        else
        {
            bestText.text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

}
