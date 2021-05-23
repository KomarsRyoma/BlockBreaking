using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    float posY;

    // Start is called before the first frame update
    void Start()
    {
        // 初期値をセットしておく
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの位置を取得
        Vector3 pos = Input.mousePosition;

        // 画面上の座標に変換する
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));

        // X座標の移動範囲を制限する
        targetPos.x = Mathf.Clamp(targetPos.x, -1.6f, 1.6f);

        // Y座標を固定する
        targetPos.y = posY;

        // バーの位置を動かす
        transform.position = targetPos;
    }
}
