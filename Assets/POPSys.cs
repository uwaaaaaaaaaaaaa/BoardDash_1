using UnityEngine;

public class PopSys : MonoBehaviour
{
    //ゴミ箱のオブジェクトを取得
    public GameObject trashCan;
    //ゴミ箱が出てくる座標の指定(縦)
    float popY = -0.3f;
    //ゴミ箱が出てくる間隔の最大値を指定
    public float popInterval = 1.2f;
    //一度に出るゴミ箱の数を指定
    public int popCount = 4;

    //ランダムな間隔でゴミ箱を出す処理
    void Start()
    {
        InvokeRepeating("PopTrashCan", 0f, popInterval);
    }

    void PopTrashCan()
    {
        for (int i = 0; i < popCount; i++)
        {
            //ゴミ箱の出現座標をランダムに指定
            float randomX = Random.Range(1, 2.5f);
            Vector3 popPosition = new Vector3(randomX, popY, 0f);
            //ゴミ箱を生成
            Instantiate(trashCan, popPosition, Quaternion.identity);
        }
    }
}
