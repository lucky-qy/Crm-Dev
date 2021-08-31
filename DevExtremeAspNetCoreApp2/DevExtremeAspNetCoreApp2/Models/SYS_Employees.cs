using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevExtremeAspNetCoreApp2.Models 
{
    [Table("SYS_Employees")]
    public class SYS_Employees
    {
        [Key]
        public long StaffID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name="姓名")]
        public string Name { get; set; }
        [Display(Name = "身份证")]
        public string CardNo { get; set; }
        [Display(Name = "性别")]
        public string Sex { get; set; } = "男";
        [Display(Name = "生日")]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public DateTime InDate { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Statues { get; set; }
        public string Photo { get; set; }
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        [Display(Name = "在职状态")]
        public string WorkState { get; set; }
        [Display(Name = "创建日期")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateName { get; set; }

    }
}
