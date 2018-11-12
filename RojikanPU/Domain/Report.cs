using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RojikanPU.Domain
{
    [Table("Reports")]
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        public string Reply { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? ProcessDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        public DateTime? RepliedDate { get; set; }

        public string StaffComment { get; set; }

        public string PPKComment { get; set; }        

        public string Type { get; set; }

        [Required]
        public string Origin { get; set; }

        [ForeignKey("PPK")]
        public int? PPKId { get; set; }

        public virtual PPK PPK { get; set; }
        
        public string IDCardFileName { get; set; }

        public string LicenseFileName { get; set; }

        public string OrganizationpermitFileName { get; set; }

        //FILES
        private ICollection<int> _reporterFileIds;
        [NotMapped]
        public ICollection<int> ReporterFileIds
        {
            get { return _reporterFileIds ?? (_reporterFileIds = ReporterFiles.Select(s => s.Id).ToList()); }
            set { _reporterFileIds = value; }
        }

        private ICollection<ReporterFile> _reporterFiles;
        public virtual ICollection<ReporterFile> ReporterFiles
        {
            get { return _reporterFiles ?? (_reporterFiles = new Collection<ReporterFile>()); }
            set { _reporterFiles = value; }
        }

        private ICollection<int> _staffFileIds;
        [NotMapped]
        public ICollection<int> StaffFileIds
        {
            get { return _staffFileIds ?? (_staffFileIds = StaffFiles.Select(s => s.Id).ToList()); }
            set { _staffFileIds = value; }
        }

        private ICollection<StaffFile> _staffFiles;
        public virtual ICollection<StaffFile> StaffFiles
        {
            get { return _staffFiles ?? (_staffFiles = new Collection<StaffFile>()); }
            set { _staffFiles = value; }
        }

        private ICollection<int> _ppkFileIds;
        [NotMapped]
        public ICollection<int> PPKFileIds
        {
            get { return _ppkFileIds ?? (_ppkFileIds = PPKFiles.Select(s => s.Id).ToList()); }
            set { _ppkFileIds = value; }
        }

        private ICollection<PPKFile> _ppkFiles;
        public virtual ICollection<PPKFile> PPKFiles
        {
            get { return _ppkFiles ?? (_ppkFiles = new Collection<PPKFile>()); }
            set { _ppkFiles = value; }
        }
    }
}