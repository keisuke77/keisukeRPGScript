using UnityEngine;

namespace osero
{
    public class DataSaveAndLoad : MonoBehaviour
    {
        public oserodata oserodata;
        public GameSystem GameSystem;

        [Button("DataSave", "セーブ")]
        public int i;

        [Button("DataLoad", "ロード")]
        public int p;

        [Button("FirstGame", "ニューゲーム")]
        public int o;

        public void DataLoad()
        {
            GameSystem.board = oserodata.board.Clone();
            GameSystem.board.Reload();

            GameSystem.nowturn = oserodata.nowturn;
        }

        public void DataSave()
        {
            oserodata.board = GameSystem.board.Clone();
            oserodata.nowturn = GameSystem.nowturn;
        }

        public void FirstGame()
        {
            GameSystem.SetUp();
        }
    }
}
