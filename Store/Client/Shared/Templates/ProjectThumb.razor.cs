using Entity = Store.Shared.Entities;

namespace Store.Client.Shared.Templates;

public partial class ProjectThumb
{
    [Parameter, EditorRequired]
    public Entity.Project Project { get; set; } = null!;
}
