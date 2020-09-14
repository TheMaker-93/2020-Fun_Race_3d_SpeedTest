using UnityEditor.UIElements;
using UnityEngine;

[System.Serializable]
public class RemoteCollision : RemoteSensor
{
    [SerializeField] protected LayerMask targetedLayerField;
    [SerializeField] private string tagToFilter;

    [SerializeField]
    protected LayerMask Layer
    {
        get
        {
            return targetedLayerField;
        }
        set
        {
            targetedLayerField = value;
        }
    }

    protected string TagToFilter
    {
        get
        {
            return tagToFilter;
        }
        set
        {
            tagToFilter = value;
        }
    }

}