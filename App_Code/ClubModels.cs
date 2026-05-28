using System;
using System.Collections.Generic;

namespace HACK.WebForms
{
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
        public string ImageUrl { get; set; }
        public string Meta { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
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
