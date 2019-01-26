using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showRestart : MonoBehaviour {

    public GameObject restartButton;

    private void Start()
    {
        restartButton.SetActive(false);
    }

    void Update() {

        if (GameControlScript.health == 0){
            restartButton.SetActive(true);
        }
    }
}
