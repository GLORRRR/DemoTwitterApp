﻿namespace Domain.Entities
{
    using System;

    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}