using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour 
{
    //----- Objects -----//
    [SerializeField] private GameObject MenuCanvas; // MenuCanvas UI which have MenuUI and FormulaUI
    [SerializeField] private GameObject MenuIcon; // MenuIcon
    [SerializeField] private GameObject MenuCloseIcon; // MenuCloseIcon
    [SerializeField] private GameObject MenuUI; // MenuUI
    [SerializeField] private GameObject FormulaUI; // FormulaUI
    [SerializeField] private GameObject formulaButton; // formula button
    [SerializeField] private GameObject resolutionButton; // resolution button
    [SerializeField] private GameObject zoomButton; // zoom button
    [SerializeField] private GameObject playButton; // play button
    [SerializeField] private GameObject returnButton; // return button
    [SerializeField] private GameObject radialBar; // radial progress bar
    [SerializeField] private GameObject zoomSliderObj; // zoom slider UI
    [SerializeField] private Slider zoomSlider; // zoom slider

    //----- tagged Objects -----//
    private GameObject[] MenuUIs; // UI objects tagged with MenuUIs
    private GameObject[] FormulaUIs; // UI objects tagged with FormulaUIs

    //----- other varialbles -----//
    private float addAngle; // angle used in ArrangeCircularLayout Function

    //----- under construction -----//
    // varialbe for ExampleDropDown
    //public Dropdown dropdown;
    //private int prevDropdownVal = -100; // defaultで-100にするのは最初に表示できるようにするため
    // variables for formulaUI
    //private GameObject formulaTextBoard;
    //private TextMeshProUGUI formulaText;

    private void Awake()
    {

        //----- set up for tagging objects -----//
        MenuUIs = GameObject.FindGameObjectsWithTag("MenuUIs");
        FormulaUIs = GameObject.FindGameObjectsWithTag("FormulaUIs");

        //----- set up button events -----//
        MenuIcon.GetComponent<Button>().onClick.AddListener(TopMenuSetting);
        formulaButton.GetComponent<Button>().onClick.AddListener(FormulaButtonPressed);
        resolutionButton.GetComponent<Button>().onClick.AddListener(ResolutionButtonPressed);
        zoomButton.GetComponent<Button>().onClick.AddListener(ZoomButtonPressed);
        playButton.GetComponent<Button>().onClick.AddListener(PlayButtonPressed);
        returnButton.GetComponent<Button>().onClick.AddListener(TopMenuSetting);

        //----- clean the scene initially -----//
        ClearScene();
        MenuIcon.SetActive(true);

        //----- under construction -----//
        // set up for formulaUI
        //formulaTextBoard = this.transform.Find("FormulaTextBoard").game・
    }

    private void Update()
    {
        //// while menuCanvas is off, clear the scene
        //if (!menuCanvas.activeSelf && !radialBar.activeSelf)
        //{
        //    ClearScene();
        //}

        //// show menuUIs on the screen 
        if (MenuUI.activeSelf)
        {
            ArrangeCircularLayout(MenuUIs);
        }
        else if (FormulaUI.activeSelf) 
        {
            ArrangeCircularLayout(FormulaUIs);
        }

        //int dropdownVal = dropdown.value;
        //// if dropdown has changed, let's change the formulaUI
        //if (dropdownVal != prevDropdownVal)
        //{
        //    string newDropdownText = CollectionOfFunctions.TemplateFunctionFormula[dropdownVal];
        //    int newDropdownTextLength = (int)newDropdownText.Length;
        //    Debug.Log(newDropdownText + "は" + newDropdownTextLength.ToString() + "文字です");
        //    // if the length of the text is over 20, then change the size of formulaUI
        //    if (newDropdownText.Length > 20)
        //    {
        //        RectTransform formulaUIRect = formulaUI.GetComponent<RectTransform>();
        //        int sizeOfScreen = (int)this.GetComponent<RectTransform>().sizeDelta.x;
        //        Debug.Log(sizeOfScreen);
        //        // 20文字を超えた文字数１文字につき20ずつサイズを広げる
        //        int newSizeFormulaUI = 300 + (newDropdownTextLength - 20) * 10;
        //        if (newSizeFormulaUI > sizeOfScreen) newSizeFormulaUI = sizeOfScreen;
        //        Debug.Log("新しいFormulaUIのサイズは" + newSizeFormulaUI);
        //        formulaUIRect.sizeDelta = new Vector2(newSizeFormulaUI, 80);
        //    }
        //    formulaUIText.text = newDropdownText;
        //    formulaUIText.color = new Color(217.0f / 255.0f, 215.0f / 255.0f, 215.0f / 255.0f, 1.0f);
        //    prevDropdownVal = dropdownVal;
        //}

         //zoom up or zoom out depending on the value of slider
        float newPosZ = Mathf.Lerp(-5.0f, -1.0f, zoomSlider.value);
        Camera.main.transform.position = new Vector3(0, 0.5f, newPosZ);
    }

    //------ other functions -----//

    // arrange UIs on the circular path
    private void ArrangeCircularLayout(GameObject[] targetObj)
    {
        float radius = 200;
        float timeSpeed = 25.0f;
        addAngle += Time.deltaTime * timeSpeed;
        int numberOfTarget = targetObj.Length;
        float splitAngle = 360 / numberOfTarget;
        for (int i = 0; i < numberOfTarget; i++)
        {
            var child = targetObj[i].GetComponent<RectTransform>();
            float currentAngle = splitAngle * i;
            child.anchoredPosition = new Vector2(Mathf.Cos((currentAngle + addAngle) * Mathf.Deg2Rad),
                                                 Mathf.Sin((currentAngle + addAngle) * Mathf.Deg2Rad)) * radius;
        }
    }

    // clean up the scene
    private void ClearScene()
    {
        // set false for all objects under Canvas
        int childCount = this.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    //------ other functions -----//


    //----- button event functions -----// 
    // top menu setting
    private void TopMenuSetting()
    {
        ClearScene();
        FormulaUI.SetActive(false);
        MenuCanvas.SetActive(true);
        MenuUI.SetActive(true);
        MenuCloseIcon.SetActive(true);
        playButton.SetActive(true);
        returnButton.SetActive(true);
    }

    // formula button event
    private void FormulaButtonPressed()
    {
        MenuUI.SetActive(false);
        FormulaUI.SetActive(true);
    }

    // resolution button event
    private void ResolutionButtonPressed()
    {
        MenuCanvas.SetActive(false);
        MenuCloseIcon.SetActive(false);
        radialBar.SetActive(true);
        returnButton.SetActive(true);
    }

    // zoom button event
    private void ZoomButtonPressed()
    {
        MenuCanvas.SetActive(false);
        zoomSliderObj.SetActive(true);
        returnButton.SetActive(true);
    }

    // play button event
    private void PlayButtonPressed()
    {
        ClearScene();
        MenuIcon.SetActive(true);
    }
    //----- button event functions -----// 
}
