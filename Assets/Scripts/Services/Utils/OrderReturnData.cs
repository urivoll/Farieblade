using ModestTree;
using UnityEngine;

[CreateAssetMenu(fileName ="OrderReturnData", menuName = "ConstData/OrderReturnData")]
public class OrderReturnData : ScriptableObject
{
    [SerializeField] private string[] _cargoData;
    [SerializeField] private string[] _bodyData;
    [SerializeField] private string[] _weightData;
    [SerializeField] private string[] _volumeData;
    public string ReturnCargoData(int index) {return _cargoData[index]; }
    public string ReturnBodyData(int index) {  return _bodyData[index]; }
    public string ReturnWeightData(int index) { return _weightData[index]; }
    public string ReturnVolumeData(int index) { return _volumeData[index]; }

    public int ReturnIndexCargo(string key) { return _cargoData.IndexOf(key); }
    public int ReturnIndexBody(string key) { return _bodyData.IndexOf(key); }
    public int ReturnIndexWeight(string key) { return _weightData.IndexOf(key); }
    public int ReturnIndexVolume(string key) { return _volumeData.IndexOf(key); }

}
