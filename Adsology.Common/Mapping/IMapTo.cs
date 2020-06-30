using AutoMapper;

namespace Adsology.Common.Mapping
{
    public interface IMapTo<TDestination>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(GetType(), typeof(TDestination));
        }
    }
}
