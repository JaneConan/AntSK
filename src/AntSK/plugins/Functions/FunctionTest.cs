using AntSK.Domain.Repositories;
using System.ComponentModel;

namespace AntSK.plugins.Functions
{
    public class FunctionTest(IAIModels_Repositories Repository)
    {
        [Description("TCCSK:获取竞价订单信息")]
        [return: Description("竞价订单信息")]
        public string GetOrder([Description("竞价订单号")]  string id)
        {
            return $"""
                    订单ID: {id}
                    商品名：己二腈
                    数量：100 吨
                    价格：4999元
                    收货地址：天津市北辰区
                """;
        }



        [Description("TCCSK:获取模型")]
        [return: Description("模型列表")]
        public string GetModels()
        {
            var models = Repository.GetList();
            return string.Join(",", models.Select(x => x.ModelName));
        }
    }
}