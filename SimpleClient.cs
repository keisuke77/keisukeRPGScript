//using UnityEngine;
//using UnityEngine.UI;
//using Grpc.Core;
//using Grpc.Core.Utils;
//using Gooseai;
//using System;
//using System.IO;
//using System.Text;
//
////シンプルクライアント
//public class SimpleClient : MonoBehaviour {
//    public Image image;
//    public RawImage rawImage;
//
//    //スタート時に呼ばれる
//    async void Start() {
//        //サーバーとの接続
//        var token = "sk-gBvh4aY1WGwb0XsmIJrXsrCxt5zWI7HaesPkGWMGsgKFCifz";
//        var callCredentials = CallCredentials.FromInterceptor(new AsyncAuthInterceptor((context, metadata) =>
//        {
//            metadata.Add("authorization", "Bearer " + token);
//            return TaskUtils.CompletedTask;
//        }));
//        var secureCredentials = ChannelCredentials.Create(new SslCredentials(), callCredentials);
//        Channel channel = new Channel("grpc.stability.ai:443", secureCredentials);
//        var client = new GenerationService.GenerationServiceClient(channel);
//
//        // プロンプトの生成
//        var prompt = new Prompt();
//        prompt.Text = "white cat";
//
//        // リクエストの生成
//        var request = new Request();
//        request.RequestId = Guid.NewGuid().ToString();
//        request.EngineId = "stable-diffusion-v1-5";
//        request.RequestedType = ArtifactType.ArtifactNone;
//        request.Prompt.Add(prompt);
//        request.Image = new ImageParameters();
//
//        // 通信中
//        var call = client.Generate(request);
//        byte[] bytes = null;
//        while (await call.ResponseStream.MoveNext())
//        {
//            print("processing...");
//            if (call.ResponseStream.Current.Artifacts.Count > 0) {
//                bytes = call.ResponseStream.Current.Artifacts[0].Binary.ToByteArray();
//            }
//        }
//
//        // テクスチャの生成
//        Texture2D texture = new Texture2D(1, 1);
//        texture.LoadImage(bytes);
//
//        // RawImageに表示
//        this.rawImage.texture = texture;
//        this.rawImage.SetNativeSize();
//    }
//}