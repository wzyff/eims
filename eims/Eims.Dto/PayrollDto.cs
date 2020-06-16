namespace Eims.Dto
{
    public class PayrollDto
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int StaffId { get; set; }
        /// <summary>
        /// 奖惩名
        /// </summary>
        public string AttenName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public float AttenMoney { get; set; }
        /// <summary>
        /// 次数
        /// </summary>
        public int AttenTimes { get; set; }
    }
}
