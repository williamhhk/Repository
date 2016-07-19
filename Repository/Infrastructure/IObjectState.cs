using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Infrastructure
{
    public interface IObjectState
    {
        ObjectState ObjectState { get; set; }
    }
    public enum ObjectState
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
}
