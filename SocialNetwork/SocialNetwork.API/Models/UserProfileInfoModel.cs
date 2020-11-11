using System;
using System.Collections.Generic;

namespace SocialNetwork.API.Models
{
    public class UserProfileInfoModel
    {
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Education { get; set; }
        public DateTime CreatedOn { get; set; }

        public TownModel Town { get; set; }

        public string ProfilePictureUrl { get; set; }
        public string CoverPictureUrl { get; set; }
        public ICollection<SocialMediaModel> SocialMedias { get; set; }
    }
}
