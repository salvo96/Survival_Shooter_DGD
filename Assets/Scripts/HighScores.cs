using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    string pName = UserInfo.GetPlayerName();
    int score = UserScore<int>.GetScore();  //lo score che l'utente ha appena ottenuto
    int curr_score;
    string curr_name;

    private void Awake()
    {
        SetData();  //richiamo il metodo per settare la classifica
    }

    public void SetData()
    {
        if(UserScore<int>.GetFinished())
            for (int i=1; i<11; i++)    //ricerco la posizione in cui salvarlo
            {
                if (PlayerPrefs.HasKey(i.ToString()))   //ho già un punteggio in questa posizione
                {
                    curr_name = PlayerPrefs.GetString(i.ToString());
                    if (PlayerPrefs.HasKey(curr_name))
                    {
                        curr_score = PlayerPrefs.GetInt(curr_name);
                        if (score > curr_score)
                        {
                            //inizia lo shift in basso
                            ShiftLow(i);
                            //salva posizione 
                            PlayerPrefs.SetString(i.ToString(), pName);
                            PlayerPrefs.SetInt(pName, score);   //assegno direttamente al nome il punteggio => se >10 non salvo
                            //esci dal ciclo
                            break;
                        }
                    }
                }
                else //non ho salvato ancora nessun punteggio in questa posizione
                {
                    //posso assegnare il punteggio in questa posizione
                    PlayerPrefs.SetString(i.ToString(), pName);
                    PlayerPrefs.SetInt(pName, score);
                    break;
                }           
            
            }
        
    }

    void ShiftLow(int pos)
    {
        if (PlayerPrefs.HasKey("10"))
            PlayerPrefs.DeleteKey(PlayerPrefs.GetString("10")); //cancello il risultato dell'utente in posizione 10
        for(int i=10; i>pos; i--)
        {
            if (PlayerPrefs.HasKey((i-1).ToString()))
                PlayerPrefs.SetString(i.ToString(), PlayerPrefs.GetString((i-1).ToString()));
        }
    }
}
