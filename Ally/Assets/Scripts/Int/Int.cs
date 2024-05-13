using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Variable Type/Int")]
public class Int : ScriptableObject
{
    [SerializeField] private int value;
    public int Value{get{return value;} set{this.value = value; OnValueChanged?.Invoke(value);}}
    public UnityEvent<int> OnValueChanged;

    public static implicit operator int(Int num)
    {
        return num.Value;
    }
}
