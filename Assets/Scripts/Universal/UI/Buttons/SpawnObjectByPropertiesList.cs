using UnityEngine;

namespace UI
{
    public class SpawnObjectByPropertiesList : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ScriptableObject[] _properties;

        [ContextMenu(nameof(SpawnInEditMode))]
        public void SpawnInEditMode()
        {
            if (Application.isPlaying) return;

            GameObject[] allObjects = new GameObject[_parent.childCount];

            for (int i = 0; i < _parent.childCount; i++)
            {
                allObjects[i] = _parent.GetChild(i).gameObject;
            }

            for (int i = 0; i < allObjects.Length; i++)
            {
                DestroyImmediate(allObjects[i]);
            }

            for (int i = 0; i < _properties.Length; i++)
            {
                GameObject gameObject = Instantiate(_prefab, _parent);
                IScriptableObjectProperty scriptableObjectProperty = gameObject.GetComponent<IScriptableObjectProperty>();
                scriptableObjectProperty.ApplyProperty(_properties[i]);
            }
        }
    }
}