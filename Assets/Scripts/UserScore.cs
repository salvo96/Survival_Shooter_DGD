using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserScore<T>{

    static T score;
    static bool just_finished;

    public static void SetScore(T match_score)  //il generics agisce in modo tale da rendere la classe un memorizzatore generico di sessione di oggetti di tipo T
    {
        score = match_score;
    }

    public static T GetScore()
    {
        return score;
    }

    public static void SetFinished(bool finished)
    {
        just_finished = finished;
    }

    public static bool GetFinished()
    {
        return just_finished;
    }
	
}
