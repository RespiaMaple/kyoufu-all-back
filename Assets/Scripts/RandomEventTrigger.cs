using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventTrigger : MonoBehaviour
{
    public float minTriggerInterval = 10f; // 最小觸發間隔
    public float maxTriggerInterval = 20f; // 最大觸發間隔

    private float nextTriggerTime;

    private void Start()
    {
        // 設定下一次觸發事件的時間
        SetNextTriggerTime();
    }

    private void Update()
    {
        // 檢查是否到達觸發時間
        if (Time.time >= nextTriggerTime)
        {
            // 觸發事件
            TriggerEvent();

            // 設定下一次觸發事件的時間
            SetNextTriggerTime();
        }
    }

    private void SetNextTriggerTime()
    {
        // 隨機生成下一次觸發事件的時間間隔
        nextTriggerTime = Time.time + Random.Range(minTriggerInterval, maxTriggerInterval);
    }

    private void TriggerEvent()
    {
        // 在這裡實現你想要觸發的事件邏輯
        Debug.Log("Random event triggered!");
    }
}
