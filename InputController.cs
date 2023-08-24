using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using NCMB;
using System;
 
public class InputController : MonoBehaviour {
 
	// 入力されたテキストへの参照保存用
	private Text _rakugakiText;
 
	// NCMBを利用するためのクラス
	private NCMBObject _testClass;
	private NCMBQuery<NCMBObject> _query;
 
	void Start () {
		// Input Fieldの子要素のText(=入力されたテキスト)への参照を保存
		_rakugakiText = transform.Find("Text").GetComponent<Text>();
	}
 
	public void SaveRakugaki()
	{
		var message = _rakugakiText.text;
		// 何も入力されていなければ処理しない
		if(message == "")
			return;
 
		 // ここからデータの保存処理開始
		 // 検索にはNCMBQueryを使う
		_query = new NCMBQuery<NCMBObject> ("TestClass");
		
		// 保存されているデータ件数を取得
		_query.CountAsync((int count , NCMBException e )=>{
			if(e != null){
				//件数取得失敗時の処理
				Debug.Log("件数の取得に失敗しました");
			}else{
				//データ件数が取得できていたらサーバにデータを送る
				SendRakugakiData(count);
			}
		});
 
	}
 
	void SendRakugakiData(int count)
	{
		// ここで指定したクラス名(=RakugakiClass)でNCMBのデータストアに登録される
		// データストアにそのクラスがなければNCMB側で新規作成してくれる
		// データを送る時に、newしておかないと追加ではなく上書き保存されるので注意
		_testClass = new NCMBObject("TestClass");
 
		// NCMBオブジェクトに値を設定する
		// [ ]内に設定した項目名でデータストアに登録される
		_testClass["id"] = count + 1; // データ保存件数に+1して連番のidを作成
		_testClass["message"] = _rakugakiText.text; // 入力されたテキストをセットで設定
		
		// データストアへデータを登録する
		_testClass.SaveAsync ((NCMBException e) => {      
			if (e != null) {
				//件数取得失敗時の処理
				Debug.Log("データの保存に失敗しました");
			} else {
				//成功時の処理
				Debug.Log("データの保存に成功しました");
			}                   
		});
	}
}