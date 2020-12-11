namespace Kentico.Kontent.Statiq.Lumen.Models
{
    public interface IOpenGraphProfile : IOpenGraph
    {
        string IOpenGraph.OgType => "profile";
        string FirstName { get; }
        string LastName { get; }
        string UserName { get; }

        /// <summary>
        /// "male" or "female"
        /// </summary>
        string Gender { get; }
    }
}
