using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveRandomNumber : MonoBehaviour
{
    private int randomNumberRange = 25;

    public List<int> deployedRandomNumbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            int rand = CreateRandomNumber(randomNumberRange);
            Debug.Log(rand);
        }
    }

    public int CreateRandomNumber(int range)
    {
        return Random.Range(1, range + 1);
    }

    public bool IsDuplicateNumber(int rand)
    {
        for(int i=0; i < deployedRandomNumbers.Count; i++)
        {
            if(deployedRandomNumbers[i] == rand)
            {
                Debug.Log("중복된 숫자 입니다.");
                return true;
            }
        }
        return false;
    }

    public void DeployedRandomNumbersRemoveAll()
    {
        deployedRandomNumbers.Clear();
        Debug.Log("deploy list count : " + deployedRandomNumbers.Count);
    }
}
