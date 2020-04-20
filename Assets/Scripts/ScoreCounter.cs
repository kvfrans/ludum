using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private TextMesh textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = score.ToString();
    }
    public void hit(){
        score+=1;
    }
    public void breakCombo(){
        score=0;
    }
}
