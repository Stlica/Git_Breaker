using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_PlayerParth : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public GameObject player1;  // Player1オブジェクトを参照
    public GameObject player2;  // Player2オブジェクトを参照

    public Camera player2Camera; // Player2のカメラ
    public float activationDistance = 500.0f;  // パーティクルが再生される距離の閾値

    private P2_Controller_Platform player2Controller;

    void Start()
    {
        // パーティクルシステムが設定されていない場合、親オブジェクトから取得
        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }
        StopParticles();

        player2Controller = player2.GetComponent<P2_Controller_Platform>();

        // Player1のカメラからパーティクルを非表示にするための設定
        if (player2Camera != null)
        {
            // パーティクルシステム用の新しいレイヤーを作成
            int particleLayer = LayerMask.NameToLayer("ParticleLayer2");
            if (particleLayer == -1)
            {
                // "ParticleLayer" レイヤーが存在しない場合は新規に作成する
                Debug.LogError("Please add a layer named 'ParticleLayer' in the Layer settings.");
            }
            else
            {
                Debug.Log("Setting particle system and children to layer: " + particleLayer);

                // パーティクルシステムとその子オブジェクトを新しいレイヤーに設定
                SetLayerRecursively(particleSystem.gameObject, particleLayer);

                // Player1のカメラのCulling Maskから新しいレイヤーを除外
                Debug.Log("Before Culling Mask: " + player2Camera.cullingMask);
                player2Camera.cullingMask &= ~(1 << particleLayer);
                Debug.Log("After Culling Mask: " + player2Camera.cullingMask);
            }
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(player1.transform.position, player2.transform.position);

        if (distance > activationDistance && !player2Controller.isCrouch && !player2Controller.Special)
        {
            PlayParticles();
        }
        else
        {
            StopParticles();
        }
    }

    // パーティクルを再生するメソッド
    public void PlayParticles()
    {
        if (particleSystem != null && !particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }

    // パーティクルを停止するメソッド
    public void StopParticles()
    {
        if (particleSystem != null && particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }

    // パーティクルを一時停止するメソッド
    public void PauseParticles()
    {
        if (particleSystem != null)
        {
            particleSystem.Pause();
        }
    }

    // パーティクルをクリアするメソッド
    public void ClearParticles()
    {
        if (particleSystem != null)
        {
            particleSystem.Clear();
        }
    }

    // オブジェクトとそのすべての子オブジェクトにレイヤーを再帰的に設定するメソッド
    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;

        obj.layer = newLayer;
        Debug.Log("Setting layer for: " + obj.name);

        foreach (Transform child in obj.transform)
        {
            if (child != null)
            {
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }
    }
}
