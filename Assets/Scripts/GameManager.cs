using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 전체 오브젝트를 관리하기 위한 매니저 클래스

    public Player player;
    public TotalScore totalScore;
    public Coin coin;

    private static GameManager instance;
	public static GameManager GetInstance{
		get{
            if(instance == null){
                instance = FindObjectOfType<GameManager>() as GameManager;
            }
            return instance;
        }
        //싱글톤 패턴 : GameManager 인스턴스가 오직 하나만 존재하도록 한다.
	}
}
