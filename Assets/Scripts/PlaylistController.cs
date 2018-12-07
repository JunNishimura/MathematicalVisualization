using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistController : MonoBehaviour
{
    public static int currentFuncID = 0;

    //----- Objects -----//
    [SerializeField] private GameObject ExamplesObj;
    [SerializeField] private GameObject OriginalsObj;
    [SerializeField] private GameObject ExampleListContent;
    public GameObject funcExample; 
    private List<string> ListGraphFunctions; // list having examples;

    private void Awake()
    {
        //----- set up button events -----//
        ExamplesObj.GetComponentInChildren<Button>().onClick.AddListener(ExampleButtonPressed);
        OriginalsObj.GetComponentInChildren<Button>().onClick.AddListener(OriginalButtonPressed);

        //----- default setting -----//
        // call ExampleButtonPressed() to activate example tab and deactivate original tab
        ExampleButtonPressed();

        //----- set up Main View -----//
        string[] StringGraphNames = System.Enum.GetNames(typeof(GraphFunctionName)); // put enum into string arrays
        ListGraphFunctions = new List<string>(StringGraphNames); // put string arrays into list
        SetScrollView();
    }

    private void SetScrollView()
    {
        for (int i = 0; i < ListGraphFunctions.Count; i++)
        {
            GameObject item = Instantiate(funcExample).gameObject;
            item.GetComponent<RectTransform>().SetParent(ExampleListContent.transform, false); // set parent
            if (i % 2 == 0) // change the background color 
            {
                item.GetComponent<Image>().color = Color.white;
            }
            else
            {
                item.GetComponent<Image>().color = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f, 1.0f);
            }
            Text itemText = item.GetComponentInChildren<Text>();
            itemText.text = ListGraphFunctions[i];
            int ID = i; // iをlocal変数(ここではID)に代入してからparameterに渡さないと、全てのparameterが同じlistGraphFunctionts.Countの長さを参照してしまう。
            item.GetComponent<Button>().onClick.AddListener(() => FuncExampleButtonPressed(ID));
        }
    }

    //----- button event functions -----//
    // example button event
    private void ExampleButtonPressed()
    {
        // activate example tab, deactivate original tab
        ExamplesObj.transform.GetChild(0).gameObject.SetActive(false);
        ExamplesObj.transform.GetChild(1).gameObject.SetActive(true);
        OriginalsObj.transform.GetChild(0).gameObject.SetActive(true);
        OriginalsObj.transform.GetChild(1).gameObject.SetActive(false);
        // activate example list content
        ExampleListContent.SetActive(true);
    }

    // original button event
    private void OriginalButtonPressed()
    {
        // activate original tab, deactivate example tab
        ExamplesObj.transform.GetChild(0).gameObject.SetActive(true);
        ExamplesObj.transform.GetChild(1).gameObject.SetActive(false);
        OriginalsObj.transform.GetChild(0).gameObject.SetActive(false);
        OriginalsObj.transform.GetChild(1).gameObject.SetActive(true);
        // activate original list content
        ExampleListContent.SetActive(false);
    }

    private void FuncExampleButtonPressed(int ID)
    {
        currentFuncID = ID;
    }

    //----- button event functions -----//

}
