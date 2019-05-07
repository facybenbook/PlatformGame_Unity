using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어 캐릭터 클래스

    public GameManager gm;

    public float speed; // 이동 속도
    public float jumpPower; // 점프 힘

    Rigidbody2D rigidbody;
    SpriteRenderer renderer;
    Animator animator;

    Vector3 movement; // 오른쪽, 왼쪽 이동 방향을 결정하기 위한 변수
    private int jumpCount = 0; // 점프 횟수를 세기 위한 변수
    public int maxJump; // 총 점프 가능 횟수

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        gm = GameManager.GetInstance;
    }

    void Update()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);

        if(Input.GetAxisRaw("Horizontal") != 0) // 오른쪽, 왼쪽 중 방향키가 하나라도 눌렸다면
            Move(); // 수평적으로 움직이는 함수 호출

        if(Input.GetButtonDown("Jump")) // 점프 버튼(스페이스바)가 눌렸다면
            if(jumpCount < maxJump) // 현재 점프 횟수가 최대 점프횟수를 초과하지 않는다면
                Jump(); // 점프하는 함수 호출
    }

    public void Move() {
        animator.SetBool("Run", true); // 움직이는 애니메이션 재생
        movement.Set(Input.GetAxisRaw("Horizontal"), 0, 0);
        // Input.GetAxisRaw("Horizontal")는 오른쪽일 때 1, 왼쪽일 때 -1을 반환
        // movement 변수에 움직일 방향벡터 설정

        if(Input.GetAxisRaw("Horizontal") < 0) // 움직일 방향이 왼쪽이면
            renderer.flipX = true; // 플레이어 캐릭터 모습 좌우반전
        else if(Input.GetAxisRaw("Horizontal") > 0) // 움직일 방향이 오른쪽이면
            renderer.flipX = false; // 플레이어 캐릭터 모습 그대로 유지

        transform.position += movement * speed * Time.deltaTime;
        // 플레이어 캐릭터의 위치를 '움직일 벡터 방향 * 스피드 * 시간' 으로 조정
    }

    public void Jump() {
        animator.SetBool("Jump", true); // 점프하는 애니메이션 재생
        rigidbody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        // AddForce는 힘을 가하는 함수
        // 위쪽 방향(transform.up) * jumpPower 만큼 힘을 가한다.

        jumpCount++; // 점프 횟수 증가
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Ground") { // 플레이어 캐릭터가 땅에 닿는다면
            jumpCount = 0; // 점프 횟수 0으로 초기화
        }
    }
}
