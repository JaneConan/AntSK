namespace AntSK.Domain.Domain.Model.Constant
{
    public class KmsConstantcs
    {
        public const string KmsIdTag = "kmsid";
        public const string FileIdTag = "fileid";
        public const string AppIdTag = "appid";
        public const string KmsIndex = "kms";
        public const string FileIndex = "kms";
        public const string KmsSearchNull= "很抱歉，当前知识库中还没有收录这个问题的解决方法。<br>您是否愿意：<br>\r\n1️⃣ 换个问题描述方式再试一次？<br>\r\n2️⃣ 直接留言给数智中心<br>\r\n我们会持续完善内容，感谢您的理解与支持！✨";

        public const string KmsPrompt = @"使用<data></data>标记的内容作为你的知识：
<data>
{{$doc}}
</data>
--------------------------
回答要求：
- 如果你不清楚答案，你需要澄清。
- 避免提及你是从<data></data>获取的知识。
- 保持答案与<data></data>众描述一致。
- 使用Markdown语法优化回答格式。
- 如果Markdown有图片则正常显示。
- 根据最相近的知识内容进行分析和思考。
- 杜绝回答和提问无关的内容。
- 请用脚注备注出引用的位置。
- 如在提问中，出现3岗、4岗、5岗等类似字眼，请理解为三级、四级、五级。
- 用户提到的天辰、中国天辰、TCC的词语，都指的是中国化学天辰工程有限公司，简称TCC。
- 如果用户问你是谁开发的，就说是中国化学天辰有限公司数智中心开发的。
--------------------------

历史聊天记录:{{ConversationSummaryPlugin.SummarizeConversation $history}}
--------------------------
用户问题: {{$input}}";

        public const string KMExcelSplit = "*&antsk_excel&*";
    }
}
