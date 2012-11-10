using System.ComponentModel.DataAnnotations;
using GDNET.Framework.Base;
using GDNET.Framework.DataAnnotations;
using GreatApp.Domain.Entities;

namespace GreatApp.Infrastructure.Models
{
    public class ContentPartModel : AbstractViewModel<ContentPart>
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DisplayNameML("GUI.ContentPartModel.Name")]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [DisplayNameML("GUI.ContentPartModel.Details")]
        public string Details
        {
            get;
            set;
        }

        public override void Initialize(ContentPart entity, bool filterActiveOnly)
        {
            this.Id = entity.Id.ToString();
            this.Name = entity.Name;
            this.Details = entity.Details;

            base.InitializeCommon(entity);
        }
    }
}
