using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_CameraController : MonoBehaviour
{
	private GameObject target; // 追従するターゲットオブジェクト
	private GameObject target2;
	private P_Controller_Platform playerController; // プレイヤーコントローラーへの参照
	public float followSpeed = 5f; // 追従するスピード
	public float cameraHeight = 5f; // カメラの通常の高さ
	public float jumpCameraHeight = 10f; // ジャンプ中のカメラの高さ
	public float downInputCameraHeight = 15f; // isDownInputがtrueの場合のカメラの高さ
	public float overheadCameraHeight = 20f; // 上から斜め後ろのカメラの高さ
	public float cameraDistance = 10f; // カメラのプレイヤーからの距離

	void Start()
	{
		// ターゲットを取得
		target = GameObject.Find("Player1_CameraCube"); // カメラの追従ターゲット
		target2 = GameObject.Find("Player1_Fighter");

		// ターゲットが見つからなかった場合のエラーチェック
		if (target == null)
		{
			Debug.LogError("ターゲットオブジェクトが見つかりません。オブジェクト名が正しいか確認してください。");
			return;
		}

		// プレイヤーコントローラーを取得
		playerController = target2.GetComponent<P_Controller_Platform>();

		// プレイヤーコントローラーが見つからなかった場合のエラーチェック
		if (playerController == null)
		{
			Debug.LogError("プレイヤーコントローラーが見つかりません。P_Controller_Platformスクリプトが正しくアタッチされているか確認してください。");
		}
	}

	void LateUpdate()
	{
		if (target != null)
		{
			// プレイヤーの向きに合わせてカメラを回転させる
			Vector3 lookDirection = -target2.transform.forward; // プレイヤーの後ろを向く方向

			// カメラの高さを決定する
			float currentCameraHeight = cameraHeight;
			if (playerController.isJump)
			{
				// ジャンプ中はジャンプ用の高さに設定
				currentCameraHeight = jumpCameraHeight;

				// カメラの位置をプレイヤーの後ろから見た位置に設定
				Vector3 targetPosition = target.transform.position - target2.transform.forward * cameraDistance + Vector3.up * currentCameraHeight;

				// カメラをターゲットに追従
				transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
			}
			else if (playerController.isDownInput)
			{
				// isDownInputがtrueの場合は斜め後ろにする
				Vector3 offset = new Vector3(-1, 1, -1); // 斜め後ろの方向へのオフセット
				Vector3 targetPosition = target.transform.position + offset.normalized * cameraDistance + Vector3.up * downInputCameraHeight;

				// カメラの位置をプレイヤーの斜め後ろに配置し、スムーズに追従させる
				transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
			}
			else
			{
				// 通常の追従の場合
				Vector3 targetPosition = target.transform.position + lookDirection * cameraDistance + Vector3.up * currentCameraHeight;

				// カメラの位置をプレイヤーの背面に配置し、スムーズに追従させる
				transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
			}

			// ターゲットを向く
			transform.LookAt(target.transform.position);
		}
	}
}
