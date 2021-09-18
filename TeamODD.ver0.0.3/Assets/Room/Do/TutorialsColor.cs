using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialsColor : MonoBehaviour
{
    public Image Information;

    static int C = 50;
    bool Up = false;
    public void ChangeColorFlash()
    {
        if(C<10){Up = true;}
        else if(C>130){ Up = false; }

        if (Up == true) { C+=2; }
        else if (Up == false) { C-=2; }

        Information.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, C / 255f);
    }

    private void Update()
    {
        ChangeColorFlash();
    }
}
