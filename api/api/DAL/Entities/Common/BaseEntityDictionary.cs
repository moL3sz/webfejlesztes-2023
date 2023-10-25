namespace api.DAL.Entities.Common {
    public class BaseEntityDictionary : BaseEntity{


        /// <summary>
        /// Elsődleges név
        /// </summary>
        public required string NameL1 {  get; set; }

        /// <summary>
        /// Név második nyelven
        /// </summary>
        public string? NameL2 { get; set; }


        /// <summary>
        /// Fátis szám
        /// </summary>
        public int? OrderNumber { get; set; }

        /// <summary>
        /// Project
        /// </summary>
        public int? ProjectId { get; set; }

        public virtual Project? Project { get; set; }
    }
}
