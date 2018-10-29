using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choosesofa : MonoBehaviour
{
    private GameObject panel;
    private GameObject panel2;
    // Use this for initialization
    void Start()
    {
        panel= GameObject.Find("Panel");
        panel2= GameObject.Find("Panel (1)");

        gameObject.GetComponent<Button>().onClick.AddListener(myAction);
    }

    void myAction()
    {
        //Debug.Log(GameObject.Find("Panel"));
        panel.SetActive(true);
        panel2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
