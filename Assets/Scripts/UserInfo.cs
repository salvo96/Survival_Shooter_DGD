using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserInfo{

    public enum Difficulty { Easy, Medium, Hard };

    static string playerName;    
    static Difficulty level;
    static float attackDamageDifficulty = 0f;

    public static void SetPlayerSetting(string name)
    {
        playerName = name;
    }    

    public static void SetPlayerSetting(float levelValue){  //overload
        if(levelValue == 1)
            level = Difficulty.Easy;
        if(levelValue == 2)
            level = Difficulty.Medium;
        if(levelValue == 3)
            level = Difficulty.Hard;
    }

    public static string GetPlayerName()
    {
        return playerName;
    }

    public static Difficulty GetLevel()
    {
        return level;
    }

    /*metodi che mi restituiscono i parametri della partita in funzione del livello scelto dal giocatore*/

    public static float GetSpawnTime()
    {
        switch (level)
        {
            case Difficulty.Easy:
                return 7f;
            case Difficulty.Medium:
                return 5f;
            case Difficulty.Hard:
                return 3f;
            default:
                return 0f;
        }
    }

    public static float GetAttackDamage()
    {
        switch (level)
        {
            case Difficulty.Easy:
                return 5f + attackDamageDifficulty;
            case Difficulty.Medium:
                return 15f + attackDamageDifficulty;
            case Difficulty.Hard:
                return 25f + attackDamageDifficulty;
            default:
                return 0;
        }
    }

    public static float GetDuration()
    {
        switch (level)
        {
            case Difficulty.Easy:
                return 90f;
            case Difficulty.Medium:
                return 60f;
            case Difficulty.Hard:
                return 30f;
            default:
                return 0f;
        }
    }

    public static void SetAttackDamageDifficulty(float value)
    {
        attackDamageDifficulty = value;
    }

    public static float GetAttackDamageDifficulty()
    {
        return attackDamageDifficulty;
    }


}



