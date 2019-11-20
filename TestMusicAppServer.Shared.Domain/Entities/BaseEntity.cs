using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMusicAppServer.Shared.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int ClusteredId { get; set; }
    }
}
