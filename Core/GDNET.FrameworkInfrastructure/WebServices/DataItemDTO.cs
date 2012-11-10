using System;

namespace GDNET.WebInfrastructure.WebServices
{
    [Serializable]
    public class DataItemDTO
    {
        #region Properties

        public string Id
        {
            get;
            set;
        }

        public string Label
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// With protected internal, the JSON result doesn't contain "__type" information. It's great!!!
        /// </summary>
        protected internal DataItemDTO()
        {
        }

        public DataItemDTO(string id, string label)
        {
            this.Id = id;
            this.Label = label;
        }
    }
}