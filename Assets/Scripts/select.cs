using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class emm : MonoBehaviour, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(name + " Game Object Clicked!");
    }
}




public class select : MonoBehaviour,IPointerClickHandler{
    int n = 6;
    private Button thebutton; 
    private GameObject showing;
    private GameObject showname;
    private GameObject count;
    public Sprite outline;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(name + " Game Object Clicked!");
    }



	void Start () {
        thebutton = Resources.Load<Button >("thebutton");


        showing = GameObject.Find("showing");
        outline = Resources.Load<Sprite>("InBorder");
        showname = GameObject.Find("name");
        count = GameObject.Find("count");
        Debug.Log(outline);




        gameObject.GetComponent<GridLayoutGroup>().cellSize = new Vector2(showing.GetComponent<Image>().sprite.texture.width, showing.GetComponent<Image>().sprite.texture.height);

        gameObject.GetComponent<GridLayoutGroup>().padding.left =(int)((gameObject.GetComponent<RectTransform>().rect.width - showing.GetComponent<Image>().sprite.texture.width) / 2);

        for (int i = 0; i < n; i++)
        {
            Button[] a;
            a = new Button[n];

            a[i] = Instantiate(thebutton);
            a[i].transform.parent = gameObject.transform;

            a[i].name = (i + 1).ToString();
            a[i].transform.localPosition=new Vector3(a[i].transform .localPosition.x,a[i].transform.localPosition.y,0);
            a[i].transform.localScale = new Vector3(1, 1, 1);

            a[i].gameObject.AddComponent<UIInfo>();
            a[i].GetComponent<UIInfo>().sofa = Resources.Load<GameObject>("sofa");
            a[i].GetComponent<UIInfo>().picture = Resources.Load<Sprite>(i.ToString()).texture;




            a[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(i.ToString());
            if (i % 3 == 1)
            {
                a[i].transform.GetChild(1).GetComponent<Text>().text ="宜家沙发";
            }else if(i%3==2){
                a[i].transform.GetChild(1).GetComponent<Text>().text = "现代沙发";
            }else {
                a[i].transform.GetChild(1).GetComponent<Text>().text = "阁楼沙发";
            }
            Button current = gameObject.transform.GetChild(i).GetComponent<Button>();
            current.GetComponent<Button>().onClick.AddListener(delegate
            {
                TaskWithParameters(current);
               // Debug.Log(current);
            });
            gameObject.transform.GetChild(i).GetChild(0).GetComponent<Image>().color = Color.clear;

            }


	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void TaskWithParameters(Button  btn){
        for (int index = 0; index < gameObject.transform.childCount; index++)
        {
            gameObject .transform.GetChild(index ).GetChild(0).GetComponent<Image>().color  = Color .clear;

        }
        showing.GetComponent<Image>().sprite = btn.GetComponent<Button>().GetComponent<Image>().sprite;
        showing.GetComponent<UIInfo>().sofa = Resources.Load<GameObject>("sofa");
        showing.GetComponent<UIInfo>().picture = btn.GetComponent<UIInfo>().picture;

        btn.transform .GetChild (0).GetComponent<Image>().sprite = outline;
        btn.transform.GetChild(0).GetComponent<Image>().color = Color.white ;

        showname.GetComponent<Text>().text = btn.transform.GetChild(1).GetComponent<Text>().text;
        count.GetComponent<Text>().text = btn .name+"/" +gameObject.transform.childCount.ToString();
    }

  
}
