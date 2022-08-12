﻿namespace Computer_club.WebAPI.Endpoints.FrontendAction.PhotoAction.Update;

public class UpdatePhotoForFrontCommand
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}