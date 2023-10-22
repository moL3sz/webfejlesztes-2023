using System.ComponentModel.DataAnnotations;

namespace api.DAL.Entities.Common
{

    /// <summary>
    ///  Alap entitás, minden entitásnak ezekből kell származnia
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Azonosító
        /// </summary>
        [Key]
        public int Id { get; set; }


        /// <summary>
        /// Létrehozás dátuma
        /// </summary>
        [Required]
        public DateTime Created {  get; set; }

        /// <summary>
        /// Létrehozó felhasználó
        /// </summary>

        [Required]
        public required string CreatorUserId { get; set; }

        /// <summary>
        /// Létrehozó felhasználóneve
        /// </summary>
        [Required]
        public required string CreatorUserName { get; set;}


        /// <summary>
        /// Módosítás dátuma
        /// </summary>
        [Required]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Módosító felhasználó azonosító
        /// </summary>
        [Required]
        public required string UpdatorUserId { get; set; }


        /// <summary>
        /// Módosító felhasználó neve
        /// </summary>
        [Required]
        public required string UpdaterUserName { get; set; }


        /// <summary>
        /// Aktív
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Klónozott
        /// </summary>
        [Required]
        public bool Clone {  get; set; }


        


    }
}
