﻿using System.ComponentModel.DataAnnotations;

namespace ComputerClub.DAL.Entities;

public abstract class BaseEntity
{
    [Key] public int Id { get; set; }
}