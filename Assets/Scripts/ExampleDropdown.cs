using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleDropdown : MonoBehaviour
{

    private void Awake()
    {
        //----- drowdown setup -----//
        // put enum into string arrays
        string[] StringGraphNames = System.Enum.GetNames(typeof(GraphFunctionName));
        // put string arrays into the list
        List<string> list = new List<string>(StringGraphNames);

    }
}
