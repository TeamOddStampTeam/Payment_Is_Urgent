using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoBackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GamePlayStop()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
