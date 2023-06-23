#if UNITY_EDITOR
//For use: public string EditorIconPath { get { return "LogoGrey"; } }

public interface IHierarchyIcon
{
    string EditorIconPath { get; }
}
#endif