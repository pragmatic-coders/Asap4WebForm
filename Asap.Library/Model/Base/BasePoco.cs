using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asap.Library.Model
{
    public class BasePoco :TopBasePoco
    {
      
        /// <summary>
        /// CreateTime
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// CreateBy
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        public string CreateBy { get; set; }
        /// <summary>
        /// UpdateTime
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// UpdateBy
        /// </summary>
        [Display(Name = "修改人")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        public string UpdateBy { get; set; }
    }
}
