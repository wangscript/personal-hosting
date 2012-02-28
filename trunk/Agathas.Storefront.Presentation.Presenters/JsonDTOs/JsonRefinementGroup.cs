using System.Runtime.Serialization;

namespace Agathas.Storefront.Presentation.JsonDTOs
{
    [DataContract]
    public class JsonRefinementGroup
    {
        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public int[] SelectedRefinements { get; set; }
    }
}
