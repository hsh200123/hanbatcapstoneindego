using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataAnalyze : MonoBehaviour
{
    public static string playerType;
    public static float parryRatio;
    public static float dashRatio;
    public static float runRatio;
    public bool changePlayerType;
    private string currentPlayerType;

    void Start()
    {
        currentPlayerType = "";
        changePlayerType = false;
    }

    public void AnalyzePlayerData(Dictionary<string, int> actionData)
    {
        // 총 액션 횟수 계산
        int totalActions = actionData["ParryAttempt"] + actionData["DashAttempt"] + actionData["RunSuccess"];
        
        // 초기 비율 계산
        float[] actionRatios = new float[3];
        actionRatios[0] = (float)actionData["ParryAttempt"] / totalActions;
        actionRatios[1] = (float)actionData["DashAttempt"] / totalActions;
        actionRatios[2] = (float)actionData["RunSuccess"] / totalActions;

        // 소프트맥스 적용
        float[] softmaxRatios = Softmax(actionRatios);

        // 결과 저장
        parryRatio = softmaxRatios[0];
        dashRatio = softmaxRatios[1];
        runRatio = softmaxRatios[2];

        // 플레이어 타입 분류
        string newPlayerType = ClassifyPlayer(parryRatio, dashRatio, runRatio);
        if (newPlayerType != currentPlayerType)
        {
            changePlayerType = true;
            currentPlayerType = newPlayerType;
        }
        else
        {
            changePlayerType = false;
        }

        playerType = newPlayerType;

        // 디버그 출력
        Debug.Log($"Parry Ratio = {parryRatio:F4}, Dash Ratio = {dashRatio:F4}, Run Ratio = {runRatio:F4}, Play Style = {playerType}");
    }

    public float[] Softmax(float[] values)
    {
        float maxVal = Mathf.Max(values); // 안정성을 위해 최대값 기준으로 정규화
        float sumExp = 0f;
        float[] expValues = new float[values.Length];

        // 지수 계산 및 합계
        for (int i = 0; i < values.Length; i++)
        {
            expValues[i] = Mathf.Exp(values[i] - maxVal); // 오버플로우 방지
            sumExp += expValues[i];
        }

        // 소프트맥스 계산
        for (int i = 0; i < values.Length; i++)
        {
            expValues[i] /= sumExp;
        }

        return expValues;
    }

    public string ClassifyPlayer(float parryRatio, float dashRatio, float runRatio)
    {
        Dictionary<string, float> ratios = new Dictionary<string, float>
        {
            { "parry", parryRatio },
            { "dash", dashRatio },
            { "run", runRatio }
        };

        string detectedType = "Balanced";
        float maxRatio = -1f;

        // 가장 높은 비율을 가진 타입 탐색
        foreach (var entry in ratios)
        {
            if (entry.Value > maxRatio)
            {
                maxRatio = entry.Value;
                detectedType = entry.Key;
            }
        }

        // 플레이어 스타일 분류
        if (maxRatio > 0.5f) // High threshold
        {
            return $"High_{detectedType}";
        }
        else if (maxRatio > 0.4f) // Medium threshold
        {
            return detectedType;
        }
        else
        {
            return "Balanced";
        }
    }
}
