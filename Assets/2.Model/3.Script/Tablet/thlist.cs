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
   
    private void Start()
    {
        TryGetComponent(out _db_Parsing);
        TryGetComponent(out _googleSheet);
    }

    private void Update()
    {
        if (_db_Parsing.textType == UI_DB_Parsing.TextType.Cook)
        {
            // 이넘이 Cook일 때의 동작
            if (_googleSheet.thnot)
            {
                string report = $"{_googleSheet.returnlist[1]}를 완성했습니다. (Exp + {_googleSheet.returnlist[2]})";
                // 큐에 새로운 요소 추가 및 큐의 크기가 3개를 초과하는 경우 오래된 요소 제거
                if (reportQ.Count >= 5)
                {
                    reportQ.Dequeue();
                }
                reportQ.Enqueue(report);
                _googleSheet.thnot = false;
            }
        }
        else if (_db_Parsing.textType == UI_DB_Parsing.TextType.Campfire)
        {
            // 이넘이 Campfire일 때의 동작
            if (_googleSheet.thnot)
            {
                string report = $"캠프파이어의 열기로 캠핑 온도를 획득했습니다. (Exp + 10)";

                // 큐에 새로운 요소 추가 및 큐의 크기가 5개를 초과하는 경우 오래된 요소 제거
                if (reportQ.Count >= 5)
                {
                    reportQ.Dequeue();
                }
                reportQ.Enqueue(report);
                _googleSheet.thnot = false;
            }
        }
        // 큐에 있는 보고서를 텍스트에 역순으로 출력
        int index = 0;
        foreach (var report in reportQ)
        {
            textMeshs[reportQ.Count - index - 1].text = report;
           
            index++;
        }

        // 남은 텍스트 필드 초기화
        for (int i = reportQ.Count; i < textMeshs.Length; i++)
        {
            textMeshs[i].text = "";
           
        }
    }

}
