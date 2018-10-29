using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allshitu : MonoBehaviour
{
    int n = 3;
    void Start()
    {
        for (int i = 0; i < n; i++)
        {
            Button current = gameObject.transform.GetChild(i).GetComponent<Button>();
            current.GetComponent<Button>().onClick.AddListener(delegate
            {
                TaskWithParameters(current);
            });
            current.GetComponent<Button>().interactable = true;
        }

    }

    void TaskWithParameters(Button btn){
        for (int i = 0; i < n;i++){
            gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("shitu" + i.ToString());
            gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;

        }
        btn.GetComponent<Button>().interactable = false;

    }

}
