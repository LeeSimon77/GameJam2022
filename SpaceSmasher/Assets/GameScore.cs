using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameScoreScript
{
    private static int gameScore;

    public static int GameScore
    {
        get
        {
            return gameScore;
        }
        set
        {
            gameScore = value;
        }
    }
}
