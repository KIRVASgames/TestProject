using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SoundSystem
{
    [CreateAssetMenu]
    public class SoundsAsset : ScriptableObject
    {
        [SerializeField] private AudioClip[] _sounds;
        public AudioClip this[Sound sound] => _sounds[(int)sound];

#if UNITY_EDITOR

        [CustomEditor(typeof(SoundsAsset))]
        public class SoundsInspector : Editor
        {
            private static readonly int _soundCount = Enum.GetValues(typeof(Sound)).Length;
            private SoundsAsset _target => target as SoundsAsset;

            public override void OnInspectorGUI()
            {
                if (_target._sounds.Length < _soundCount)
                {
                    Array.Resize(ref _target._sounds, _soundCount);
                }

                for (int i = 0; i < _target._sounds.Length; i++)
                {
                    _target._sounds[i] = EditorGUILayout.ObjectField($"{(Sound)i}: ", _target._sounds[i], typeof(AudioClip), false) as AudioClip;
                }

                EditorUtility.SetDirty(_target);
            }
        }
#endif
    }
}