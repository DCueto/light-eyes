﻿using light_eyes.DTOs.CheckListItemDto;
using light_eyes.Models;

namespace light_eyes.DTOs.CheckList;

public class UpdateCheckListDto
{
    public string Name { get; set; }
    public string Description { get; set; }= String.Empty;
    public string Language { get; set; } = String.Empty;
    
    public List<UpdateCheckListItemDto> CheckListItems { get; set; }
}