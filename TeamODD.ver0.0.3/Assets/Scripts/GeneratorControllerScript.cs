using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorControllerScript : MonoBehaviour
{
    public GameObject signPrefab;
    public GameObject sealingPrefab;
    public GameObject stampPrefab1;
    public GameObject stampPrefab2;
    public GameObject stampPrefab3;
    public GameObject stampPrefab4;
    public GameObject stampPrefab5;
    public GameObject stampPrefab6;
    public GameObject paperDragPrefab;
    public GameObject completePrefab;
    public GameObject winPrefab;

    public GameObject successTxt;
    public GameObject scoreTxt;
    public GameObject coinTxt;

    public Slider scoreSlider;
    public Text scoreText;

    private int stampAmount = 60;
    private int signAmount = 20;
    private int sealingAmount = 12;
    private int stampEmptyAmount = 30;

    public int pageScore = 0;
    public int currentScore;
    private int totalScore;
    public static bool success = true;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 4;
        sealingAmount = 11;
        totalScore = 0;
        scoreText.text = "0/30";
        SealingOrAnother();
    }

    // Update is called once per frame
    void Update()
    {
        scoreSlider.value = totalScore;
    }

    public void SealingOrAnother()
    {
        if (sealingAmount > 0)
        {
            int random = Random.Range(0, 3);

            switch (random)
            {
                case 0:
                    currentScore = 1;
                    pageScore = 1;
                    SealingGenerator();
                    break;
                case 1:
                    currentScore = 4;
                    pageScore = 4;
                    Row1Random();
                    Row2Random();
                    Row3Random();
                    Row4Random();
                    break;
                case 2:
                    currentScore = 4;
                    pageScore = 4;
                    Row1Random();
                    Row2Random();
                    Row3Random();
                    Row4Random();
                    break;
            }
        }
        else if (sealingAmount == 0)
        {
            currentScore = 4;
            pageScore = 4;
            Row1Random();
            Row2Random();
            Row3Random();
            Row4Random();
        }
    }

    public void Row1Random()
    {
        int random = Random.Range(0, 7);

        if (random == 0)
        {
            if (signAmount == 0)
            {
                Row1Random();
            }
            else if (signAmount > 0)
            {
                Instantiate(signPrefab, new Vector2(0.15f, 1.7f), Quaternion.identity);
                signAmount -= 1;
            }
        }
        else if (random == 1)
        {
            if (stampAmount == 0)
            {
                Row1Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab1, new Vector2(0.15f, 1.7f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 2)
        {
            if (stampAmount == 0)
            {
                Row1Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab2, new Vector2(0.15f, 1.7f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 3)
        {
            if (stampAmount == 0)
            {
                Row1Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab3, new Vector2(0.15f, 1.7f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 4)
        {
            if (stampEmptyAmount == 0)
            {
                Row1Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab4, new Vector2(0.15f, 1.7f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 5)
        {
            if (stampEmptyAmount == 0)
            {
                Row1Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab5, new Vector2(0.15f, 1.7f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 6)
        {
            if (stampEmptyAmount == 0)
            {
                Row1Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab6, new Vector2(0.15f, 1.7f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
    }

    public void Row2Random()
    {
        int random = Random.Range(0, 7);

        if (random == 0)
        {
            if (signAmount == 0)
            {
                Row2Random();
            }
            else if (signAmount > 0)
            {
                Instantiate(signPrefab, new Vector2(0.15f, 0.6f), Quaternion.identity);
                signAmount -= 1;
            }
        }
        else if (random == 1)
        {
            if (stampAmount == 0)
            {
                Row2Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab1, new Vector2(0.15f, 0.6f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 2)
        {
            if (stampAmount == 0)
            {
                Row2Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab2, new Vector2(0.15f, 0.6f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 3)
        {
            if (stampAmount == 0)
            {
                Row2Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab3, new Vector2(0.15f, 0.6f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 4)
        {
            if (stampEmptyAmount == 0)
            {
                Row2Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab4, new Vector2(0.15f, 0.6f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 5)
        {
            if (stampEmptyAmount == 0)
            {
                Row2Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab5, new Vector2(0.15f, 0.6f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 6)
        {
            if (stampEmptyAmount == 0)
            {
                Row2Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab6, new Vector2(0.15f, 0.6f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
    }

    public void Row3Random()
    {
        int random = Random.Range(0, 7);

        if (random == 0)
        {
            if (signAmount == 0)
            {
                Row3Random();
            }
            else if (signAmount > 0)
            {
                Instantiate(signPrefab, new Vector2(0.15f, -0.5f), Quaternion.identity);
                signAmount -= 1;
            }
        }
        else if (random == 1)
        {
            if (stampAmount == 0)
            {
                Row3Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab1, new Vector2(0.15f, -0.5f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 2)
        {
            if (stampAmount == 0)
            {
                Row3Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab2, new Vector2(0.15f, -0.5f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 3)
        {
            if (stampAmount == 0)
            {
                Row3Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab3, new Vector2(0.15f, -0.5f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 4)
        {
            if (stampEmptyAmount == 0)
            {
                Row3Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab4, new Vector2(0.15f, -0.5f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 5)
        {
            if (stampEmptyAmount == 0)
            {
                Row3Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab5, new Vector2(0.15f, -0.5f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 6)
        {
            if (stampEmptyAmount == 0)
            {
                Row3Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab6, new Vector2(0.15f, -0.5f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
    }

    public void Row4Random()
    {
        int random = Random.Range(0, 7);

        if (currentScore == 1)
        {
            random = Random.Range(0, 4);
        }
        if (random == 0)
        {
            if (signAmount == 0)
            {
                Row4Random();
            }
            else if (signAmount > 0)
            {
                Instantiate(signPrefab, new Vector2(0.15f, -1.6f), Quaternion.identity);
                signAmount -= 1;
            }
        }
        else if (random == 1)
        {
            if (stampAmount == 0)
            {
                Row4Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab1, new Vector2(0.15f, -1.6f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 2)
        {
            if (stampAmount == 0)
            {
                Row4Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab2, new Vector2(0.15f, -1.6f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 3)
        {
            if (stampAmount == 0)
            {
                Row4Random();
            }
            else if (stampAmount > 0)
            {
                Instantiate(stampPrefab3, new Vector2(0.15f, -1.6f), Quaternion.identity);
                stampAmount -= 1;
            }
        }
        else if (random == 4)
        {
            if (stampEmptyAmount == 0)
            {
                Row4Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab4, new Vector2(0.15f, -1.6f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 5)
        {
            if (stampEmptyAmount == 0)
            {
                Row4Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab5, new Vector2(0.15f, -1.6f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
        else if (random == 6)
        {
            if (stampEmptyAmount == 0)
            {
                Row4Random();
            }
            else if (stampEmptyAmount > 0)
            {
                Instantiate(stampPrefab6, new Vector2(0.15f, -1.6f), Quaternion.identity);
                currentScore -= 1;
                pageScore -= 1;
                stampEmptyAmount -= 1;
            }
        }
    }

    public void SealingGenerator()
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:
                Instantiate(sealingPrefab, new Vector2(0.15f, 0.7f), Quaternion.identity);
                break;
            case 1:
                Instantiate(sealingPrefab, new Vector2(0.15f, -0.4f), Quaternion.identity);
                break;
        }
        sealingAmount -= 1;
    }
   
    public void PrefabReset()
    {
        GameObject[] stampPrefabs = GameObject.FindGameObjectsWithTag("StampBoard");
        for (int i = 0; i < stampPrefabs.Length; i++)
        {
            Destroy(stampPrefabs[i]);
        }

        GameObject[] signPrefabs = GameObject.FindGameObjectsWithTag("Sign");
        for (int i = 0; i < signPrefabs.Length; i++)
        {
            Destroy(signPrefabs[i]);
        }

        GameObject[] letterPrefabs = GameObject.FindGameObjectsWithTag("Letter");
        for (int i = 0; i < letterPrefabs.Length; i++)
        {
            Destroy(letterPrefabs[i]);
        }

        GameObject[] linestampPrefabs = GameObject.FindGameObjectsWithTag("LineAndStamp");
        for (int i = 0; i < linestampPrefabs.Length; i++)
        {
            Destroy(linestampPrefabs[i]);
        }

        GameObject[] waxPrefabs = GameObject.FindGameObjectsWithTag("Wax");
        for (int i = 0; i < waxPrefabs.Length; i++)
        {
            Destroy(waxPrefabs[i]);
        }
    }
    
    public void Score()
    {
        currentScore--;
        if (currentScore == 0)
        {
            if(success == true)
            {
                if (totalScore == 30)
                {
                    Invoke("PrefabReset", 0.3f);
                    Invoke("FinishPage", 0.3f);
                }   
                else
                {
                    if (!ButtonScript.is_Stop && BoardControllerScript.otherTouchCount == 0)
                    {
                        currentScore = 4;
                        pageScore = 4;
                        GameObject.Find("GameController").GetComponent<BoardControllerScript>().StampBoardOnOff();
                        Invoke("NextPage", 0.3f);
                    }
                }
            }
        }
    }

    public void LetterScore() 
    {
        Debug.Log("LetterScore");
        currentScore--;
        if (currentScore == 0)
        {
            if(success == true)
            {
                if (totalScore == 30)
                {
                    Invoke("PrefabReset", 0.3f);
                    Invoke("FinishPage", 0.3f);
                }
                else
                {
                    PrefabReset();
                    currentScore = 4;
                    pageScore = 4;
                    SealingOrAnother();
                    totalScore++;
                    scoreText.text = totalScore + "/30";
                }
            }
        }
    }

    public void ResetScore()
    {
        currentScore = pageScore;
        success = true;
    }

    public void NextPage()
    {
        Instantiate(paperDragPrefab);
        totalScore++;
        scoreText.text = totalScore + "/30";
    }

    public void FinishPage()
    {
        SoundManager.soundManager.WinPlaySound();
        Instantiate(winPrefab);
        Instantiate(successTxt);
        Instantiate(scoreTxt);
        Instantiate(coinTxt);

    }

    public void FalseScore()
    {
        success = false;
    }
}
