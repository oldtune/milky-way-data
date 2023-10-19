using AutoMapper;

namespace QuackQuack.Configs;
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        // CreateMap<WordRecord, WordResponse>()
        // .ForMember(x => x.Word, x => x.MapFrom(x => x.Word))
        // .ForMember(x => x.PronounceVi, x => x.MapFrom(x => x.ViPronounce))
        // .ForMember(x => x.WordTypes, x => x.MapFrom(x => x.WordTypeLinks));

        // CreateMap<WordTypeLink, WordTypeResponse>()
        // .ForMember(x => x.WordTypeEn, x => x.MapFrom(x => x.WordType.En))
        // .ForMember(x => x.WordTypeVi, x => x.MapFrom(x => x.WordType.Vi))
        // .ForMember(x => x.Meanings, x => x.MapFrom(x => x.WordMeanings));

        // CreateMap<WordMeaning, WordMeaningResponse>()
        // .ForMember(x => x.MeaningEn, x => x.MapFrom(x => x.EnMeaning))
        // .ForMember(x => x.MeaningVi, x => x.MapFrom(x => x.ViMeaning))
        // .ForMember(x => x.Examples, x => x.MapFrom(x => x.Examples));

        // CreateMap<Example, ExampleResponse>()
        // .ForMember(x => x.Example, x => x.MapFrom(x => x.EnExample))
        // .ForMember(x => x.ViMeaning, x => x.MapFrom(x => x.ViMeaning));
    }
}