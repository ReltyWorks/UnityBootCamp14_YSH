using UnityEngine;

public class Sample2 : MonoBehaviour
{
    public Sample1 Sample1;
    private void Awake() {
        Sample1 = GameObject.FindWithTag("s1").GetComponent<Sample1>();
        // 1. GameObject.FindWithTag("태그이름")
        // >> 씬에서 해당 태그를 가지고 있는 오브젝트를 검색하는 기능
        //      이 기능을 통해 받아오는 값 > gameObject

        // 2. gameObject.GetComponent<T>
        // >> 게임 오브젝트는 GetComponent<T>를 통해 T에 컴포넌트의 유형을
        //      작성해주면 해당 게임오브젝트가 컴포넌트로 가지고 있는 값을 가져옵니다.
        //      이 기능을 통해 받아오는 값 > T

        // public <T> Sample1;
        // Sample1 = GameObject.FindWithTag("s1").GetComponent<T>();
        // T의 위치를 보자

        Debug.Log(Sample1.cc.message);
    }
}