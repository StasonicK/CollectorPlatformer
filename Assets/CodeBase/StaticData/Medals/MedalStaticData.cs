using UnityEngine;

namespace CodeBase.StaticData.Medals
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "StaticData/Medal")]
    public class MedalStaticData : ScriptableObject
    {
        public MedalId MedalId;
        public Sprite Sprite;
    }
}