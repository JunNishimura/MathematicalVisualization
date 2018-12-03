using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//参考：http://baba-s.hatenablog.com/entry/2018/02/15/085200
//参考：http://tsubakit1.hateblo.jp/entry/2016/04/11/070637

public class RadialProgressBar : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int maxResolution;
    public GameObject LoadingBarObj;
    public GameObject PauseButtonObj;
    public GameObject ApplyObj;
    private Image loadingBar;
    private Image loadingStateImage;
    private Button pauseButton;
    private Sprite pauseSprite;
    private Sprite restartSprite;
    private static float currentAmount;
    public static int GetCurrentLoadingResolution
    {
        get
        {
            return (int)currentAmount;
        }
    }
    private bool loadingState;

    private void Awake()
    {
        currentAmount = 0;
        maxResolution = 100;
        loadingBar = LoadingBarObj.GetComponent<Image>();
        loadingStateImage = PauseButtonObj.GetComponent<Image>();
        pauseButton = PauseButtonObj.GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseButtonFunc);
        pauseSprite = Resources.Load<Sprite>("pause");
        restartSprite = Resources.Load<Sprite>("play");
        loadingState = true; // if this is true, then let's increase currentAmount. if NOT, stop increasing.
        loadingStateImage.sprite = pauseSprite; // as default, pauseSprite.
    }

    private void Update()
    {
        // if loadingState is true, then increase the currentAmount
        if (currentAmount <= maxResolution && loadingState)
        {
            currentAmount += speed * Time.deltaTime;
        }
        else if (currentAmount > maxResolution && loadingState)
        {
            currentAmount = 0;
        } 
        else if (!loadingState)
        {
            currentAmount += 0;
        }
        loadingBar.fillAmount = currentAmount / maxResolution;
    }

    private void PauseButtonFunc()
    {
        // change the state
        loadingState = !loadingState;
        if (!loadingState)
        {
            // if the loading bar stops increasing, then show the restart image
            loadingStateImage.sprite = restartSprite;
            ApplyObj.SetActive(true);
        } 
        else
        {
            // if the loading bar is increasing, then show the pause image
            loadingStateImage.sprite = pauseSprite;
            ApplyObj.SetActive(false);
        }
    }
}
