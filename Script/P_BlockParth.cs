using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BlockParth : MonoBehaviour
{
    public ParticleSystem particleSystem2;
    public GameObject player1;
    public float scaleReductionStep = 0.1f; // パーティクルスケールの減少幅
    public float minScale = 0.1f; // パーティクルの最小スケール
    private P_Controller_Platform player1Controller;
    private Vector3 originalScale; // パーティクルの元のスケールを保存するための変数

    // Start is called before the first frame update
    void Start()
    {
        player1Controller = player1.GetComponent<P_Controller_Platform>();

        // パーティクルの元のスケールを保存する
        originalScale = particleSystem2.transform.localScale;

        StopParticles2();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Controller.isBlocking)
        {
            PlayParticles2();

            // 防御中に攻撃を受けた場合の処理
            if (player1Controller.isweakdamage)
            {
                ReduceParticleScale();
                // 攻撃を受けた後にフラグをリセット
                player1Controller.isweakdamage = false;
            }
        }
        else
        {
            // 防御が解除されたらパーティクルのスケールを元に戻す
            RestoreOriginalScale();

            StopParticles2();
        }
    }

    public void PlayParticles2()
    {
        if (particleSystem2 != null && !particleSystem2.isPlaying)
        {
            particleSystem2.Play();
        }
    }

    public void StopParticles2()
    {
        if (particleSystem2 != null && particleSystem2.isPlaying)
        {
            particleSystem2.Stop();
            particleSystem2.Clear(); // 残りのパーティクルを即時クリア
        }
    }

    private void ReduceParticleScale()
    {
        Vector3 currentScale = particleSystem2.transform.localScale;

        // 新しいスケールを計算し、最小スケールを下回らないようにする
        float newScaleX = Mathf.Max(currentScale.x - scaleReductionStep, minScale);
        float newScaleY = Mathf.Max(currentScale.y - scaleReductionStep, minScale);
        float newScaleZ = Mathf.Max(currentScale.z - scaleReductionStep, minScale);

        // スケールの値を更新
        particleSystem2.transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);

        // 最小スケールを下回った場合の処理
        if (newScaleX <= minScale || newScaleY <= minScale || newScaleZ <= minScale)
        {
            player1Controller.isstrongdamage = true;
            StartCoroutine(player1Controller.DisableBlockInput());
        }

        // デバッグメッセージを追加して、スケールの変更を確認
        Debug.Log("Reduced particle scale: " + particleSystem2.transform.localScale);
    }



    private void RestoreOriginalScale()
    {
        // 元のスケールにパーティクルのスケールを戻す
        particleSystem2.transform.localScale = originalScale;

        // デバッグメッセージを追加して、スケールの変更を確認
        Debug.Log("Restored original particle scale: " + particleSystem2.transform.localScale);
    }

}
