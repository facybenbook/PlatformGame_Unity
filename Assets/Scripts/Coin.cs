using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //코인 클래스

    public GameManager gm;
    public int score;

    void Start()
    {
        gm = GameManager.GetInstance;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") { // 플레이어와 코인이 부딪히면
            gm.totalScore.ScorePlus(10); // 총점수 10 상승
            Debug.Log("Score 10 up!");

            Destroy(gameObject); // 코인 삭제
        }
    }
}
