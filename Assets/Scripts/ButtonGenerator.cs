using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    private int colCount = 5;
    private int rowCount = 5;

    [SerializeField] private GameObject buttonObj;

    private List<GameObject> buttonList = new List<GameObject>();
    
    private void Awake()
    {
        for(int col = 0; col < colCount; col++)
        {
            for(int row =0; row < rowCount; row++)
            {
                GameObject btnObj = Instantiate(buttonObj);
                btnObj.transform.parent = transform;
                buttonList.Add(btnObj);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
