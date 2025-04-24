using AntSK.Domain.Domain.Model.Enum;
using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace AntSK.Domain.Repositories
{
    [SugarTable("FeedBacks")]
    public partial class FeedBacks
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        [SugarColumn(ColumnDataType = "varchar(3000)")]
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public FeedBacksStatus? Status { get; set; } = FeedBacksStatus.Submitted;

        /// <summary>
        /// IP地址
        /// </summary>
        public string? IPAddress { get; set; }
    }
}
