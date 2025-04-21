using AntDesign;
using AntSK.Domain;
using AntSK.Domain.Domain.Model.Dto.OpenAPI;
using AntSK.Domain.Utils;
using AntSK.Services.OpenApi;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AntSK.Controllers
{
    /// <summary>
    /// 对外接口
    /// </summary>
    [ApiController]
    public class OpenController(IOpenApiService _openApiService) : ControllerBase
    {
        /// <summary>
        /// 对话接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/chat/completions")]
        public async Task Chat(OpenAIModel model)
        {
            string sk = HttpContext.Request.Headers["Authorization"].ConvertToString();
            await _openApiService.Chat(model, sk, HttpContext);
        }

        [HttpPost]
        [Route("api/v1/rerank")]
        public async Task<IActionResult> Rerank(RerankModel model)
        {
            try
            {
                string sk = HttpContext.Request.Headers["Authorization"].ConvertToString();
                var result = await _openApiService.Rerank(model, sk, HttpContext);
                return Ok(result.Success());
            }
            catch (Exception ex)
            {
                return Ok(ResponseResult.Error("1001", ex.Message));
            }

        }

        /// <summary>
        /// 智能体对接接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/models")]
        public async Task Models()
        {
            string sk = HttpContext.Request.Headers["Authorization"].ConvertToString();
            await _openApiService.Models(sk, HttpContext);
        }

        /// <summary>
        /// 对话接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/chat/completions")]
        public async Task Completions(OpenAIModel model)
        {
            string sk = HttpContext.Request.Headers["Authorization"].ConvertToString();
            await _openApiService.Chat(model, sk, HttpContext);
        }

        /// <summary>
        /// 对话接口(带附件)
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("v1/chat/completionswithfile")]
        //public async Task CompletionsWithFile(OpenAIModel model, List<IFormFile> uploadFiles)
        //{
        //    string sk = HttpContext.Request.Headers["Authorization"].ConvertToString();
        //    await _openApiService.Chat(model, sk, HttpContext);

        //    List<UploadFileItem> fileList = [];

        //    foreach (var fileInfo in uploadFiles)
        //    {
        //        fileList.Add(new()
        //        {
        //            FileName = fileInfo.FileName,
        //            Url = fileInfo.Url = fileInfo.Response,
        //            Ext = fileInfo.Ext,
        //            State = UploadState.Success,
        //        });
        //    }
            
        //    _kMService.OnSingleCompleted(fileInfo);
        //    List<string> types = new List<string>() {
        //        "text/plain",
        //        "application/msword",
        //        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        //        "application/vnd.ms-excel",
        //        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //        "application/vnd.ms-powerpoint",
        //        "application/vnd.openxmlformats-officedocument.presentationml.presentation",
        //        "application/pdf",
        //        "application/json",
        //        "text/x-markdown",
        //        "text/markdown",
        //        "image/jpeg",
        //        "image/png",
        //        "image/tiff"
        //    };

        //    string[] exceptExts = [".md", ".pdf"];
        //    var validTypes = types.Contains(file.Type) || exceptExts.Contains(file.Ext);
        //    if (!validTypes && file.Ext != ".md")
        //    {
        //        _message.Error("文件格式错误,请重新选择!");
        //    }
        //    var IsLt500K = file.Size < 1024 * 1024 * 100;
        //    if (!IsLt500K)
        //    {
        //        _message.Error("文件需不大于100MB!");
        //    }

        //    return validTypes && IsLt500K;
        //    try
        //    {
        //        // 验证文件上传参数
        //        if (uploadFile == null || uploadFile.Length == 0)
        //        {
        //            return BadRequest("请选择要上传的文件");
        //        }

        //        // 安全性校验（示例：限制文件类型和大小）
        //        var allowedExtensions = new[] { ".pdf", ".docx", ".txt" };
        //        var fileName = Path.GetFileName(uploadFile.FileName);
        //        var fileExtension = Path.GetExtension(fileName).ToLower();
        //        if (!allowedExtensions.Contains(fileExtension))
        //        {
        //            return BadRequest("仅支持PDF/DOCX/TXT格式文件");
        //        }

        //        if (uploadFile.Length > 10 * 1024 * 1024) // 限制10MB
        //        {
        //            return BadRequest("文件大小不能超过10MB");
        //        }

        //        // 保存文件到安全路径（使用配置文件管理路径）
        //        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
        //        using (var stream = new FileStream(uploadPath, FileMode.Create))
        //        {
        //            await uploadFile.CopyToAsync(stream);
        //        }

        //        // 调用服务层时传递文件信息
        //        await _openApiService.Chat(model, sk, HttpContext, uploadPath);

        //        return Ok("文件上传并处理成功");
        //    }
        //    catch (Exception ex)
        //    {
        //        // 记录异常日志（建议使用日志框架）
        //        return StatusCode(500, $"服务器内部错误: {ex.Message}");
        //    }
        //}


    }
}