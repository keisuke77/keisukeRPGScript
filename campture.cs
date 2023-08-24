using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class campture : MonoBehaviour
{
    public Camera ThumbnailCamera; // サムネイル撮影用カメラ
    public float CameraDistance = 1.5f; // カメラを被写体バウンディングボックス半径の何倍離すか

    public RawImage previewImage; // 動作確認用のテクスチャ表示領域...実際の使用時には不要
    public GameObject ObjectToCaptureThumbnail; // 動作確認用の撮影対象...実際の使用時には不要

    // ボタンクリックでサムネイルを撮影する動作確認用メソッド...実際の使用時には不要
    public void Capture()
    {
        if (previewImage.texture != null)
        {
            Destroy(previewImage.texture);
        }

        previewImage.texture = this.TakeThumbnail(this.ObjectToCaptureThumbnail);
    }

    // objのサムネイルを撮影する
    public Texture2D TakeThumbnail(GameObject obj, int width = 256, int height = 256)
    {
        if (obj == null)
        {
            return null;
        }

        var objTransform = obj.transform;
        var cameraTransform = this.ThumbnailCamera.transform;
        var renderers = obj.GetComponentsInChildren<Renderer>(); // 被写体中のレンダラーを全部さらってくる
        var gameObjects = renderers.Select(r => r.gameObject).Distinct().ToArray(); // レンダラーを持つオブジェクト群
        var gameObjectCount = gameObjects.Length;
        var currentLayers = new int[gameObjectCount];
        var photoBoothLayer = LayerMask.NameToLayer("Photo Booth");

        // オブジェクト群のレイヤーをPhoto Boothに変更する
        // 元のレイヤーは後で原状復帰するために覚えておく
        for (var i = 0; i < gameObjectCount; i++)
        {
            var g = gameObjects[i];
            currentLayers[i] = g.layer;
            g.layer = photoBoothLayer;
        }

        var unitedBounds = new Bounds(objTransform.position, Vector3.zero);

        // レンダラー群のバウンディングボックスを全部結合する
        foreach (var r in renderers)
        {
            unitedBounds.Encapsulate(r.bounds);
        }

        var boundsCenter = unitedBounds.center;
        var boundsExtents = unitedBounds.extents;
        var boundsRadius = boundsExtents.magnitude;

        Debug.LogFormat("Bounds center: {0}, extents:{1}, radius:{2}", boundsCenter, boundsExtents, boundsRadius);

        objTransform.Translate(-boundsCenter); // 被写体を原点に移動
        cameraTransform.position = -cameraTransform.forward * (boundsRadius * this.CameraDistance); // カメラを原点からboundsRadius * this.CameraDistanceだけ離した位置に据える

        var film = RenderTexture.GetTemporary(width, height); // 撮影用の一時テクスチャ
        var result = new Texture2D(film.width, film.height); // 撮影結果を格納する新規テクスチャ
        var currentTexture = RenderTexture.active; // 現在のアクティブなテクスチャは退避

        // サムネイルを撮影し、フレームバッファから結果を取得
        this.ThumbnailCamera.targetTexture = film;
        RenderTexture.active = film;
        this.ThumbnailCamera.Render();
        result.ReadPixels(new Rect(0, 0, film.width, film.height), 0, 0);
        result.Apply();
        RenderTexture.active = currentTexture; // アクティブテクスチャを原状復帰
        RenderTexture.ReleaseTemporary(film); // 一時テクスチャは廃棄
        this.ThumbnailCamera.targetTexture = null;

        // オブジェクト群のレイヤーを元に戻す
        for (var i = 0; i < gameObjectCount; i++)
        {
            gameObjects[i].layer = currentLayers[i];
        }

        objTransform.Translate(boundsCenter); // 被写体の位置を元に戻す

        return result;
    }
}