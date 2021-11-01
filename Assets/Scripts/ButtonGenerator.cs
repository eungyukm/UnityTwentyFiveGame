using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    private int colCount = 5;
    private int rowCount = 5;

    [SerializeField] private GameObject buttonObj;

    private List<GameObject> buttonObjList = new List<GameObject>();

    [SerializeField] private Button[] btnArray;

    private GiveRandomNumber giveRandomNumber;

    private int randomNumber;

    private void Awake()
    {
        Init();

        CreateButton();

        SetUPButtonText();

        SetBtnArray();

        AddButtonClickEventListener();
    }

    private void SetBtnArray()
    {
        btnArray = new Button[buttonObjList.Count];

        for(int i=0; i<buttonObjList.Count; i++)
        {
            btnArray[i] = buttonObjList[i].GetComponent<Button>();
        }
    }

    private void AddButtonClickEventListener()
    {
        for(int i=0; i < btnArray.Length; i++)
        {
            int rand = giveRandomNumber.deployedRandomNumbers[i];
            int btnIndex = i;
            btnArray[i].onClick.AddListener(delegate { RandomNumberButtonClicked(btnIndex, rand); });
        }
    }

    private void RandomNumberButtonClicked(int btnIndex, int rand)
    {
        Debug.Log("btn Index : " + btnIndex);
        Debug.Log("rand :" + rand);

        // 누른 숫자가 GameOver가 아닌지 확인
        bool isGameOver = GameManager.Instance.IsGameOver(rand);
        if(isGameOver)
        {
            GameManager.Instance.GameOverState();

            // 버튼 색상 Green으로 변경
            btnArray[btnIndex].GetComponent<Image>().color = Color.red;
        }
        else
        {
            // 버튼 색상 Green으로 변경
            btnArray[btnIndex].GetComponent<Image>().color = Color.green;
            GameManager.Instance.InCreasingGameNumber();
        }
    }

    private void Init()
    {
        giveRandomNumber = GetComponent<GiveRandomNumber>();
    }

    private void CreateButton()
    {
        for (int col = 0; col < colCount; col++)
        {
            for (int row = 0; row < rowCount; row++)
            {
                GameObject btnObj = Instantiate(buttonObj);
                btnObj.transform.parent = transform;
                buttonObjList.Add(btnObj);
            }
        }
    }

    private void SetUPButtonText()
    {
        giveRandomNumber.DeployedRandomNumbersRemoveAll();
        for(int i=0; i< buttonObjList.Count; i++)
        {
            randomNumber = giveRandomNumber.CreateRandomNumber(colCount * rowCount);
            Text btnText = buttonObjList[i].transform.GetChild(0).GetComponent<Text>();
            if (i == 0)
            {
                SetButtonText(randomNumber, btnText);
            }
            else
            {
                RecursiveDuplicateCheck(randomNumber);
                SetButtonText(randomNumber, btnText);
            }
        }
    }

    private void RecursiveDuplicateCheck(int rand)
    {
        if(!giveRandomNumber.IsDuplicateNumber(rand))
        {
            return;
        }
        randomNumber = giveRandomNumber.CreateRandomNumber(colCount * rowCount);
        RecursiveDuplicateCheck(randomNumber);
    }

    private void SetButtonText(int randomNumber, Text btnText)
    {
        btnText.text = randomNumber.ToString();
        SaveRandomNumber(randomNumber);
    }

    private void SaveRandomNumber(int rand)
    {
        giveRandomNumber.deployedRandomNumbers.Add(rand);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            SetUPButtonText();
        }
    }
}
