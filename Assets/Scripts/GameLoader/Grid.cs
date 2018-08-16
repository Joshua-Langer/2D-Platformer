using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Grid
{
    public static GameSFX gameSFX;
    public static GameMusicProper gameMusicProper;
    public static GameManagerProper gameManagerProper;

    static Grid()
    {
        GameObject g = safeFind("__app");

        gameSFX = (GameSFX)SafeComponent(g, "GameSFX");
        gameMusicProper = (GameMusicProper)SafeComponent(g, "GameMusicProper");
        gameManagerProper = (GameManagerProper)SafeComponent(g, "GameManagerProper");
    }


    private static GameObject safeFind(string s)
    {
        GameObject g = GameObject.Find(s);
        if (g == null) Woe("GameObject " + s + " not on _preload");
        return g;
    }

    private static Component SafeComponent(GameObject g, string s)
    {
        Component c = g.GetComponent(s);
        if (c == null) Woe("Component " + s + " not on _preload");
        return c;
    }

    private static void Woe(string error)
    {
        Debug.Log(">>> Can't proceed... " + error);
        Debug.Log(">>> It is very likely you just for got to launch");
        Debug.Log(">>> from scene zero, the _preload scene.");
    }


}
