using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

    public Text powerUpInfo;


	public virtual void TakeContact(string type)
    {
        powerUpInfo.text = type;
        gameObject.SetActive(false);
    }


}
