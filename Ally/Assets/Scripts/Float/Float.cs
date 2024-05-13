using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Variable Type/Float")]
public class Float : ScriptableObject
{
    [SerializeField] private float value;
    public float Value{get{return value;} set{this.value = value; OnValueChanged?.Invoke(value);}}
    public UnityEvent<float> OnValueChanged;

    public static implicit operator float(Float num)
    {
        return num.Value;
    }
}
