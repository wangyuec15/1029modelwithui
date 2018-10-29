using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class delete : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    public GameObject todelete;

    public bool goingtodelete = false;



    void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(myAction);

	}
	
	// Update is called once per frame
	void Update () {

        todelete = GameObject.Find("sofaCollecter").GetComponent<forFurnitureCollect>().curFurniture;

        if (todelete != null)
        {
            gameObject.transform.position = todelete.transform.position+new Vector3(10,15,0);

        }
	}

    void myAction()
    {
        todelete.GetComponent<forEachFurniture>().choosing = true;
        todelete.GetComponent<Renderer>().sharedMaterial.SetColor("_OutlineColor", Color.blue);
        Debug.Log("i die");
        //Destroy(todelete);
        goingtodelete = false;
        gameObject.SetActive(false);
    }



    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        goingtodelete = true;
        Debug.Log("don't destroy me!!!!!!!!!");
    }

   
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        goingtodelete = false;
        Debug.Log("233333333333");
    }



}
