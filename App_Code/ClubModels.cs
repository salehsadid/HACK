using System;
using System.Collections.Generic;

namespace HACK.WebForms
{
    public class ImageResult
    {
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public string FallbackUrl { get; set; }
    }

    public class ClubPerson
    {
        public string PersonType { get; set; }
        public string ClubDesignation { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public bool RemoveImage { get; set; }
        public string Info { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class RegistrationEntry
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Batch { get; set; }
        public string InterestArea { get; set; }
        public string Motivation { get; set; }
        public DateTime SubmittedAt { get; set; }
    }

    public class ClubContentItem
    {
        public string ContentType { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Body { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public bool RemoveImage { get; set; }
        public string Meta { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class HomeFeature
    {
        public string Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class HomeMetric
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class HomePageSettings
    {
        public string HeroEyebrow { get; set; }
        public string HeroTitle { get; set; }
        public string HeroCopy { get; set; }
        public string HeroImageUrl { get; set; }
        public string HeroPrimaryText { get; set; }
        public string HeroPrimaryUrl { get; set; }
        public string HeroSecondaryText { get; set; }
        public string HeroSecondaryUrl { get; set; }
        public List<HomeMetric> Metrics { get; set; }
        public string WhatEyebrow { get; set; }
        public string WhatTitle { get; set; }
        public List<HomeFeature> Features { get; set; }
    }

    public class BlogPost
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
    }

    public static class BlogRepository
    {
        private static readonly List<BlogPost> Posts = new List<BlogPost>
        {
            new BlogPost
            {
                Category = "Workshop",
                Title = "ESP32 sprint lab notes",
                Summary = "Board bring-up, sensor reading, MQTT telemetry, and field debugging lessons from the lab."
            },
            new BlogPost
            {
                Category = "Build Log",
                Title = "Rover platform control loop",
                Summary = "How the robotics team tuned motor response, wiring reliability, and quick service access."
            },
            new BlogPost
            {
                Category = "Digital Design",
                Title = "First HDL timing review",
                Summary = "A practical walkthrough of waveform inspection, timing constraints, and FPGA lab habits."
            }
        };

        public static IReadOnlyList<BlogPost> GetPosts()
        {
            return Posts;
        }
    }
}
