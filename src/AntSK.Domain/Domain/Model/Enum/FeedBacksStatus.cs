namespace AntSK.Domain.Domain.Model.Enum
{
    public enum FeedBacksStatus
    {
        /// <summary>
        /// 反馈已提交，等待处理
        /// </summary>
        Submitted = 0,

        /// <summary>
        /// 反馈正在处理中
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// 反馈已解决
        /// </summary>
        Resolved = 2,

        /// <summary>
        /// 反馈已关闭（最终状态）
        /// </summary>
        Closed = 3,
    }
}
