using UnityEngine;

namespace Arj2D
{
    public class Taggable : MonoBehaviour
    {
        [SerializeField] public ScriptableTag[] tags;

        public bool ContainTag(string _tagName)
        {
            foreach (var tg in tags)
            {
                if (tg.name.Equals(_tagName))
                    return true;
            }
            
            return false;
        }
        
        public bool ContainTags(string[] _tagNames)
        {
            if (_tagNames.Length == 0)
                return false;

            foreach (string tagName in _tagNames)
            {
                bool insideTag = ContainTag(tagName);

                if (insideTag == false)
                    return false;
            }
            
            return true;
        }
        
        public bool ContainAnyTags(string[] _tagNames)
        {
            foreach (string tagName in _tagNames)
            {
                if (ContainTag(tagName))
                    return true;
            }
            
            return false;
        }

        public bool ContainTag(ScriptableTag _tag)
        {
            foreach (var tg in tags)
            {
                if (tg.Equals(_tag))
                    return true;
            }
            
            return false;
        }
        
        public bool ContainTags(ScriptableTag[] _tags)
        {
            if (_tags.Length == 0)
                return false;

            foreach (ScriptableTag tg in _tags)
            {
                bool insideTag = ContainTag(tg);

                if (insideTag == false)
                    return false;
            }
            
            return true;
        }
        
        public bool ContainAnyTags(ScriptableTag[] _tags)
        {
            foreach (ScriptableTag tg in _tags)
            {
                if (ContainTag(tg))
                    return true;
            }
            
            return false;
        }
        
    }
}

