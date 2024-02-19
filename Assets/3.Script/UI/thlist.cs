using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class thlist : MonoBehaviour
{
    public GameObject google;
    public UI_DB_Parsing dB_Parsing;
    public GoogleSheetManager googlesheet;
    public Queue<string> reportQ = new Queue<string>();

    public TextMeshProUGUI[] textMeshs;
    public TextMeshProUGUI[] textMeshs2;

    private void Update()
    {
        a();
        if (dB_Parsing.textType == UI_DB_Parsing.TextType.Cook)
        {
            // �̳��� Cook�� ���� ����
            if (googlesheet.thnot)
            {
                string report = googlesheet.returnlist[1] + "�丮�� �ϼ��Ǿ����ϴ�. ����ġ " + googlesheet.returnlist[2] + " ȹ��";

                // ť�� ���ο� ��� �߰� �� ť�� ũ�Ⱑ 3���� �ʰ��ϴ� ��� ������ ��� ����
                if (reportQ.Count >= 3)
                {
                    reportQ.Dequeue();
                }
                reportQ.Enqueue(report);
                googlesheet.thnot = false;
            }
        }
        else if (dB_Parsing.textType == UI_DB_Parsing.TextType.Campfire)
        {
            // �̳��� Campfire�� ���� ����
            if (googlesheet.thnot)
            {
                string report = "ķ�����̾� �����";

                // ť�� ���ο� ��� �߰� �� ť�� ũ�Ⱑ 3���� �ʰ��ϴ� ��� ������ ��� ����
                if (reportQ.Count >= 3)
                {
                    reportQ.Dequeue();
                }
                reportQ.Enqueue(report);
                googlesheet.thnot = false;
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

    public void a()
    {
        google = GameObject.FindGameObjectWithTag("UIManager");
        dB_Parsing = google.GetComponent<UI_DB_Parsing>();
        googlesheet = google.GetComponent<GoogleSheetManager>();
    }
}
