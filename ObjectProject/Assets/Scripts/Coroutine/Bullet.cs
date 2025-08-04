using System.Collections;
using UnityEngine;

// 총알에 대한 정보, 총알 반납, 총알 이동
public class Bullet : MonoBehaviour {

    [Range(0, 100)] public float speed = 5.0f; // 총알 이동 속도
    [Range(0, 100)] public float life_time = 2.0f; // 총알 반납 시간
    public GameObject effect_prefab; // 이펙트 프리팹

    private BulletPool pool; // 풀
    private Coroutine life_coroutine;


    public void SetPool(BulletPool pool) => this.pool = pool;

    private void OnEnable() {
        life_coroutine = StartCoroutine(IEBulletReturn());
    }

    private void OnDisable() {
        if (life_coroutine != null) StopCoroutine(life_coroutine);
    }

    private void Update() {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator IEBulletReturn() {
        yield return new WaitForSeconds(life_time);
        pool.BulletReturn(gameObject);
    }

    private void OnTriggerEnter(Collider other) {

        // 부딪힌 대상이 Enemy 태그를 가지고ㅗ 있는 오브제[ㄱ트일 경우
        // 데미지를 입힙니다. 와 같은 데미지 관련 코드 작성

        // 이펙트 연출 (파티클)
        if (effect_prefab != null) Instantiate(effect_prefab, transform.position, Quaternion.identity);

        pool.BulletReturn(gameObject);
    }

    // 메소드의 명령이 1줄일 경우, 람다식
    void ReturnPool() => pool.BulletReturn(gameObject);
}
