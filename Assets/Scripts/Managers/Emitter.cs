using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject[] waves;//waveを格納する

    private int currentWave;//現在のwave

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //waveが存在しなければコルーチンを終了
        if (waves.Length == 0)
            yield break;

        while (true)
        {

            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            //waveをEmitterの子にする
            wave.transform.parent = transform;

            //waveの子要素のEnemyがすべて消えるまで待機
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            //現在のwaveを削除
            Destroy(wave);

            //全てのwaveを実行したら最初のwaveに戻る(ここはあとで変更する)
            if (waves.Length <= ++currentWave)
                currentWave = 0;
        }
    }
}
