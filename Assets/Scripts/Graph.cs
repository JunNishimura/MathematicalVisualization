using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO:
/*
 * deadline for the completion is the end of November
 * ( at least )
 * resolutionとzoomのためのradial barの実装。紐づけ。
 * FormulaUIのexampleの表示、インプット機能の実装
 * ( want )
 * add examples
 * compute shader and increase the resolution
 * increase the variety of prefabs
 * animation corresponding to the formula 
 * performance update
 * パッチ型で関数作れる。んで、作ったやつに自由に名前つけたりしてオリジナル関数を保存できたりする
 * update UI 
 * sound reaction 
 */

public class Graph : MonoBehaviour 
{
    public GameObject pointPrefab;
    public Dropdown dropdown;

    // points of instances
    private List<GameObject> pointslist = new List<GameObject>();
    // resolution
    private int resolution;

    private void Awake()
    {
        ClearLists();
        SetList();
    }

    private void FixedUpdate()
    {
        float t = Time.time;
        float step = 2.0f / resolution;
        GraphFunction f = CollectionOfFunctions.functions[(int)dropdown.value];
        for (int i = 0, z = 0; z < resolution; z++) 
        {
            float v = (z + 0.5f) * step - 1.0f;
            for (int x = 0; x < resolution; x++, i++)
            {
                float u = (x + 0.5f) * step - 1.0f;
                pointslist[i].transform.localPosition = f(u, v, t);
            }
        }
    }

    // this is called from the ApplyChange button in Resolution
    public void OnClickApplyResolution() 
    {
        ClearLists();
        SetList();
        transform.GetComponent<Rotation>().ResetRotation();
    }

    // clear up instance and lists
    private void ClearLists() 
    {
        for (int i = 0; i < resolution * resolution; i++)
        {
            Destroy(pointslist[i]);
        }
        pointslist.Clear();
    }

    // set new resolution. and put them into the list
    private void SetList() 
    {
        //----- resolution setup -----//
        resolution = Resolution.currentSliderValue;
        Debug.Log("Now the resolution is : " + resolution.ToString());

        //----- points setup -----//
        // why 2? because we want to range -1 ~ 1, which means 2.
        float step = 2.0f / resolution;
        Vector3 scale = Vector3.one * step;

        for (int i = 0; i < resolution * resolution; i++)
        {
            GameObject point = Instantiate(pointPrefab);
            point.transform.localScale = scale;
            point.transform.SetParent(transform, false);
            pointslist.Add(point);
        }
    }
}
