using UnityEngine;

[CreateAssetMenu (fileName = "New Pickable Object Data", menuName = "Pickable Object Data") ]
public class PickableObjectData : ScriptableObject
{
    public string poName = null;
    public int poPoints = 0;
}
