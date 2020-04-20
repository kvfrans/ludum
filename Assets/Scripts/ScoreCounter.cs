using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        transform.DOKill();
        transform.localPosition = new Vector3(-0.668f,-0.17f,1);
        transform.localEulerAngles = new Vector3(0,0,0);
        transform.DOPunchRotation(new Vector3(0, 0, Custom.RandUni()*5), 0.2f);
        transform.DOPunchPosition(Custom.RandomInUnitCircle()*0.01f, 0.01f);
    }
    public void breakCombo(){
        score=0;
    }
}
