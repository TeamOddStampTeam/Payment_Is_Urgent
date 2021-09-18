using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCustom : MonoBehaviour
{
    public Text Stuff_Name;

    private void Start()
    {
        Stuff_Name.GetComponent<Text>().text = HubButton.ItemGroup[HubButton.ListNum];
    }

    public void choseSkin()
    {

    }

}
