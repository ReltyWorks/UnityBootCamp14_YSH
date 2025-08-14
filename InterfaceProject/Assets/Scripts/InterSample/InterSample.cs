/*
���������� interface �̸�
{

}
[�ۼ� ����]
���� ������ class �ڽ�Ŭ������ : �θ�Ŭ������, �������̽�1, �������̽�2
Ư¡ : �������� ������ �����մϴ�.
������ Ŭ���� ��� : ��ɿ� ���� ������ ����, ���� ��� �Ұ���
                   ���� �����忡 ���� ��� ����
                   ���뼺�� �ִ� �ڵ��� ����� ������ ���� ���踦 �����ִ� ����
�������̽� ��� : ��ɿ� ���� ���踦 ��Ź��, �߰��ٸ� ��Ȱ
                �������̽��� ���� ��� ����
                ���� ��ӿ� ���� ���
                --> ������ ��ü�� �ᱹ �������̽��� ������ 'Ŭ����'�ڽ�
                �������� ���ۿ� ���� ���踦 �����ϴ� ����
>> �������̽��� ���յ��� ���Ƽ�, �������� ���� �ڵ带 ¥�� �����ϰ�
*/


using UnityEngine;

public interface IThrowable {

}
public interface IWeapon {

}
public interface ICountable {

}
public interface IPotion {

}
public interface IUsable {

}
public class Item {

}
public class Sword : Item, IWeapon {

}
public class Jabelin : Item, IWeapon, ICountable, IThrowable {

}
public class MaxPotion : Item, IPotion, ICountable, IUsable {

}
public class FirePotion : Item, IPotion, ICountable, IThrowable {

}

public class InterSample : MonoBehaviour {


}
