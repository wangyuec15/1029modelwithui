using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class close : MonoBehaviour {

    private GameObject panel;
    private GameObject panel2;
    // Use this for initialization
    void Start () {
        panel = GameObject.Find("Panel");
        panel2 = GameObject.Find("Panel (1)");

        gameObject.GetComponent<Button>().onClick.AddListener(myAction);
	}
	
    void myAction(){
        panel.SetActive(false);
        panel2.SetActive(false);

    }

	// Update is called once per frame
	void Update () {
		
	}
}
