using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    // 총점수 클래스

	public GameManager gm;
    public int totalScore;

    private void Start() {
        gm = GameManager.GetInstance;    
    }

    public void ScorePlus(int plus) {
        // 총점수 추가

        totalScore += plus;
    }

    public void ScoreMinus(int minus) {
        // 총점수 감소

        totalScore -= minus;
    }
}
