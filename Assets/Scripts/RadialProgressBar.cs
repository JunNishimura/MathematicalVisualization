using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//参考：http://baba-s.hatenablog.com/entry/2018/02/15/085200
//参考：http://tsubakit1.hateblo.jp/entry/2016/04/11/070637

public class RadialProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    private void Awake()
    {
        currentAmount = 0;
    }

    private void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }
        else
        {
            currentAmount = 0;
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

    }
}
