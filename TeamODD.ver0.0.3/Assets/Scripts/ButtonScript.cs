using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject letterPrefab;
    public GameObject IBM;
    bool Pause;

    // Start is called before the first frame update
    void Start()
    {
        Pause = false;
        IBM.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Pause == false)
        {
            Time.timeScale = 0;
            Pause = true;
        }

        if(Pause == true)
        {
            Time.timeScale = 1;
            Pause = false;
        }
    }

    public void OnResetClick()
    {
        GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampBoardReset();
        GameObject.Find("SealingWaxDummyObj").GetComponent<SealingWaxScript2>().WaxOnOff();
        GameObject.Find("SealingWaxStampObj").GetComponent<SealingStampScript>().WaxStampOnOff();

        SoundManager.soundManager.resetPlaySound();

        GameObject[] linestampPrefabs = GameObject.FindGameObjectsWithTag("LineAndStamp");
        for (int i = 0; i < linestampPrefabs.Length; i++)
        {
            Destroy(linestampPrefabs[i]);
        }

        GameObject[] stampPrefabs = GameObject.FindGameObjectsWithTag("StampBoard");
        for (int i = 0; i < stampPrefabs.Length; i++)
        {
            stampPrefabs[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        GameObject[] waxPrefabs = GameObject.FindGameObjectsWithTag("Wax");
        for (int i = 0; i < waxPrefabs.Length; i++)
        {
            Destroy(waxPrefabs[i]);
        }

        GameObject.Find("GameController").GetComponent<GeneratorControllerScript>().ResetScore();
        GameObject.Find("SealingWaxDummyObj").GetComponent<SealingWaxScript2>().LetterReset();
    }

    public void OnGotoLobbyClick()
    {
        Pause = true;
        IBM.SetActive(true);
    }

    public void OK_Button()
    {
        IBM.SetActive(false);
        Pause = false;
        SceneManager.LoadScene("SampleScene");
    }
    public void Cancel_Button()
    {
        Pause = false;
        IBM.SetActive(false);
    }
}
