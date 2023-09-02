namespace HorizontalTabControl.Interfaces
{
    public interface IBasicItem
    {
        object Id { get; set; }
        string Name { get; set; }
        string IconKey { get; set; }
    }
}
