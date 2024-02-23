using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class thlist : MonoBehaviour
{
    private UI_DB_Parsing _db_Parsing;
    private GoogleSheetManager _googleSheet;
    public Queue<string> reportQ = new Queue<string>();

    public TextMeshProUGUI[] textMeshs;
    public TextMeshProUGUI[] textMeshs2;

    private void Start()
    {
        TryGetComponent(out _db_Parsing);
        TryGetComponent(out _googleSheet);
    }

    private void Update()
    {
        if (_db_Parsing.textType == UI_DB_Parsing.TextType.Cook)
        {
            // �̳��� Cook�� ���� ����
            if (_googleSheet.thnot)
            {
                string report = _googleSheet.returnlist[1] + "�丮�� �ϼ��Ǿ����ϴ�. ����ġ " + _googleSheet.returnlist[2];
                UiManager.instance.Exp -= 50;
                // ť�� ���ο� ��� �߰� �� ť�� ũ�Ⱑ 3���� �ʰ��ϴ� ��� ������ ��� ����
                if (reportQ.Count >= 3)
                {
                    reportQ.Dequeue();
                }
                reportQ.Enqueue(report);
                _googleSheet.thnot = false;
            }
        }
        else if (_db_Parsing.textType == UI_DB_Parsing.TextType.Campfire)
        {
            // �̳��� Campfire�� ���� ����
            if (_googleSheet.thnot)
            {
                string report = "ķ�����̾� �����";

                // ť�� ���ο� ��� �߰� �� ť�� ũ�Ⱑ 3���� �ʰ��ϴ� ��� ������ ��� ����
                if (reportQ.Count >= 3)
                {
                    reportQ.Dequeue();
                }
                reportQ.Enqueue(report);
                _googleSheet.thnot = false;
            }
        }
        // ť�� �ִ� ������ �ؽ�Ʈ�� �������� ���
        int index = 0;
        foreach (var report in reportQ)
        {
            textMeshs[reportQ.Count - index - 1].text = report;
            textMeshs2[reportQ.Count - index - 1].text = report;
            index++;
        }

        // ���� �ؽ�Ʈ �ʵ� �ʱ�ȭ
        for (int i = reportQ.Count; i < textMeshs.Length; i++)
        {
            textMeshs[i].text = "";
            textMeshs2[i].text = "";
        }
    }

}
