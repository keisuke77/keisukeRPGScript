namespace osero
{
using UnityEngine;

[CreateAssetMenu(fileName = "oserodata", menuName = "New Unity Project (1)/oserodata", order = 0)]
public class oserodata : ScriptableObject {
    public board board;
    public nowturn nowturn;
    public void Save(board boards){
        board=boards;
    }
}
}