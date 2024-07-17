using light_eyes.DTOs;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class SectionMappers
{
    public static SectionDto ToSectionDto(this Section sectionModel)
    {
        return new SectionDto
        {
            SectionId = sectionModel.SectionId,
            Name = sectionModel.Name,
            Title = sectionModel.Title,
            Content = sectionModel.Content,
            Type = sectionModel.Type,
            Language = sectionModel.Language
        };
    }

    public static Section ToSectionFromCreateDTO(this CreateSectionRequestDto createSectionDto)
    {
        return new Section()
        {
            Name = createSectionDto.Name,
            Title = createSectionDto.Title,
            Content = createSectionDto.Content,
            Type = createSectionDto.Type,
            Language = createSectionDto.Language
        };
    }
    
    public static Section ToSectionFromUpdateDto(this UpdateSectionRequestDto updateSectionDto)
    {
        return new Section()
        {
            Name = updateSectionDto.Name,
            Title = updateSectionDto.Title,
            Content = updateSectionDto.Content,
            Type = updateSectionDto.Type,
            Language = updateSectionDto.Language
        };
    }
}