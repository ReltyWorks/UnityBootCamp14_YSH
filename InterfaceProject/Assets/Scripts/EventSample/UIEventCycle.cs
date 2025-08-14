using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventCycle : MonoBehaviour, IPointerEnterHandler,
    IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,
    IPointerClickHandler, // ������ ����
    
    IBeginDragHandler, IDragHandler, IEndDragHandler, // �巡�� ����
    
    ISelectHandler, IDeselectHandler, // ���ð� ���
    ISubmitHandler, ICancelHandler, 

    IScrollHandler,         // ��ũ��
    IUpdateSelectedHandler, // ���� ���¿����� �� �����ӿ� ���� �۾�
    IMoveHandler            // Ű���峪 ���̽�ƽ ����

 { // [class body]

    // �ʵ�
    private int eventCount = 0;
    private float lastEventTime = 0.0f;

    // �̺�Ʈ ó���� �Լ�
    // BaseEventData�� �̺�Ʈ �ý��ۿ��� ���Ǵ� �̺�Ʈ �����Ϳ� ���� ���� Ŭ����
    private void Handle(string eventName, BaseEventData eventData) {
        eventCount++; // ī��Ʈ ����
        float now = Time.time; // �ð� üũ
        float delta = now - lastEventTime; // ������ �̺�Ʈ���� �ð� ������ ����մϴ�.
        lastEventTime = now;

        string pos = ""; // ���� ���� PointerEventData�� ��� ��ǥ�� ���� ��� ó��

        // C# ���� ��Ī
        // 1. eventData is PointerEventData > ��ü�� PointerEventData���� Ȯ��
        // 2. ������ pointerData�� ��ȯ�ؼ� ���� ������ �����Ѵ�.

        if (eventData is PointerEventData pointerData) {
            pos = $"pos : {pointerData.position}";
        }

        StringBuilder sb = new StringBuilder();

        sb.Append($"<color=yellow>{eventCount}</color>"); // �̺�Ʈ Ƚ��
        sb.Append($" <b>{eventName}</b>"); // �̺�Ʈ ��
        sb.Append($" <color=cyan>{delta:F3}</color>"); // �̺�Ʈ �ð� ����
        sb.Append($" <color=blue>{pos}</color>"); // ��ǥ
        // F3 : Fixed-point(�Ҽ��� ����) ���·� �Ҽ��� ���� 3�ڸ����� ǥ���ϼ���!
        // N2 : Number�� ���� ���� 1,234
        // D5 : Decimal(����)�� ���� ���� 01234
        // P1 : (������1) �ۼ�Ʈ�� ���� ��� (�� * 100 ���� %�� ���δ�.)
        //      ex. {0.34 : P1} > 34%

        Debug.Log(sb.ToString());
    }

    private void OnEnable() {
        eventCount = 0;
        lastEventTime = Time.time;
    }

    // �ش� �̺�Ʈ�� �߻��� ������ Handle�� ����˴ϴ�.
    // �����ϴ� ��ɹ��� 1���� ��� �ٿ��� ǥ�� ����
    // ���) ���������� ��ȯŸ�� �Լ���(�Ű�����) => ���� ����;



    public void OnPointerEnter(PointerEventData eventData) => Handle("Pointer Enter", eventData);
    public void OnPointerExit(PointerEventData eventData) => Handle("Pointer Exit", eventData);
    public void OnPointerDown(PointerEventData eventData) => Handle("Pointer Down", eventData);
    public void OnPointerUp(PointerEventData eventData) => Handle("Pointer Up", eventData);
    public void OnPointerClick(PointerEventData eventData) => Handle("Pointer Click", eventData);



    public void OnSelect(BaseEventData eventData) => Handle("Select", eventData);
    public void OnDeselect(BaseEventData eventData) => Handle("Deselect", eventData);
    public void OnSubmit(BaseEventData eventData) => Handle("Submit", eventData);
    public void OnCancel(BaseEventData eventData) => Handle("Cancel", eventData);



    public void OnBeginDrag(PointerEventData eventData) => Handle("Begin Drag", eventData);
    public void OnDrag(PointerEventData eventData) => Handle("Drag", eventData);
    public void OnEndDrag(PointerEventData eventData) => Handle("End Drag", eventData);


    public void OnScroll(PointerEventData eventData) => Handle("Scroll", eventData);
    public void OnUpdateSelected(BaseEventData eventData) => Handle("Update Selected", eventData);
    public void OnMove(AxisEventData eventData) => Handle("Move", eventData);
}
