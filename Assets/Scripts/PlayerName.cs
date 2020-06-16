using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    Text playerName;

    // Use this for initialization
    void Awake () {
        playerName = GetComponent<Text>();
        playerName.text = playerName.text + UserInfo.GetPlayerName();
    }

}
