﻿namespace School.Data.Bases
{
    public interface IBaseTrackEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
    }
}
