using UnityEngine;

public class UnitView : MonoBehaviour
{
    public Material m_ArmyLineRendererMaterial;

    [SerializeField] MeshFilter m_MeshFilter;
    [SerializeField] MeshRenderer m_MeshRenderer;
    [SerializeField] Transform m_Transform;
    [SerializeField] DrawScript m_DrawScript;
    
    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        MeshFilter = GetComponent<MeshFilter>();
        Transform = GetComponent<Transform>();
        DrawScript = GetComponent<DrawScript>();
        DrawScript.Init();
    }

    public void SetLineRendererMaterial(Material m_ArmyAttackMaterial)
    {
        DrawScript.m_LineRenderer.material = m_ArmyAttackMaterial;
    }

    public void Set(Mesh mesh, Material material, float factor)
    {
        MeshFilter.mesh = mesh;
        MeshRenderer.material = material;
        Transform.localScale *= factor;
    }

    internal void DrawAttackLine(Vector3 position1, Vector3 position2)
    {
        DrawScript.DrawLine(position1, position2);
    }

    public DrawScript DrawScript { get => m_DrawScript; set => m_DrawScript = value; }
    public Transform Transform { get => m_Transform; set => m_Transform = value; }
    public MeshRenderer MeshRenderer { get => m_MeshRenderer; set => m_MeshRenderer = value; }
    public MeshFilter MeshFilter { get => m_MeshFilter; set => m_MeshFilter = value; }

}
