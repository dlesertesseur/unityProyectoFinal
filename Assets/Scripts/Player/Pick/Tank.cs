using UnityEngine;

public class Tank : PickableObject
{
    public override Quaternion InitialRotation()
    {
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);
        return (rotation);
    }
}
